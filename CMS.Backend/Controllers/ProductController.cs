/*
 * Sinh vien:Nguyen Hoang Gia
 * Ma sv:2123110021
 * Version 1.1
 * Ngay thuc hien:21/5/2016
 */
using CMS.Data;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var data = _context.Products.ToList();
        return View(data);
    }
}