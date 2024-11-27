using Azure.Identity;
using Common;
using DataAccess.Extensions;
using DataFactory.Extensions;
using IgClient.Extensions;
using TradingService.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (builder.Environment.IsDevelopment())
{
    // builder.Configuration.AddUserSecrets<Program>();
}
else
{
    var kvUri = "https://ig-api-keys.vault.azure.net/";
    builder.Configuration.AddAzureKeyVault(new Uri(kvUri), new DefaultAzureCredential());
}

builder.Services.AddControllersWithViews();
builder.Services.AddDataAccessServices(ServiceLifetime.Scoped);
builder.Services.AddDataFactoryServices();
builder.Services.AddIgClientServices();
builder.Services.AddTradingServices();
builder.Services.AddDataFactoryServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUriService>(o =>
{
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(uri);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    "default",
    "{controller}/{action=Index}/{id?}");


app.MapFallbackToFile("index.html");
;

app.Run();