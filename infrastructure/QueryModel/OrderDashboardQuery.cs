namespace Infrastructure.QueryModel;

public class OrderDashboardQuery
{
    public string? BoxTitle { get; set; } // Match the alias 'box_title'
    public DateTime OrderDate { get; set; } // Match the alias 'order_date'
    public int TotalSales { get; set; } // Match the alias 'total_sales'
    public decimal TotalPrice { get; set; } // Match the alias 'total_price'
}
