using System;

class Program
{
    // Объявляем класс Numbers
    class Numbers
    {
        // Приватные поля целого типа
        private int number1;
        private int number2;

        // Свойство для работы с полем number1
        public int Number1
        {
            get { return number1; }
            set { number1 = value; }
        }

        // Свойство для работы с полем number2
        public int Number2
        {
            get { return number2; }
            set { number2 = value; }
        }

        // Статическая функция для обмена значений двух параметров
        // ВОЗВРАЩАЕМ кортеж вместо использования ref
        public static (int, int) Swap(int a, int b)
        {
            // Возвращаем значения в обратном порядке
            return (b, a);
        }

        // Альтернативный метод: обмен значений полей самого объекта
        public void SwapFields()
        {
            int temp = number1;
            number1 = number2;
            number2 = temp;
        }
    }

    static void Main(string[] args)
    {
        // Создаем объект класса Numbers
        Numbers numbers = new Numbers();

        // Ввод первого числа с клавиатуры
        Console.Write("Введите первое число: ");
        numbers.Number1 = Convert.ToInt32(Console.ReadLine());

        // Ввод второго числа с клавиатуры
        Console.Write("Введите второе число: ");
        numbers.Number2 = Convert.ToInt32(Console.ReadLine());

        // Распечатываем поля объекта до обмена
        Console.WriteLine("\nДо обмена значений:");
        Console.WriteLine($"Number1 = {numbers.Number1}");
        Console.WriteLine($"Number2 = {numbers.Number2}");

        // СПОСОБ 1: Используем статический метод с возвращаемым кортежем
        (numbers.Number1, numbers.Number2) = Numbers.Swap(numbers.Number1, numbers.Number2);

        // СПОСОБ 2: Используем метод объекта для обмена его полей
        // numbers.SwapFields();

        // СПОСОБ 3: Прямой обмен через кортежи (самый простой)
        // (numbers.Number1, numbers.Number2) = (numbers.Number2, numbers.Number1);

        // Распечатываем поля объекта после обмена
        Console.WriteLine("\nПосле обмена значений:");
        Console.WriteLine($"Number1 = {numbers.Number1}");
        Console.WriteLine($"Number2 = {numbers.Number2}");

        // Ждем нажатия клавиши перед закрытием консоли
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
