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

app.UseAuthorization();

app.MapControllers();
string cs = builder.Configuration.GetConnectionString("ShopDb");
using (SqliteConnection connection = new SqliteConnection(cs))
{
    connection.Open();
    SqliteCommand command = connection.CreateCommand();
    command.CommandText = "CREATE TABLE IF NOT EXISTS Products (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Quantity INTEGER, Price REAL)";
    command.ExecuteNonQuery();
}
using (SqliteConnection connection = new SqliteConnection (cs))
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
app.Run();
