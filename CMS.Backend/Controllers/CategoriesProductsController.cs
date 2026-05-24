/*
 * Sinh vien: Nguyen Hoang Gia
 * Ma sv: 2123110021
 * Version 1.1
 * Ngay thuc hien:21/5/2016
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } // Quản trị viên hoặc Biên tập viên
    }
}

using CMS.Data;
using Microsoft.AspNetCore.Mvc;

public class CategoriesProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoriesProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var data = _context.CategoriesProducts.ToList();
        return View(data);
    }
}