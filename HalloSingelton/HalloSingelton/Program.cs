using HalloSingelton;

Console.WriteLine("Hello, World!");


Parallel.For(0, 100, i =>
{
    Logger.Instance.Log($"Hallo logger {i}");
});
