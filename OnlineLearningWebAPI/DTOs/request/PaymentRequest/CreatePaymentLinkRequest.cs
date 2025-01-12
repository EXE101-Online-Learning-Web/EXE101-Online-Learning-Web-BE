namespace OnlineLearningWebAPI.DTOs.request.PaymentRequest
{
    public class CreatePaymentLinkRequest
    {
        public string OrderName { get; set; }
        public string Description { get; set; }
        public long TotalPrice { get; set; }
        public string returnUrl { get; set; } = "https://localhost:7091/api/Payment/AddPaymentHistory";
        public string cancelUrl { get; set; } = "https://localhost:7091/api/Test/Fail";
    }
}
