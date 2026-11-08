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
    public List<Product> GetProducts(int page =1)
    {
        List<Product> products = new List<Product>();
        string connectionString = _config.GetConnectionString("ShopDb") ?? "";
        int pageSize = 10;
        int skip = (page - 1) * pageSize;

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, Quantity, Price FROM Products ORDER BY Id LIMIT @Take OFFSET @Skip";
            command.Parameters.AddWithValue("@Take", pageSize);
            command.Parameters.AddWithValue("@Skip", skip);
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
    public IActionResult AddProduct(Product newProduct)
    {
        if (string.IsNullOrWhiteSpace(newProduct.Name))
        {
            return BadRequest("Name is required");
        }
        if (newProduct.Quantity <= 0)
        {
            return BadRequest("Quantity must be greater than zero.");
        }
        if (newProduct.Price <= 0)
        {
            return BadRequest("Price must be greater then zero");
        }

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
            return Ok();
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct (int id)
    {
        string connectionString = _config.GetConnectionString("ShopDb") ?? "";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Products WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                return NotFound();
            }
            return Ok();
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            return BadRequest("Name is required");
        }
        if (product.Quantity <= 0)
        {
            return BadRequest("Quantity must be greater than zero.");
        }
        if (product.Price <= 0)
        {
            return BadRequest("Price must be greater then zero");
        }
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
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected ==0)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
