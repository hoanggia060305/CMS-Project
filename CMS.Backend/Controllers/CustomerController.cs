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
    public class CustomerController : Controller
    {
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<Customer> list = new List<Customer>();

            string connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM Customers";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Customer item = new Customer
                    {
                        Id = Convert.ToInt32(reader["Id"]),

                        FullName = reader["FullName"].ToString(),

                        Email = reader["Email"].ToString(),

                        Phone = reader["Phone"].ToString(),

                        Address = reader["Address"].ToString(),

                        Password = reader["Password"].ToString()
                    };

                    list.Add(item);
                }
            }

            return View(list);
        }
    }
}