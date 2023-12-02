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
builder.Services.AddTransient<IPricingRepo, PricingRepo>();
builder.Services.AddTransient<IPricingService, PricingService>();

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
MapPricingEndpoints(app, "Pricings");

app.Run();

void MapProductEndpoints(WebApplication app, string tag)
{
    app.MapGet("api/products", (IProductService service, DateTime? actingDate) 
        => { return service.SetActingDate(actingDate).ReadAll(); }).WithTags(tag);
    app.MapGet("api/products/{key}", (IProductService service, string key, DateTime? actingDate) 
        => { return service.SetActingDate(actingDate).Read(key); }).WithTags(tag);
    app.MapPost("api/products", (IProductService service, ProductCreateReq req) 
        => { return service.Create(req); }).WithTags(tag);
    app.MapPost("api/products/batch",
                ([FromServices] IProductService service, List<ProductCreateReq> reqs) =>
                { return service.CreateRange(reqs); }).WithTags(tag);
    app.MapPut("api/products", (IProductService service, ProductUpdateReq req) 
        => { return service.Update(req); }).WithTags(tag);
    app.MapDelete("api/products/{key}", (IProductService service, string key) 
        => { return service.Delete(key); }).WithTags(tag);
}
void MapPricingEndpoints(WebApplication app, string tag)
{
    app.MapGet("api/pricings", (IPricingService service)
        => { return service.ReadAll(); }).WithTags(tag);
    app.MapGet("api/pricings/{key}", (IPricingService service, string key)
        => { return service.Read(key); }).WithTags(tag);
    app.MapPost("api/pricings", (IPricingService service, PricingCreateReq req)
        => { return service.Create(req); }).WithTags(tag);
    app.MapPut("api/pricings", (IPricingService service, PricingUpdateReq req)
        => { return service.Update(req); }).WithTags(tag);
    app.MapDelete("api/pricings/{key}", (IPricingService service, string key)
        => { return service.Delete(key); }).WithTags(tag);

}

