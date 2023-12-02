using MenuLib;
using ProductClient;

string baseUri = "https://localhost:7242";
ProductHelper.BaseUrl = baseUri;
PricingHelper.BaseUrl = baseUri;

MenuBank menuBank = new MenuBank()
{
    Title = "Product Pricings",
    Menus = new List<Menu>()
        {
            new Menu(){ Text= "Products", Action=ProductMenus},
            new Menu(){ Text= "Pricings", Action=PricingMenus},
            new Menu(){ Text= "Exiting", Action=ExitingProgram}
        }
};
menuBank.MenuSimulate(() => { Console.WriteLine(); });



void PricingMenus()
{
     PricingHelper.MenuBank.MenuSimulate(() => { Console.WriteLine(); });
}

void ProductMenus()
{
    ProductHelper.MenuBank.MenuSimulate(() => { Console.WriteLine(); });
}
void ExitingProgram()
{
    Console.WriteLine("\n[Exiting Program]");
    Environment.Exit(0);
}