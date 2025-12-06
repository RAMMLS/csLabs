using System;
using System.Threading;

class Say
{
    public void Answer(string name)
    {
        lock (this) // блокировка
        {
            if (name == "YES")
            {
                Console.Write("Да ");
                //Monitor.Pulse(this); // Уведомляем другой поток
                Monitor.Wait(this);  // Ожидаем уведомления
            }

            if (name == "NO")
            {
                Console.WriteLine("Нет ");
                //Monitor.Pulse(this); // Уведомляем другой поток
                Monitor.Wait(this);  // Освобождаем объект
            }
        }
    }
}

class MyThread
{
    Say say;
    public Thread thr;

    public MyThread(string nm, Say s) // Исправлено: конструктор должен называться MyThread
    {
        say = s;
        thr = new Thread(new ThreadStart(FnThr)); // создаем поток
        thr.Name = nm;
        thr.Start();
    }

    void FnThr() // Добавлен тип возвращаемого значения void
    {
        for (int j = 0; j < 10; j++) // Исправлено: fot -> for
        {
            say.Answer(thr.Name);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Say sf = new Say();
        MyThread thr1 = new MyThread("YES", sf);
        MyThread thr2 = new MyThread("NO", sf);
        
        // Ждем завершения потоков
        //thr1.thr.Join();
        //thr2.thr.Join();
        
        //Console.WriteLine("\nПрограмма завершена.");
    }
}
