using System;

public class TrigonometryTable
{
    public static void Main(string[] args)
    {
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("|   Угол (°) |   Угол (рад) |    Sin(x) |    Cos(x) |");
        Console.WriteLine("---------------------------------------------------");

        for (int degrees = 0; degrees <= 180; degrees += 10)
        {
            // Преобразование градусов в радианы
            double radians = Math.PI * degrees / 180.0;

            // Вычисление синуса и косинуса
            double sinValue = Math.Sin(radians);
            double cosValue = Math.Cos(radians);

            // Форматирование вывода для выравнивания по правому краю
            Console.WriteLine($"| {degrees,10:D} | {radians,10:F4} | {sinValue,9:F4} | {cosValue,9:F4} |");
        }

        Console.WriteLine("---------------------------------------------------");
    }
}


