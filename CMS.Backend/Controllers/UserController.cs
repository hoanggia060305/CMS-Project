/*
 * Sinh vien:Nguyen Hoang Gia
 * Ma sv:2123110021
 * Version 1.1
 * Ngay thuc hien:21/5/2016
 */
using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Inject DbContext
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách user
        public IActionResult Index()
        {
            // Lấy dữ liệu THẬT từ database
            var users = _context.Users.ToList();

            // Trả về View
            return View(users);
        }

        // Chi tiết user
        public IActionResult Details(int id)
        {
            // Tìm user theo Id
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            // Nếu không tìm thấy
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
    }
}