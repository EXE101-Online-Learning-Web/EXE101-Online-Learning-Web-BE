using OnlineLearningWebAPI.Enum;
using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IOrderService
    {
        Task<bool> UpdateOrderStatusAsync(string orderCode, OrderStatus status);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId, OrderStatus status);
    }
}
