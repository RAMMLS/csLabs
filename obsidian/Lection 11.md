## Потоки

**Если один пользователь печатает, другой не должен**

Мы должны заблокировать доступ к принтеру 

Достигается это за счет 
Синхронизации потоков - обеспечение корректной работы нескольких потоков с одним общим разделяемым ресурсом
```cs
lock (obj) { // для синхронизации потоков
	///
	///
	///
}
```
Называется оператор, а по виду - запись функции

Этот код будет выполнен без доступа со стороны других потоков

Объект А должен быть **ссылочного типа**
A|	B |	  C|    
|	  |	   |
| {...|....|lock (m) {}
|	  |    |
| }...|....|
|	  |	   |
|	  |	   |

**Структура это не ссылочный тип, а тип по значению**
```cs

lock (A) {
	//
}
lock (B) {
	//
}
```

Поток B засыпает пока поток A не освободит вывод.

Объект **m с помощью которого достигается синхронизация** должен быть единственным


"Ключ должен быть один"


Попросил добавить lock () 
```cs
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


```


------------
## Как передавать параметры

**Классический делегат**

```cs
delegate int Oper (int a);
static void Main(string[] args) {
	int x = 25;
	int y = 5;
	int Add(int a) {
		return a+x+y;
	}
	Oper op = new Oper(Add);
	Console.WriteLine(op(11));
}
```

## Анонимные методы

```cs
delegate (parameters) {
	// instructions
}
```

Анонимной называется потому что нет имени функции (гениально)

```cs
delegate int Oper(int a);
static void Main(string[] args) {
	int x = 25;
	int y = 5;
Oper op1 = delegate (int a) {
	return a+x+y;
};
Console.WriteLine(op1(12));
}
```

## Лямбда-выражения

Лямбда-выражения представляют упрощенную запись анонимных методов:

```cs
delegate int Oper(int a);
static void Main(string[] args) {
	int x =25;
	int y = 5;
	
	Oper sum = (int m) => { return x+y+m; };
	Console.WriteLine(sum(13));
}
```

```cs
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
```

## Приоритеты потоков

Каждый поток имеет определенный приоритет. Потоки с более высоким приоритетом имеют преимущество перед другими потоками и могут полностью блокировать работу потоков с более низкими приоритетами.

Приоритет потока можно прочитать или изменить с помощью **Prioruty**, которое является членом класса **Thread**

```cs
ThreadPriority.Higest // высокий
ThreadPriority.AboveNormal // выше нормального
ThreadPriority.Normal // нормальный
ThreadPriority.BelowNormal // ниже нормального 
ThreadPriority.Lowest // низкий
```


Каждый процесс (не поток) имеет некоторый приоритет. Приоритет процесса, запустившего потоки, считается базовым для потоков и принимается за нормальный
```cs
thr1.Priority = ThreadPriority.AboveNormal
thr2.Priority = ThreadPriority.BelowNormal
```