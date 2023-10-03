using Infrastructure.QueryModel;
using Infrastructure.Repository.Interface;
using Service.Service.Interface;

namespace Service.Service;

public class OrderService : IOrderService
{
    
    private readonly IOrderRepository _orderRepository;
    
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    
    public async Task<IEnumerable<OrderDashboardQuery>> GetDashboardSalesDataAsync()
    {
        return await _orderRepository.GetDashboardSalesDataAsync();
    }
}