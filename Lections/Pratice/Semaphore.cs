using System;
using System.Threading;

namespace Sem {
	class Reader {
		// Создаем семафор
		static Semaphore sem = new Semaphore(3,3);
		Thread myThread;
		int count = 3; // максимальное кол-во посещений
	}
}
