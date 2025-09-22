using System;

class IntArray
{
    private int[] array; // Приватное поле для хранения массива

    public IntArray()
    {
        array = new int[10]; // Инициализация массива размером 10
    }

    // Индексатор для доступа к элементам массива
    public int this[int index]
    {
        get
        {
            // Проверка корректности индекса
            if (index < 0 || index >= array.Length)
                throw new IndexOutOfRangeException("Индекс выходит за границы массива");
            return array[index];
        }
        set
        {
            if (index < 0 || index >= array.Length)
                throw new IndexOutOfRangeException("Индекс выходит за границы массива");
            array[index] = value;
        }
    }

    // Свойство для получения длины массива
    public int Length => array.Length;
}

class Program
{
    static void Main()
    {
        IntArray arr = new IntArray(); // Создание объекта класса IntArray

        // Ввод элементов массива с клавиатуры
        Console.WriteLine("Введите 10 целых чисел:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"Элемент {i}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        // Вычисление среднего арифметического
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        double average = sum / arr.Length;

        // Поиск ближайшего элемента к среднему арифметическому
        double minDifference = double.MaxValue; // Минимальная разница
        int closestValue = arr[0]; // Ближайшее значение
        int closestIndex = 0;      // Индекс ближайшего значения

        for (int i = 0; i < arr.Length; i++)
        {
            // Вычисление абсолютной разницы между текущим элементом и средним
            double difference = Math.Abs(arr[i] - average);
            
            // Если найдена меньшая разница, обновляем результаты
            if (difference < minDifference)
            {
                minDifference = difference;
                closestValue = arr[i];
                closestIndex = i;
            }
        }

        // Вывод результата
        Console.WriteLine($"\nСреднее арифметическое: {average:F2}");
        Console.WriteLine($"Ближайший элемент: {closestValue}");
        Console.WriteLine($"Индекс элемента: {closestIndex}");
    }
}
