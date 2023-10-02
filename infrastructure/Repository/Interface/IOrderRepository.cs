using Infrastructure.QueryModel;

namespace Infrastructure.Repository.Interface;

public interface IOrderRepository
{
    Task<IEnumerable<OrderDashboardQuery>> GetDashboardSalesDataAsync();
}