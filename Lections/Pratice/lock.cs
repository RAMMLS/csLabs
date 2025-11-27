using System;
using System.Threading;

class CA
{
    private int[] mas = new int[10];
    private readonly object lockObject = new object(); // Объект для блокировки

    public CA()
    {
        for (int i = 0; i < mas.Length; i++)
        {
            mas[i] = i;
        }
    }

    public void PrintMas()
    {
        lock (lockObject) // Блокировка доступа к критической секции
        {
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine("Name= {0} mas[{1}]={2}",
                    Thread.CurrentThread.Name, i, mas[i]);
                Thread.Sleep(10);
            }
        }
    }
}

internal class Program
{
    class Thr
    {
        private Thread pth;
        private CA pCA;

        private void FnTh()
        {
            for (int j = 0; j <= 3; j++)
            {
                pCA.PrintMas();
            }
        }

        public Thr(string name, CA p)
        {
            pCA = p;
            pth = new Thread(FnTh);
            pth.Name = name;
            pth.Start();
        }
    }

    static void Main()
    {
        CA ca = new CA();
        Thr Thr1 = new Thr("#1", ca);
        Thr Thr2 = new Thr("#2", ca);
        
        // Ожидание завершения потоков (опционально)
        Thread.Sleep(1000);
    }
}


