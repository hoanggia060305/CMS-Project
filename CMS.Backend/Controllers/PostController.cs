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
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Inject DbContext
        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách bài viết
        public IActionResult Index()
        {
            // Lấy dữ liệu THẬT từ database
            var posts = _context.Posts.ToList();

            return View(posts);
        }

        // Chi tiết bài viết
        public IActionResult Details(int id)
        {
            // Tìm bài viết theo Id
            var post = _context.Posts.FirstOrDefault(x => x.Id == id);

            // Nếu không tìm thấy
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }
}