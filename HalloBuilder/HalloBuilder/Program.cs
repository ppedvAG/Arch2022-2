// See https://aka.ms/new-console-template for more information
using HalloBuilder;

Console.WriteLine("Hello, World!");


Schrank schrank = new Schrank.SchrankBuilder()
                         .SetBöden(3)
                         .SetTüren(6)
                         .Create();