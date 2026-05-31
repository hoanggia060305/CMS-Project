/*
 * Sinh vien:Nguyen Hoang Gia
 * Ma sv:2123110021
 * Version 1.0
 * Ngay thuc hien :14/05/2026
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using CMS.Data.Entities;

namespace CMS.Backend.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<Product> list = new List<Product>();

            string connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM Products";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product item = new Product
                    {
                        Id = Convert.ToInt32(reader["Id"]),

                        Name = reader["Name"].ToString(),

                        Description = reader["Description"].ToString(),

                        Price = Convert.ToDecimal(reader["Price"]),

                        StockQuantity =
                            Convert.ToInt32(reader["StockQuantity"]),

                        ImageUrl = reader["ImageUrl"].ToString(),

                        CategoryProductId =
                            Convert.ToInt32(reader["CategoryProductId"])
                    };

                    list.Add(item);
                }
            }

            return View(list);
        }
    }
}