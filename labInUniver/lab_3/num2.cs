using System;

public class NumberObject {
  private static int _counter = 0;
  public readonly int Number;

  public NumberObject() {
    Number = ++_counter;
  }
}

class Program {
  static void Main() {
    for (int i =0; i < 10; i++) {
      var obj = new NumberObject();
      Console.WriteLine($"Создан объект под номером: {obj.Number}");
    }
  }
}
