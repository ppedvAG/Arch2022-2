// See https://aka.ms/new-console-template for more information
using HalloDeco;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Hello, World!");


var p = new Käse(new Salami(new Käse(new Pizza())));
Console.WriteLine($"Pizza: {p.Beschreibung} {p.Preise:c}");


var b = new Käse(new Salami(new Käse(new Brot())));
Console.WriteLine($"Brot: {b.Beschreibung} {b.Preise:c}");