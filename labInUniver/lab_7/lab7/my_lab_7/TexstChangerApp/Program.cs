using System;
using Gtk;

namespace TextChangerApp {
  class Program {
    [STAThread]
    public static void Main(string[] args) {
      Application.Init();

      //Обработчик исключений
      GLib.ExceptionManager.UnhandledException += OnUnhandledException;

      //Создание и запуск главного окна 
      var app = new Application("org.sobit.textchanger", GLib.Application Flags.None);

      app.Register(GLib.Cancellable.Current);

      var win = new MainWindow();
      app.AddWindow(win);

      win.Show();
      Application.Run();
    }

    private static void OnUnhandledException(GLib.UnhandledExceptionArgs args) {
      Console.WriteLine($"Необработанное исключение: {args.ExceptionObject}");

      Application.Quit();
    }
  }
}
