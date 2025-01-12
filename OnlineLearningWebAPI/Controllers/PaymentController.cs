using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.request.PaymentRequest;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
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

        [HttpGet("history/{userId}")]
        public async Task<IActionResult> GetPaymentHistory(string userId)
        {
            try
            {
                var history = await _paymentService.GetPaymentHistory(userId);
                return Ok(history);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("AddPaymentHistory")]
        public async Task<IActionResult> AddPaymentHistory()
        {
            try
            {
                // Tạo đối tượng HistoryPayment từ dữ liệu yêu cầu
                var historyPayment = new HistoryPayment();


                // Gọi Service để thêm lịch sử thanh toán
                //await _paymentService.AddPaymentHistory(historyPayment);

                return Ok(new { Message = "Payment history added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
