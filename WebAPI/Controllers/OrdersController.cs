using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder(TblOrderMaster order)
        {
            if (order == null || order.OrderDetails == null || !order.OrderDetails.Any())
                return BadRequest("Order items are required");

            // Generate unique order number
            order.OrderNo = "ORD-" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            order.OrderDate = DateTime.Now;

            // Set Amount for each detail and assign OrderNo
            foreach (var item in order.OrderDetails)
            {
                item.OrderNo = order.OrderNo; // EF needs this to link master and detail
                item.Amount = item.Quantity * item.Rate;
            }

            // Calculate total
            order.TotalAmount = order.OrderDetails.Sum(x => x.Amount);

            // Add master; details are automatically tracked because they are in the list
            _context.TblOrderMaster.Add(order);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, inner = ex.InnerException?.Message });
            }

            return Ok(new
            {
                OrderNo = order.OrderNo,
                Message = "Order placed successfully"
            });
        }

    }
}