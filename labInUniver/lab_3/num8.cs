using System;

public class ArrayProcessor {
  private int[] _internalArray;
  public readonly int MinValue;
  public readonly int MaxValue;

  //Конструктор принимающий ссылку на внешний массив 
  public ArrayProcessor(int[] externalArray) {
    if (externalArray == null || externalArray.Length == 0) {
      throw new ArgumentException("Массив не может быть null или пустым");
    }

    //Выделяем память под внутренний массив
    _internalArray = new int[externalArray.Length];

    //Копируем значения из внешнего массив
    Array.Copy(externalArray, _internalArray, externalArray.Length);

    //Сортируем внутренний массив по возрастанию 
    Array.Sort(_internalArray);

    //Определяем мин/мах значения 
    MinValue = _internalArray[0];
    MaxValue = _internalArray[_internalArray.Length - 1];
  }

  //Функция для печати элементов массив
  public void PrintArray() {
    Console.WriteLine("Эллементы массива: ");
    foreach (var element in _internalArray) {
      Console.WriteLine(element + " ");
    }
    Console.WriteLine();
  }
}

class Program {
  static void Main() {
    try {
      Console.WriteLine("Введите элементы массива через пробел: ");
      string input = Console.ReadLine();

      //Преобразуем введенную строку в массив целых чисел 
      string[] inputArray = input.Split(' ');
      int[] externalArray = new int[inputArray.Length];

      for (int i = 0; i < inputArray.Length; i++) {
        externalArray[i] = int.Parse(inputArray[i]);
      }

      //Создаем объект класса ArrayProcessor
      ArrayProcessor processor = new ArrayProcessor(externalArray);

      //Вывод
      processor.PrintArray();
      Console.WriteLine($"Минимальное значение: {processor.MinValue}");
      Console.WriteLine($"Максимальное значение: {processor.MaxValue}");
    }
    catch (Exception ex) {
      Console.WriteLine($"Ошибка: {ex.Message}");
    }
  }
}
