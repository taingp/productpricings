using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi;
using ProductLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IDbContext, SqlDbContext>(optionBuilder
    => { optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")); });
builder.Services.AddTransient<IProductRepo, ProductRepo>();
builder.Services.AddTransient<IProductService,ProductService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

MapProductEndpoints(app, "Products");

app.Run();

void MapProductEndpoints(WebApplication app, string tag)
{
    app.MapGet("api/products", (IProductService service) 
        => { return service.ReadAll(); }).WithTags(tag);
    app.MapGet("api/products/{key}", (IProductService service, string key) 
        => { return service.Read(key); }).WithTags(tag);
    app.MapPost("api/products", (IProductService service, ProductCreateReq req) 
        => { return service.Create(req); }).WithTags(tag);
    app.MapPut("api/products", (IProductService service, ProductUpdateReq req) 
        => { return service.Update(req); }).WithTags(tag);
    app.MapDelete("api/products/{key}", (IProductService service, string key) 
        => { return service.Delete(key); }).WithTags(tag);

}

