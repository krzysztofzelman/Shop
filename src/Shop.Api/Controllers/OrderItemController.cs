using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController : ControllerBase
{
    private readonly IConfiguration _config;

    public OrderItemController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet("{orderId}")]
    public List<OrderItem> GetOrdersItems(int orderId)
    {
        List<OrderItem> items = new List<OrderItem>();
        string connectionString = _config.GetConnectionString("ShopDb");

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, OrderId, ProductId, Quantity, Price FROM OrderItems WHERE OrderId = @OrderId";
            command.Parameters.AddWithValue("@OrderId", orderId);
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new OrderItem
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    OrderId = Convert.ToInt32(reader["OrderId"]),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    Price = Convert.ToDecimal(reader["Price"])
                });
            }
        }
        return items;
    }

    [HttpPost]
    public void AddOrderItem(OrderItem newItem)
    {
        string connectionString = _config.GetConnectionString("ShopDb");
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO OrderItems (OrderId, ProductId, Quantity, Price) VALUES (@OrderId, @ProductId, @Quantity, @Price)";
            command.Parameters.AddWithValue("@OrderId", newItem.OrderId);
            command.Parameters.AddWithValue("@ProductId", newItem.ProductId);
            command.Parameters.AddWithValue("@Quantity", newItem.Quantity);
            command.Parameters.AddWithValue("@Price", newItem.Price);
            command.ExecuteNonQuery();
        }
    }
}
