using System;
using System.Threading;

class Say
{
    private readonly object _lock = new object();
    
    public void SaySomething(string word)
    {
        lock (_lock) // Блокировка потока
        {
            if (word == "YES")
            {
                Console.WriteLine("Да");
            }
            else if (word == "NO")
            {
                Console.WriteLine("Нет");
            }
            else
            {
                Console.WriteLine("Неизвестная команда");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Say say = new Say();
        
        // Создаем и запускаем поток YES
        Thread yesThread = new Thread(() =>
        {
            Thread.CurrentThread.Name = "YES";
            say.SaySomething("YES");
        });
        
        // Создаем и запускаем поток NO
        Thread noThread = new Thread(() =>
        {
            Thread.CurrentThread.Name = "NO";
            say.SaySomething("NO");
        });
        
        yesThread.Start();
        noThread.Start();
        
        // Ждем завершения потоков
        yesThread.Join();
        noThread.Join();
    }
}
