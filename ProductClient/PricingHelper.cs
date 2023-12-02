using MenuLib;
using ProductLib;
using RestClientLib;

namespace ProductClient;

public static class PricingHelper
{
    public static string BaseUrl { get; set; } = "https://localhost:5001";

    public static MenuBank MenuBank { get; set; } = new MenuBank()
    {
        Title = "Pricings",
        Menus = new List<Menu>()
        {
            new Menu(){ Text= "Viewing", Action=ViewingPricings},
            new Menu(){ Text= "Creating", Action=CreatingPricings},
            new Menu(){ Text= "Updating", Action=UpdatingPricings},
            new Menu(){ Text= "Deleting", Action=DeletingPricings},
            new Menu(){ Text= "Returning", Action = ReturningBack}
        }
    };
    public static void ReturningBack()
    {
        Console.WriteLine("\n[Returning Back]");
        MenuBank.LoopBreak = true;
    }
    private static void DeletingPricings()
    {
        Task.Run(async () =>
        {
            RestClient<Product> restClient = new(BaseUrl);
            Console.WriteLine("\n[Deleting Pricing]");
            while (true)
            {
                Console.Write("Pricing Id: ");
                var key = Console.ReadLine() ?? "";
                var endpoint = $"api/pricings/{key}";
                var result = await restClient.DeleteAsync<Result<string>>(endpoint);
                if (result!.Data != null)
                {
                    Console.WriteLine($"Successfully delete the pricing with id, {key}");
                }
                else
                {
                    Console.WriteLine($"Failed to delete a pricing with id, {key} > {result!.Message}");
                }

                if (WaitForEscPressed("ESC to stop or any key for more deleting ..."))
                {
                    break;
                }
            }
        }).Wait();
    }
    private static void UpdatingPricings()
    {
        Task.Run(async () =>
        {
            RestClient<Product> restClient = new(BaseUrl);
            Console.WriteLine("\n[Updating Pricings]");
            while (true)
            {
                Console.Write("Pricing Id(required)  : ");
                var id = Console.ReadLine() ?? "";
                Console.Write("Product Key(required): ");
                var productKey = Console.ReadLine() ?? "";
                var endpoint = "api/pricings";
                Console.Write("New Price (required) : ");
                double.TryParse(Console.ReadLine(), out double price);

                var result = await restClient.PutAsync<PricingUpdateReq, Result<string>>(endpoint, new PricingUpdateReq()
                {
                    Id = id,
                    ProductKey = productKey,
                    Value = price,
                });

                if (result!.Data != null)
                {
                    Console.WriteLine($"Successfully update the pricing with id, {id}");
                }
                else
                {
                    Console.WriteLine($"Failed to update the product with id, {id}> {result!.Message}");
                }

                Console.WriteLine();
                if (WaitForEscPressed("ESC to stop or any key for more updating...")) break;
            }
        }).Wait();
    }
    private static bool WaitForEscPressed(string text)
    {
        Console.Write(text); ;
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        Console.WriteLine(keyInfo.KeyChar);
        return keyInfo.Key == ConsoleKey.Escape;
    }
    private static void CreatingPricings()
    {
        Task.Run(async () =>
        {
            RestClient<Product> restClient = new(BaseUrl);
            Console.WriteLine("\n[Creating Pricing]");
            var endpoint = "api/pricings";
            while (true)
            {
                var req = GetCreatePricing();
                if (req != null)
                {
                    var result = await restClient.PostAsync<PricingCreateReq, Result<string>>(endpoint, req);
                    var id = result!.Data;
                    if (!string.IsNullOrEmpty(id))
                        Console.WriteLine($"Successfully created a new pricing with id, {id}");
                    else
                        Console.WriteLine($"Failed to create a new pricing with id, {id}");
                }

                Console.WriteLine();
                if (WaitForEscPressed("ESC to stop or any key for more creating...")) break;
            }
        }).Wait();
    }
    static PricingCreateReq? GetCreatePricing()
    {
        double price = 0;
        while (true)
        {
            Console.Write("Price(required) : ");
            if (double.TryParse(Console.ReadLine(), out price)) break;
            Console.WriteLine("Price is required or invalid");
        }
        string productKey = "";
        while (true)
        {
            Console.Write("Product Key(required): ");
            productKey = Console.ReadLine() ?? "";
            if (!string.IsNullOrEmpty(productKey)) break;
            Console.WriteLine("Product key is required");
        }
        DateTime? effected = null;
        Console.Write("Effected From(optional, yyyy-mm-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out var date)) effected = date;
        
        return new PricingCreateReq() { ProductKey = productKey, Value = price, EffectedFrom= date };
    }
    private static void ViewingPricings()
    {
        Task.Run(async () =>
        {
            RestClient<Pricing> restClient = new(BaseUrl);
            Console.WriteLine("\n[Viewing Pricings]");
            var endpoint = "api/pricings";
            var result = await restClient.GetAsync<Result<List<PricingResponse>>>(endpoint) ?? new();
            var all = result!.Data ?? new();
            var count = all.Count;
            Console.WriteLine($"Pricings: {count}");
            if (count == 0) return;

            var groupResult = all.GroupBy(x => x.ProductCode
                                 , x => new { x.Id, x.Value, x.EffectedFrom }
                                 , (key, g) => new { ProductCode = key, Pricings = g.OrderBy(p=>p.EffectedFrom).ToList() }
                                 ).OrderBy(x=>x.ProductCode).ToList();

            Console.WriteLine($"{"[Product Code]",-15} {"[Id]",-36} {"[Value]",-8} {"[Effected From]",-25}");
            Console.WriteLine(new string('=', 15 + 1 + 36 + 1 + 8 + 1 + 25));
            foreach (var item in groupResult)
            {
                Console.Write($"{item.ProductCode,-15} ");
                var leading = "";
                foreach (var pricing in item.Pricings)
                {
                    Console.WriteLine($"{leading}{pricing.Id,-36} {pricing.Value,8} {pricing.EffectedFrom,-25}");
                    leading = new string(' ', 15 + 1);
                }  
            }

        }).Wait();
    }
}