using MenuLib;
using ProductLib;
using RestClientLib;

namespace ProductClient;
public static class ProductHelper
{
    public static string BaseUrl { get; set; } = "https://localhost:5001";

    public static MenuBank MenuBank { get; set; } = new MenuBank()
    {
        Title = "Products",
        Menus = new List<Menu>()
        {
            new Menu(){ Text= "Viewing", Action=ViewingProducts},
            new Menu(){ Text= "Creating", Action=CreatingProducts},
            new Menu(){ Text= "Updating", Action=UpdatingProducts},
            new Menu(){ Text= "Deleting", Action=DeletingProducts},
            new Menu(){ Text= "Returning", Action = ReturningBack}
        }
    };
    public static void ReturningBack()
        {
            Console.WriteLine("\n[Returning Back]");
            MenuBank.LoopBreak = true;
        }
    private static void DeletingProducts()
    {
        Task.Run(async () =>
        {
            RestClient<Product> restClient = new(BaseUrl);
            Console.WriteLine("\n[Deleting Product]");
            while (true)
            {
                Console.Write("Product Id/Code: ");
                var key = Console.ReadLine() ?? "";
                var endpoint = $"api/products/{key}";
                var result = await restClient.DeleteAsync<Result<string>>(endpoint);
                if (result!.Data != null)
                {
                    Console.WriteLine($"Successfully delete the product with id/code, {key}");
                }
                else
                {
                    Console.WriteLine($"Failed to delete a product with id/code, {key}");
                }

                if (WaitForEscPressed("ESC to stop or any key for more deleting ..."))
                {
                    break;
                }
            }
        }).Wait();
    }
    private static void UpdatingProducts()
    {
        Task.Run(async () =>
        {
            RestClient<Product> restClient = new(BaseUrl);
            Console.WriteLine("\n[Updating Products]");
            while (true)
            {
                Console.Write("Product Id/Code(required): ");
                var key = Console.ReadLine() ?? "";
                var endpoint = "api/products";
                Console.Write("New Name (optional)  : ");
                var name = Console.ReadLine();

                Console.WriteLine($"Category available: {Enum.GetNames<Category>().Aggregate((a, b) => a + ", " + b)}");
                Console.Write("New Category: ");
                var category = Console.ReadLine();

                var result = await restClient.PutAsync<ProductUpdateReq, Result<string>>(endpoint, new ProductUpdateReq()
                {
                    Key = key,
                    Name = name,
                    Category = category
                });

                if (result!.Data !=null)
                {
                    Console.WriteLine($"Successfully update the product with id/code, {key}");
                }
                else
                {
                    Console.WriteLine($"Failed to update the product with id/code, {key}");
                }

                Console.WriteLine();
                if (WaitForEscPressed("ESC to stop or any key for more updating...")) break;
            }
        }).Wait();
    }
    private static bool WaitForEscPressed(string text)
    { 
        Console.Write(text);;
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        Console.WriteLine(keyInfo.KeyChar);
        return keyInfo.Key == ConsoleKey.Escape;
    }
    private static void CreatingProducts()
    {
        Task.Run(async () =>
        {
            RestClient<Product> restClient = new(BaseUrl);
            Console.WriteLine("\n[Creating Product]");
            var endpoint = "api/products";
            while (true)
            {
                var req = GetCreateProduct();
                if (req != null)
                {
                    var result = await restClient.PostAsync<ProductCreateReq, Result<string>>(endpoint, req);
                    var id = result!.Data;
                    if (!string.IsNullOrEmpty(id))
                        Console.WriteLine($"Successfully created a new product with id, {id}");
                    else
                        Console.WriteLine($"Failed to create a new product code, {req.Code}");
                }

                Console.WriteLine();
                if (WaitForEscPressed("ESC to stop or any key for more creating...")) break;
            }
        }).Wait();
    }
    static ProductCreateReq? GetCreateProduct()
    {
        Console.WriteLine($"Category available: {Enum.GetNames<Category>().Aggregate((a, b) => a + ", " + b)}");
        Console.Write("Product(code/name/category): ");
        string data = Console.ReadLine() ?? "";
        var dataParts = data.Split("/");
        if (dataParts.Length < 3)
        {
            Console.WriteLine("Invalid create product's data");
            return null;
        }
        var code = dataParts[0].Trim();
        var name = dataParts[1].Trim();
        var category = dataParts[2].Trim();
       
        return new ProductCreateReq() { Code = code, Name = name, Category = category };

    }
    private static  void ViewingProducts()
    {
        Task.Run(async () =>
        {
            RestClient<Product> restClient = new(BaseUrl);
            Console.WriteLine("\n[Viewing Products]");
            var endpoint = "api/products";
            var result = await restClient.GetAsync<Result<List<ProductResponse>>>(endpoint) ?? new();
            var all = result!.Data??new();
            var count = all.Count;
            Console.WriteLine($"Products: {count}");
            if (count == 0) return;

            Console.WriteLine($"{"Id",-36} {"Code",-10} {"Name",-30} {"Category",-20} {"Price", -5}");
            Console.WriteLine(new string('=', 36 + 1 + 10 + 1 + 30 + 1 + 20 + 1 + 5));
            foreach (var prd in all)
            {
                Console.WriteLine($"{prd.Id,-36} {prd.Code,-10} {prd.Name,-30} {prd.Category,-20} {prd.Price, 5}");
            }
        }).Wait();
    }
}
