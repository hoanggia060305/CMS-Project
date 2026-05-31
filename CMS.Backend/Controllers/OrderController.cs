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
    public class OrderController : Controller
    {
        private readonly IConfiguration _configuration;

        public OrderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<Order> list = new List<Order>();

            string connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM Orders";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Order item = new Order
                    {
                        Id = Convert.ToInt32(reader["Id"]),

                        OrderDate =
                            Convert.ToDateTime(reader["OrderDate"]),

                        CustomerId =
                            Convert.ToInt32(reader["CustomerId"]),

                        Status =
                            Convert.ToInt32(reader["Status"]),

                        Notes = reader["Notes"].ToString()
                    };

                    list.Add(item);
                }
            }

            return View(list);
        }
    }
}