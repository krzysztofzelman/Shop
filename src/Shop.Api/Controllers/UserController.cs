using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

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
            command.Parameters.AddWithValue("@Password", newUser.Password);
            command.ExecuteNonQuery();
            return Ok();
        }
    }
}