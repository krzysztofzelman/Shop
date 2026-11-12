using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.Security.Cryptography;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IConfiguration _config;

    public UserController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost]
    public IActionResult RegisterUser(User newUser)
    {
        if (string.IsNullOrWhiteSpace(newUser.Login))
        {
            return BadRequest("Login is required");
        }
        if (string.IsNullOrWhiteSpace(newUser.Password))
        {
            return BadRequest("Password is required");
        }

        string connectionString = _config.GetConnectionString("ShopDb") ?? "";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Users (Login, Password) VALUES (@Login, @Password)";
            command.Parameters.AddWithValue("@Login", newUser.Login);
            command.Parameters.AddWithValue("@Password", HashPassword(newUser.Password));
            command.ExecuteNonQuery();
            return Ok();
        }
    }

    [HttpPost("Login")]
    public IActionResult Login(User loginUser)
    {
        string connectionString = _config.GetConnectionString("ShopDb") ?? "";
        int userId = 0;
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id FROM Users WHERE Login = @Login AND Password = @Password";
            command.Parameters.AddWithValue("@Login", loginUser.Login);
            command.Parameters.AddWithValue("@Password", HashPassword(loginUser.Password));
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    userId = Convert.ToInt32(reader["Id"]);
                }
            }

            if (userId == 0)
            {
                return Unauthorized();
            }

            string token = Guid.NewGuid().ToString();
            SqliteCommand insertCommand = connection.CreateCommand();
            insertCommand.CommandText = "INSERT INTO Tokens (UserId, Value) VALUES (@UserId, @Value)";
            insertCommand.Parameters.AddWithValue("@UserId", userId);
            insertCommand.Parameters.AddWithValue("@Value", token);
            insertCommand.ExecuteNonQuery();
            return Ok(token);
        }
    }
    private string HashPassword(string password)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = SHA256.HashData(bytes);
        string hashText = Convert.ToHexString(hash);
        return hashText;
    }
    
} 