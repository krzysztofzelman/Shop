using Shop.Web.Components;

using Shop.Web;

using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var polish = new CultureInfo("pl-PL");
CultureInfo.DefaultThreadCurrentCulture = polish;
CultureInfo.DefaultThreadCurrentUICulture = polish;


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
var apiUrl = builder.Configuration["ApiUrl"] ?? "http://localhost:5143";
string secret = builder.Configuration["SecretKey"] ?? "brak-klucza";

builder.Services.AddScoped(sp =>
{
    var client = new HttpClient { BaseAddress = new Uri(apiUrl) };
    client.DefaultRequestHeaders.Add("X-Secret", secret);
    return client;
});

builder.Services.AddScoped<AuthState>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();