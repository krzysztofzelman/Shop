using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IConfiguration _config;
    public OrderController(IConfiguration config)
    {
        _config = config;
    }
    [HttpGet]
    public List<Order>GetOrders()
    {
        List<Order> orders = new List<Order>();
    string connectionString = _config.GetConnectionString("ShopDb") ?? "";

    using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    connection.Open();
    SqliteCommand command = connection.CreateCommand();
    command.CommandText = "SELECT Id, Date FROM Orders";
    SqliteDataReader reader = command.ExecuteReader();
    while (reader.Read())
    {
        orders.Add(new Order
        {
            Id = Convert.ToInt32(reader["Id"]),
            Date = Convert.ToDateTime(reader["Date"])
        });
    }
}
return orders;
    
    }

    [HttpPost]
    public void AddOrder(Order newOrder)
    {
        string connectionString = _config.GetConnectionString("ShopDb") ?? "";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Orders (Date) VALUES (@Date)";
            command.Parameters.AddWithValue ("@Date", newOrder.Date);          
            command.ExecuteNonQuery();
        }
     }

}
