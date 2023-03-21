using Microsoft.EntityFrameworkCore;
using Repository;
using Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IPasswordsService, PasswordsService>();

builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddDbContext<MyShopSite325593952Context>(options => options.UseSqlServer
(@"Server=srv2\PUPILS;Database=MyShopSite_325593952;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
