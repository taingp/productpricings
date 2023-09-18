using ProductLib;
using System.Runtime.CompilerServices;

//Creating a product repository
var repo = new ProductRepo();

//Initializing some products
repo.Initialize();

//Viewing products
Console.WriteLine("\nAll products...");
Viewing(repo);

//Creating new products
Console.WriteLine("\nCreating products...");
var reqs = new List<ProductCreateReq>()
{
    new()
    {
        Code = "PRD100",
        Name = "Land Criser 2026",
        Category = "Vehicle"
    },
    new()
    {
        Code = "PRD101",
        Name = "Diamond Affric Nextlace",
        Category = "Jewelry"
    }
};
reqs.ForEach(x =>
{
    var result = repo.Create(x);
    Console.WriteLine($"New product, {result}, was created");
});


//Viewing products
Console.WriteLine("\nAll products...");
Viewing(repo);

//Method to view products
void Viewing(ProductRepo repo)
{
    Console.WriteLine($"{"Id",-36} {"Code",-10} {"Name",-50} {"Category",-20}");
    Console.WriteLine(new string('=', 36 + 1 + 10 + 1 + 50 + 1 + 20));
    repo.ReadAll().ForEach(x =>
    {
        Console.WriteLine($"{x.Id,-36} {x.Code,-10} {x.Name,-50} {x.Category,-20}");
    });
}
