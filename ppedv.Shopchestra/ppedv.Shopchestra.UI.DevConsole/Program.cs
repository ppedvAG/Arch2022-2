using Autofac;
using ppedv.Shopchestra.Data.EfCore;
using ppedv.Shopchestra.Logic;
using ppedv.Shopchestra.Model;
using ppedv.Shopchestra.Model.Contracts;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("*** Shopchestra v0.1 ***");

//DI per hand mit Referenz
//Core core = new Core(new EfRepository());

//DI per Reflection + EfCore als Nuget-Pack
//var filePath = @"C:\Users\Fred\source\repos\Arch2022-2\ppedv.Shopchestra\ppedv.Shopchestra.Data.EfCore\bin\Debug\net6.0\ppedv.Shopchestra.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(filePath);
//Type typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//var repo = Activator.CreateInstance(typeMitRepo);
//Core core = new Core(repo as IRepository);

//DI per AutoFac
var builder = new ContainerBuilder();
//builder.RegisterType<EfRepository>().As<IRepository>();
builder.RegisterType<EfRepository>().AsImplementedInterfaces();
//builder.RegisterType<XMLRepository>().AsImplementedInterfaces();
//...
var cont = builder.Build();

var core = new Core(cont.Resolve<IRepository>());

foreach (var kunde in core.Repository.GetAll<Kunde>())
{
    Console.WriteLine($"{kunde.Name}");
    foreach (var b in kunde.Bestellungen)
    {
        Console.WriteLine($"\t{b.Bestelldatum} [{core.CalcBestellSumme(b):c}]");
        foreach (var pos in b.Positionen)
        {
            Console.WriteLine($"\t\t{pos.Menge}x {pos.Einzelpreis:c} {pos.Produkt.Bezeichnung}");
        }
    }
}

Console.WriteLine($"VIP: {core.GetVIPCustomer().Name}");

