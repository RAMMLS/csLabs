using System;

class CA {
	private int x = 10;
	public void PrintA() {
		Console.WriteLine(x);
	}
}

class CB : CA {
	public void PrintB() {
		//Console.WriteLine(x);
	}
}

class Program {
	static void Main(string[] args) {
		CA pA = new CA(); //pA — название объекта
		pA.PrintA();//10
		CB pB = new CB(); //pb — название объекта
		pB.PrintA();
	}
}
