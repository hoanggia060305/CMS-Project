using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderRequest request)
        {
            if (request.Items == null || request.Items.Count == 0)
            {
                return BadRequest("Giỏ hàng rỗng");
            }

            var order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                Status = 0,
                Notes = request.Notes
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var item in request.Items)
            {
                var product = _context.Products.Find(item.ProductId);

                if (product == null)
                {
                    return BadRequest("Không tìm thấy sản phẩm");
                }

                if (product.StockQuantity < item.Quantity)
                {
                    return BadRequest("Sản phẩm không đủ số lượng tồn kho");
                }

                var detail = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };

                _context.OrderDetails.Add(detail);

                product.StockQuantity -= item.Quantity;
            }

            _context.SaveChanges();

            return Ok(new
            {
                message = "Đặt hàng thành công",
                orderId = order.Id
            });
        }

        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomer(int customerId)
        {
            var data = _context.Orders
                .Where(o => o.CustomerId == customerId)
                .Select(o => new
                {
                    o.Id,
                    o.OrderDate,
                    o.CustomerId,
                    o.Status,
                    o.Notes
                })
                .ToList();

            return Ok(data);
        }
    }

    public class OrderRequest
    {
        public int CustomerId { get; set; }
        public string? Notes { get; set; }
        public List<OrderItemRequest> Items { get; set; }
    }

    public class OrderItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}