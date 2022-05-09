// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

foreach (var item in GetWoche())
{
    Console.WriteLine(item.ToShortDateString());
}

IReadOnlyCollection<DateTime> GetWoche___()
{
    var tage = new List<DateTime>();
    tage.Add(DateTime.Now);
    tage.Add(DateTime.Now.AddDays(1));
    tage.Add(DateTime.Now.AddDays(2));
    tage.Add(DateTime.Now.AddDays(3));
    tage.Add(DateTime.Now.AddDays(4));
    return tage;
}


IEnumerable<DateTime> GetWoche()
{
    yield return DateTime.Now;
    yield return DateTime.Now.AddDays(1);
    yield return DateTime.Now.AddDays(2);
    yield return DateTime.Now.AddDays(3);
    yield return DateTime.Now.AddDays(4);
}