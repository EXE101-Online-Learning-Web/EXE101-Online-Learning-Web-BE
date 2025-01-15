using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.request.PaymentRequest;
using OnlineLearningWebAPI.Enum;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        private readonly IOrderService _orderService;

        public PaymentController(IPaymentService paymentService, IOrderService orderService)
        {
            _paymentService = paymentService;
            _orderService = orderService;
        }

        [HttpPost("payment-link")]
        public async Task<IActionResult> CreatePaymentLink([FromBody] CreatePaymentLinkRequest request)
        {
            try
            {
                // Chờ đợi hoàn thành trước khi trả về
                var paymentLink = await _paymentService.CreatePaymentLink(request);
                return Ok(new { PaymentLink = paymentLink });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("paymentSuccess")]
        public async Task<IActionResult> PaymentSuccess(string code, string id, bool cancel, string status, string orderCode)
        {
            // Kiểm tra điều kiện thanh toán thành công
            if (code == "00" && status == "PAID" && !cancel)
            {
                // Cập nhật trạng thái Order
                var result = await _orderService.UpdateOrderStatusAsync(orderCode, OrderStatus.Completed);

                if (result)
                {
                    return Ok(new { message = "Payment successful and order status updated" });
                }

                return NotFound(new { message = "Order not found or invalid orderCode" });
            }

            return BadRequest(new { message = "Payment failed or canceled" });
        }

        [HttpGet("purchaseHistory")]
        public async Task<IActionResult> GetPurchaseHistory(string userId)
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(userId, OrderStatus.Completed);

            if (orders == null || !orders.Any())
            {
                return NotFound(new { message = "No purchase history found" });
            }

            return Ok(orders);
        }

    }
}
