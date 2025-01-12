using Net.payOS;
using Net.payOS.Types;
using OnlineLearningWebAPI.DTOs.request.PaymentRequest;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly PayOS _payOS;

        private readonly IHistoryPaymentRepository _historyPaymentRepository;

        public PaymentService(PayOS payOS, IHistoryPaymentRepository historyPaymentRepository)
        {
            _payOS = payOS;
            _historyPaymentRepository = historyPaymentRepository;
        }
        public async Task<string> CreatePaymentLink(CreatePaymentLinkRequest request)
        {
            // Gửi yêu cầu tạo link thanh toán
            int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
            ItemData item = new ItemData(request.OrderName, 1, (int)request.TotalPrice);
            List<ItemData> items = new List<ItemData> { item };
            PaymentData paymentData = new PaymentData(orderCode, (int)request.TotalPrice, request.Description, items, request.cancelUrl, request.returnUrl);

            CreatePaymentResult response = await _payOS.createPaymentLink(paymentData);

            if (response == null || string.IsNullOrEmpty(response.checkoutUrl))
            {
                throw new Exception("Failed to create payment link");
            }

            return response.checkoutUrl;
        }

        public async Task<IEnumerable<HistoryPayment>> GetPaymentHistory(string userId)
        {
            return await _historyPaymentRepository.GetPaymentHistoryAsync(userId);
        }

        public async Task AddPaymentHistory(HistoryPayment historyPayment)
        {
            await _historyPaymentRepository.AddPaymentHistoryAsync(historyPayment);
            await _historyPaymentRepository.SaveAsync();
        }
    }
}
