using System;
using System.Threading;

namespace LambdaThread
{
    class Program
    {
        static string str = "Hello";
        static string str1 = "Hola";
        static readonly object lockObject = new object(); // Для синхронизации вывода

        static void PrintMessage(string str)
        {
            lock (lockObject) // Блокировка для предотвращения перемешивания вывода
            {
                Console.WriteLine(str);
            }
        }

        static void Display()
        {
            PrintMessage(str1); // потоковая функция
        }

        delegate void Tpdl();

        static void Main(string[] args)
        {
            //ThreadStart pt = new ThreadStart(Display);
            //Thread pTh1 = new Thread(pt);
            Thread pTh1 = new Thread(Display); // короткая запись
            pTh1.Start();

            // использование анонимного метода 
            string strAn = str + str1;
            Tpdl pdl = delegate () { PrintMessage(strAn); };
            Thread ptH2 = new Thread(new ThreadStart(pdl));
            ptH2.Start();

            // использование анонимного метода для передачи параметров
            Thread ptH3 = new Thread(delegate () { PrintMessage(strAn); });
            ptH3.Start();

            // Использование лямбда для передачи параметров потоку 
            Thread thread = new Thread(() => PrintMessage("Lambda"));
            thread.Start();

            // Ожидание завершения потоков
            pTh1.Join();
            ptH2.Join();
            ptH3.Join();
            thread.Join();
        }
    }
}
