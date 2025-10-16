using System;

class CA {
    public virtual void Display() {
        Console.WriteLine("CA");
    }
}

// CB must inherit from CA to override its method
class CB : CA {
    public override void Display() {
        Console.WriteLine("CB");
    }
}

class Program {
    static void ShowDisplay(CA m) {
        m.Display();
    }

    static void Main(string[] args) {
        CA pA = new CA();
        CB pB = new CB();

        pA.Display();           // Output: CA
        ShowDisplay(pA);        // Output: CA

        pB.Display();           // Output: CB
        ShowDisplay(pB);        // Output: CB
        
        pA = pB;

        pA.Display();          // Output: CB 
        ShowDisplay(pA);       // Output: CB
        pB.Display();          // Output: CB
        ShowDisplay(pB);       // Output: CB
    }
}
