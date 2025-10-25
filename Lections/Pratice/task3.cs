interface IX {
    double Fn(int a, int b);
}

interface IY {
    double Fn(int a, int b);
}

class CA : IX, IY {
    // Явная реализация интерфейса IX
    double IX.Fn(int a, int b) {
        // реализация метода
        return a + b;
    }
    
    // Явная реализация интерфейса IY
    double IY.Fn(int a, int b) {  // Было FN - исправлено на Fn
        // реализация метода
        return a * b;
    }

    public IX pIX;
    public IY pIY;

    public CA() {  // Добавлены скобки ()
        pIX = this;
        pIY = this;
    }
}

class Program {
    static void Main(string[] args) {
        CA pA = new CA();

        // Правильные способы вызова методов:
        double m = pA.pIX.Fn(5, 3);  // Передаем значения, а не объявления
        double n = pA.pIY.Fn(5, 3);  // Передаем значения, а не объявления
        
        // Или через приведение типов:
        double x = ((IX)pA).Fn(5, 3);
        double y = ((IY)pA).Fn(5, 3);
    }
}
