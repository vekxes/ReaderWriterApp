// See https://aka.ms/new-console-template for more information
using ReaderWriterApp;

Parallel.For(0, 100, i =>
{
    if (i % 2 == 0)
        Server.AddToCount(2);
    else
        Console.WriteLine(Server.GetCount());
});
Console.WriteLine("Stop");

Console.WriteLine(Server.GetCount());

Console.ReadKey();