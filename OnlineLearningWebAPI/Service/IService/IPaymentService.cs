using OnlineLearningWebAPI.DTOs.request.PaymentRequest;
using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IPaymentService
    {
        Task<string> CreatePaymentLink(CreatePaymentLinkRequest request);
        Task<IEnumerable<HistoryPayment>> GetPaymentHistory(string userId);
        Task AddPaymentHistory(HistoryPayment historyPayment);
    }
}
