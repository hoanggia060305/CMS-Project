/*
 * Sinh vien:Nguyen Hoang Gia
 * Ma sv:2123110021
 * Version 1.0
 * Ngay thuc hien :30/05/2026
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using CMS.Data.Entities;

namespace CMS.Backend.Controllers
{
    public class CategoryProductController : Controller
    {
        private readonly IConfiguration _configuration;

        public CategoryProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<CategoryProduct> list = new List<CategoryProduct>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM CategoriesProducts";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategoryProduct item = new CategoryProduct
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };

                    list.Add(item);
                }
            }

            return View(list);
        }
    }
}