using Dapper;
using Infrastructure.QueryModel;
using Infrastructure.Repository.Interface;
using Npgsql;

namespace Infrastructure.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public OrderRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<IEnumerable<OrderDashboardQuery>> GetDashboardSalesDataAsync()
    {
        await using var connection = await _dataSource.OpenConnectionAsync();
        const string sql = @"
   SELECT
    b.title AS BoxTitle,
    o.order_date AS OrderDate,
    SUM(ob.quantity) AS TotalSales,
    SUM(b.price * ob.quantity) AS TotalPrice
FROM factory.box AS b
JOIN factory.order_box AS ob ON b.id = ob.box_id
JOIN factory.order AS o ON ob.order_id = o.id
GROUP BY b.title, o.order_date
ORDER BY TotalSales DESC, b.title, o.order_date
LIMIT 30;
";
        return await connection.QueryAsync<OrderDashboardQuery>(sql);
    }
}