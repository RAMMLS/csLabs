using System;
using System.Collections.Generic;

public abstract class State
{
    public string Name { get; set; }  

    public State(string name)
    {
        Name = name;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Государство");
    }
}

//Республика 
public class Republic : State
{
    public string President { get; set; }

    public Republic(string name, string  president) : base(name)
    {
        President = president;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Республика: {Name}");
        Console.WriteLine($"Президент: {President}");
    }
}

//Монархия
public class Monarchy : State
{
    public string Monarch { get; set; }

    public Monarchy(string name, string monarch) : base(name)
    {
        Monarch = monarch;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Монархия: {Name}");
        Console.WriteLine($"Монарх: {Monarch}");
    }
}

//Королевство наследуем от монархии 
public class Kingdom : Monarchy
{
    public string KigdomTitle { get; set; }

    public Kingdom(string name, string monarch, string title) : base (name, monarch)
    {
        KigdomTitle = title;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Королевство: {Name}");
        Console.WriteLine($"Титул монарха: {KigdomTitle}");
        Console.WriteLine($"Правящий монарх: {Monarch}");
    }
}

class Proram
{
    static void Main(string[] args)
    {
        List<State> states = new List<State>
        {
            new Republic ("Франция", "Эммануэль Макрон"),
            new Monarchy ("Япония", "Нарухито"),
            new Kingdom ("испания", "Филипп 6", "Король")
        };

        foreach (var state in states)
        {
            state.DisplayInfo();
            Console.WriteLine(new string('-', 30));
        }
    }
}
