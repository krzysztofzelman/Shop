using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IConfiguration _config;

    public ProductController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet]
    public List<Product> GetProducts()
    {
        List<Product> products = new List<Product>();
        string connectionString = _config.GetConnectionString("ShopDb") ?? "";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, Quantity, Price FROM Products";
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = Convert.ToString(reader["Name"]) ?? "",
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    Price = Convert.ToDecimal(reader["Price"])
                });
            }
        }
        return products;
    }
    [HttpPost]
    public void AddProduct(Product newProduct)
    {
        string connectionString = _config.GetConnectionString("ShopDb") ?? "";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Products (Name, Quantity, Price) VALUES (@Name, @Quantity, @Price)";
            command.Parameters.AddWithValue("@Name", newProduct.Name);
            command.Parameters.AddWithValue("@Quantity", newProduct.Quantity);
            command.Parameters.AddWithValue("@Price", newProduct.Price);
            command.ExecuteNonQuery();
        }
    }
    [HttpDelete("{id}")]
    public void DeleteProduct (int id)
    {
        string connectionString = _config.GetConnectionString("ShopDb") ?? "";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Products WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }

    [HttpPut("{id}")]
    public void UpdateProduct(int id, Product product)
    {
        string connectionString = _config.GetConnectionString("ShopDb") ?? "";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Products SET Name=@Name, Quantity=@Quantity, Price=@Price WHERE Id=@Id";
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.ExecuteNonQuery();
        }
    }
}
