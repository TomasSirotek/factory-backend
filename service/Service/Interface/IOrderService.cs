using Infrastructure.QueryModel;

namespace Service.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDashboardQuery>> GetDashboardSalesDataAsync();
    }
}