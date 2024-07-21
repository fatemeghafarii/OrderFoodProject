using Microsoft.EntityFrameworkCore;
using OrderFood.Application.Contract.Customers;
using OrderFood.Application.Contract.Foods;
using OrderFood.Application.Contract.Orders;
using OrderFood.Application.Contract.Vendors;
using OrderFood.Application.Customers;
using OrderFood.Application.Foods;
using OrderFood.Application.Orders;
using OrderFood.Application.Vendors;
using OrderFood.Framework.Persistence.EF;
using OrderFood.Persistence.EF.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));


var connectionString = builder.Configuration.GetConnectionString("OrderFoodConnectionString");
builder.Services.AddDbContext<DbContext, OrderFoodContext>(option => option.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
