namespace Shop.Web;

public static class Lang
{
    private static string current = "pl";

    private static readonly Dictionary<string, string> Pl = new()
    {
        { "Home", "Home" },
        { "Products", "Produkty" },
        { "ShopLead", "Prosty sklep zbudowany w Blazor i .NET API." },
        { "ProductsCardText", "Dodawaj, zmieniaj i usuwaj produkty w katalogu." },
        { "Open", "Otwórz" },
        { "Orders", "Zamówienia" },
         { "OrdersCardText", "Wkrótce - lista złożonych zamówień." },
        { "Name", "Nazwa" },
        { "Quantity", "Ilość" },
        { "Price", "Cena" },
        { "Actions", "Akcje" },
        { "Add", "Dodaj" },
        { "Save", "Zapisz" },
        { "Cancel", "Anuluj" },
        { "Delete", "Usuń" },
        { "Edit", "Zmień" },
        { "Loading", "Ładowanie..." }
    };

    private static readonly Dictionary<string, string> En = new()
    {
        { "Home", "Home" },
        { "Products", "Products" },
        { "ShopLead", "Simple store built with Blazor and a .NET API." },
        { "ProductsCardText", "Add, edit and remove products in the catalogue." },
        { "Open", "Open" },
        { "Orders", "Orders" },
        { "OrdersCardText", "Coming soon - list of placed orders." },
        { "Name", "Name" },
        { "Quantity", "Quantity" },
        { "Price", "Price" },
        { "Actions", "Actions" },
        { "Add", "Add" },
        { "Save", "Save" },
        { "Cancel", "Cancel" },
        { "Delete", "Delete" },
        { "Edit", "Edit" },
        { "Loading", "Loading..." }
    };

    public static string T(string key)
    {
        return current == "en" ? En[key] : Pl[key];
    }

    public static void Set(string lang)
    {
        current = lang;
    }
}