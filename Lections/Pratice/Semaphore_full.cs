using System;
using System.Threading;

namespace Sem {
	class Reader {
		// Создаем семафор
		static Semaphore sem = new Semaphore(3,3);
		Thread myThread;
		int count = 3; // максимальное кол-во посещений
		
		public void Read() {
			while (count > 0) {
			
				sem.WaitOne();
				Console.WriteLine($"{Thread.CurrentThread.Name} Входит в библиотеку");
				Console.WriteLine($"{Thread.CurrentThread.Name} Читает");
				Thread.Sleep(1000);
				
				Console.WriteLine($"{Thread.CurrentThread.Name} Покидает библиотеку");
				sem.Release(); // освобождаем место
				count--;
				Thread.Sleep(1000);
			}
		}
		
		public Reader (int i) {
			myThread = new Thread(Read);
			myThread.Name = $"Читатель {i}";
			myThread.Start();
		}
	}
	
	class Program {
		static void Main(string[] args) {
			for (int i = 0; i < 6; i++) {
				Reader reader = new Reader(i);
			}
		}
	}
}
