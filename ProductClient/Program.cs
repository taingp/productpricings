using ProductClient;

ProductHelper.BaseUrl = "https://localhost:7242";
Console.WriteLine("Product Management");
ProductHelper.MenuBank.MenuSimulate(() => { Console.WriteLine(); });
