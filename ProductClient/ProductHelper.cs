using MenuLib;
using ProductLib;


namespace ProductClient;
public static class ProductHelper
{
    private static ProductRepo repo = new ProductRepo();
    public static MenuBank MenuBank { get; set; } = new MenuBank()
    {
        Title = "People",
        Menus = new List<Menu>()
        {
            new Menu(){ Text= "Viewing", Action=ViewingProducts},
            new Menu(){ Text= "Creating", Action=CreatingProducts},
            new Menu(){ Text= "Updating", Action=UpdatingProducts},
            new Menu(){ Text= "Deleting", Action=DeletingProducts},
            new Menu(){ Text= "Exiting", Action = ExitingProgram}
        }
    };
    static ProductHelper()
    {
        repo.Initialize();
    }
    public static void ExitingProgram()
        {
            Console.WriteLine("\n[Exiting Program]");
            Environment.Exit(0);
        }

    private static void DeletingProducts()
        {
            Console.WriteLine("\n[Deleting Product]");
            while (true)
            {
                Console.Write("Product Id/Code: ");
                var key = Console.ReadLine()??"";
                var result = repo.Delete(key);
                if (result ==true)
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
        }
    
    private static void UpdatingProducts()
    {
        Console.WriteLine("\n[Updating Products]");
        while (true)
        {
            Console.Write("Product Id/Code(required): ");
            var key = Console.ReadLine() ?? "";
            if (!repo.Exist(key))
            {
                Console.WriteLine($"No product with the id/code, {key}");
            }
            else
            {
                Console.Write("New Name (optional)  : ");
                var name = Console.ReadLine();

                Console.WriteLine($"Category available: {Enum.GetNames<Category>().Aggregate((a, b) => a + ", " + b)}");
                Console.Write("New Category: ");
                var category = Console.ReadLine();

                var result = repo.Update(new ProductUpdateReq()
                {
                    Key = key,
                    Name = name,
                    Category = category
                });

                if (result == true)
                {
                    Console.WriteLine($"Successfully update the product with id/code, {key}");
                }
                else
                {
                    Console.WriteLine($"Failed to update the product with id/code, {key}");
                }
            }
            Console.WriteLine();
            if (WaitForEscPressed("ESC to stop or any key for more updating...")) break;
        }
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
        Console.WriteLine("\n[Creating People]");
        while (true)
        {
            var req= GetCreateProduct();
            if (req != null)
            {
                var id = repo.Create(req);
                if (!string.IsNullOrEmpty(id))
                    Console.WriteLine($"Successfully created a new product with id, {id}");
                else
                    Console.WriteLine($"Failed to create a new product code, {req.Code}");
            }

            Console.WriteLine();
            if (WaitForEscPressed("ESC to stop or any key for more creating...")) break;
        }
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
    private static void ViewingProducts()
    {
        Console.WriteLine("\n[Viewing Products]");
        var all = repo.ReadAll();
        var count = all.Count;
        Console.WriteLine($"Products: {count}");
        if (count == 0) return;

        Console.WriteLine($"{"Id",-36} {"Code", -10} {"Name",-30} {"Category",-20}");
        Console.WriteLine(new string('=', 36 + 1 + 10 + 1 + 30 + 1  + 20));
        foreach (var prd in all)
        {
            Console.WriteLine($"{prd.Id,-36} {prd.Code, -10} {prd.Name,-30} {prd.Category,-20}");
        }
    }


}
