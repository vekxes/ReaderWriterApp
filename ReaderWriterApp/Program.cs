// See https://aka.ms/new-console-template for more information
using ReaderWriterApp;
using System.ComponentModel;

class WriteReadApp
{    
    static Random _rand = new Random();

    static void Main()
    {
        new Thread(Write).Start("A");
        new Thread(Read).Start("Reader AAA");
        new Thread(Read).Start("Reader BBB");
        new Thread(Read).Start("Reader CCC");        
        new Thread(Write).Start("B");
    }

    static void Read(object threadID)
    {
        while (true)
        {
            Console.WriteLine("Поток " + threadID + " прочитал " + Server.GetCount());
            Thread.Sleep(200);
        }
    }

    static void Write(object threadID)
    {
        while (true)
        {
            int newNumber = GetRandNum(100);
            Server.AddToCount(newNumber);
            Console.WriteLine("Поток " + threadID + " добавил " + newNumber);
            Thread.Sleep(1000);
        }
    }

    static int GetRandNum(int max) { lock (_rand) return _rand.Next(max); }
}

