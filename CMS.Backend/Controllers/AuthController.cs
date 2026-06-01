using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using CMS.Data;
using CMS.Backend.Helpers;

namespace CMS.Backend.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // 1. Mã hóa mật khẩu người dùng vừa nhập để so sánh với DB
            string hashedInput = SecurityHelper.HashPassword(password);

            // 2. Kiểm tra tài khoản trong SQL
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hashedInput);

            if (user != null)
            {
                // 3. Tạo danh sách thông tin người dùng (Claims) để nạp vào thẻ bài Cookie
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("FullName", user.FullName),
                    new Claim(ClaimTypes.Role, user.Role) // Lưu quyền: Admin hoặc Editor
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // 4. Chính thức cấp Cookie đăng nhập
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }

            // Nếu sai tài khoản/mật khẩu
            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác!");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            // Xóa Cookie đăng nhập
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View(); // Trả về giao diện báo lỗi không có quyền truy cập
        }
    }
}