using System;

public class FunctionTable
{
    public static void Main(string[] args)
    {
        Console.WriteLine("#####################################");
        Console.WriteLine("|  Угол |  Радианы |      F(x)      |");
        Console.WriteLine("#####################################");

        for (int angleDegrees = 0; angleDegrees <= 180; angleDegrees += 10)
        {
            //Преобразование в радианы
            double angleRadians = angleDegrees * Math.PI / 180.0; 
            double functionValue = Math.Sin(angleRadians) + Math.Cos(angleRadians);


            //Выводим значения с форматированием
            Console.WriteLine($"| {angleDegrees,4} | {angleRadians,5:F2} | {functionValue,12:F4} |");
        }

        Console.WriteLine("######################################");
    }
}


