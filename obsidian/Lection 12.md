## Синхронизация потоков

Обеспечивает корректную работу нескольких потоков.

```cs
lock (object ob) {
	// инструкции
}
```

ob - объект, с помощью которого осуществляется синхронизация

```cs
lock () {} //разворачивается транслятором в monitor.<operands>

monitor.Enter(object ob);
//
//
//
monitor.Exit(object ob);
```

monitor - класс, предназначенный для синхронизации работы потоков.

В классе monitor определено несколько статических методов для организации синхронизации. Для блокировки некоторого объекта, необходимо вызвать метод Enter(), а чтобы снять блокировку - метод Exit().

**Эти методы образуют следующий формат**

```cs
public static void Enter(object syncOb)
public static void Exit(object syncOb)
```

В классе Monitor определены еще три метода: 
```cs
Wait()
Pulse()
PulseAll()
```

Они могут быть вызваны только внутри lock-блока кода. Имеется два наиболее употребимых формата метода wait():

```cs
public static bool Wait(object waitOb)
public static bool Wait(object waitOb, int milliseconds)
```

Здесь параметр waitOb означает объект, освобождаемый от блокировки.

Вызов метода Pulse() возобновляет выполнение потока, стоящего первым в очереди потоков, пребывающих в режиме ожидания. Вызов метода PulseAll() сообщает о возобновлении выполнения всех ожидающих потоков. 

Форматы использования методов Pulse() && PulseAll(): 

```cs
public static void Pulse(object waitOb)
public static void PulseAll(object waitOb)
```

Если не вызвать один из этих двух методов - поток заснет навечно.

Если метод Wait(), Pulse(), PulseAll() вызывается из кода, который находится в lock-блоке, генерируется исключение типа:

```cs
SynchronizationLockException
```

Задача: Имеется объект класса Say в этом классе объявлена функция, которая принимает строку символов. Если она принимает YES - печатает да, если NO печатает нет. Создается один объект данного класса и к нему обращается два потока, один поток имеет имя YES второй имеет имя NO

```cs
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
                Monitor.Pulse(this); // Уведомляем другой поток
                Monitor.Wait(this);  // Ожидаем уведомления
            }

            if (name == "NO")
            {
                Console.Write("Нет ");
                Monitor.Pulse(this); // Уведомляем другой поток
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
        thr1.thr.Join();
        thr2.thr.Join();
        
        Console.WriteLine("\nПрограмма завершена.");
    }
}
```

### Класс Interlocket 

```cs
public class CountRef {
	private long refCount = 0;
	public void AddRef() {
		Interlocked.Increment(ref refCount);
	}
	
	public void Release() {
		Interlocked.Decrement(ref refCount);
	}
	//
	//
	//
}
```

