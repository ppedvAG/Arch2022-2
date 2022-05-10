using ppedv.Shopchestra.Logic;
using ppedv.Shopchestra.Model;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("*** Shopchestra v0.1 ***");

Core core = new Core();

foreach (var kunde in core.Repository.GetAll<Kunde>())
{
    Console.WriteLine($"{kunde.Name}");
    foreach (var b in kunde.Bestellungen)
    {
        Console.WriteLine($"\t{b.Bestelldatum}");
        foreach (var pos in b.Positionen)
        {
            Console.WriteLine($"\t\t{pos.Menge}x {pos.Einzelpreis:c} {pos.Produkt.Bezeichnung}");
        }
    }
}

Console.WriteLine($"VIP: {core.GetVIPCustomer().Name}");

