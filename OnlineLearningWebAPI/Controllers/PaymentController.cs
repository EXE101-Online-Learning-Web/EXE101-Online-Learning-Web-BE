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
		public async Task<IActionResult> PaymentSuccess([FromQuery] PaymentSuccessRequest request)
		{
			// If payment is cancelled
			if (request.Cancel)
			{
				var cancelledOrder = await _orderService.GetOrderByIdAsync(request.OrderCode);
				if (cancelledOrder != null)
				{
					cancelledOrder.Status = OrderStatus.Cancelled;
					await _orderService.UpdateOrderAsync(cancelledOrder);
				}
				return BadRequest(new { Message = "Payment was cancelled." });
			}

			// If payment is successful: code = "00" and status = "PAID"
			if (request.Code == "00" && request.Status.Equals("PAID", StringComparison.OrdinalIgnoreCase))
			{
				var order = await _orderService.GetOrderByIdAsync(request.OrderCode);
				if (order == null)
				{
					return NotFound(new { Message = "Order not found." });
				}

				order.Status = OrderStatus.Completed;
				await _orderService.UpdateOrderAsync(order);

				return Ok(new { Message = "Payment successful. Your course has been activated." });
			}
			else
			{
				return BadRequest(new { Message = "Invalid payment information or transaction failed." });
			}
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
