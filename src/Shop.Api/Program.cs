using Microsoft.Data.Sqlite;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

string cs = builder.Configuration.GetConnectionString("ShopDb") ?? "";
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/api/User"))
    {
        await next();
        return;
    }

    string token = context.Request.Headers["X-Token"].ToString();
    if (TokenExists(token) == false)
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Unauthorized");
        return;
    }
    await next();
});

app.UseAuthorization();

app.MapControllers();
using (SqliteConnection connection = new SqliteConnection(cs))
{
    connection.Open();
    SqliteCommand command = connection.CreateCommand();
    command.CommandText = "CREATE TABLE IF NOT EXISTS Products (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Quantity INTEGER, Price REAL)";
    command.ExecuteNonQuery();
}
using (SqliteConnection connection = new SqliteConnection(cs))
{
    connection.Open();
    SqliteCommand command = connection.CreateCommand();
    command.CommandText = "CREATE TABLE IF NOT EXISTS Orders (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT)";
    command.ExecuteNonQuery();
}
using (SqliteConnection connection = new SqliteConnection(cs))
{
    connection.Open();
    SqliteCommand command = connection.CreateCommand();
    command.CommandText = "CREATE TABLE IF NOT EXISTS OrderItems (Id INTEGER PRIMARY KEY AUTOINCREMENT, OrderId INTEGER, ProductId INTEGER, Quantity INTEGER, Price REAL)";
    command.ExecuteNonQuery();
}
using (SqliteConnection connection = new SqliteConnection(cs))
{
    connection.Open();
    SqliteCommand command = connection.CreateCommand();
    command.CommandText = "CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT, Login TEXT, Password TEXT)";
    command.ExecuteNonQuery();
}
using (SqliteConnection connection = new SqliteConnection(cs))
{
    connection.Open();
    SqliteCommand command = connection.CreateCommand();
    command.CommandText = "CREATE TABLE IF NOT EXISTS Tokens (Id INTEGER PRIMARY KEY AUTOINCREMENT, UserId INTEGER, Value TEXT)";
    command.ExecuteNonQuery();
}

bool TokenExists(string token)
{
    using (SqliteConnection connection = new SqliteConnection(cs))
    {
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT Id FROM Tokens WHERE Value = @Value";
        command.Parameters.AddWithValue("@Value", token);
        using (SqliteDataReader reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                return true;
            }
        }
    }
    return false;

}

app.Run();