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
    public class OrderDetailController : Controller
    {
        private readonly IConfiguration _configuration;

        public OrderDetailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<OrderDetail> list = new List<OrderDetail>();

            string connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM OrderDetails";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    OrderDetail item = new OrderDetail
                    {
                        Id = Convert.ToInt32(reader["Id"]),

                        OrderId =
                            Convert.ToInt32(reader["OrderId"]),

                        ProductId =
                            Convert.ToInt32(reader["ProductId"]),

                        Quantity =
                            Convert.ToInt32(reader["Quantity"]),

                        UnitPrice =
                            Convert.ToDecimal(reader["UnitPrice"])
                    };

                    list.Add(item);
                }
            }

            return View(list);
        }
    }
}