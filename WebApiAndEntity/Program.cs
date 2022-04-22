using WebApiAndEntity.Entities;
using WebApiAndEntity.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    ProductData db = new ProductData();

    List<Products> products = new();

    products.Add(new Products { Id = 1, Name = "Laptop", StockAmount = 8 });
    products.Add(new Products { Id = 2, Name = "Desktop", StockAmount = 10 });
    products.Add(new Products { Id = 3, Name = "Keyboard", StockAmount = 25 });
    products.Add(new Products { Id = 4, Name = "Mouse", StockAmount = 43 });
    products.Add(new Products { Id = 6, Name = "Printer", StockAmount = 3 });
    products.Add(new Products { Id = 7, Name = "HeadSet", StockAmount = 35 });
    products.Add(new Products { Id = 8, Name = "Scanner", StockAmount = 2 });
    products.Add(new Products { Id = 9, Name = "Controller", StockAmount = 15 });
    products.Add(new Products { Id = 10, Name = "MousePad", StockAmount = 75 });
    products.Add(new Products { Id = 11, Name = "Usb", StockAmount = 53 });
    products.Add(new Products { Id = 12, Name = "SSD", StockAmount = 5 });
    products.Add(new Products { Id = 13, Name = "HDD", StockAmount = 1 });

    db.Products.AddRange(products);
    db.SaveChanges();
    
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
