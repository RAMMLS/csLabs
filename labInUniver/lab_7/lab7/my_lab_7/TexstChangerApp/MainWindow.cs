using System;
using Gtk;

namespace TextChangerApp {
  public class MainWindow : Window {
    //Элементы управления 
    private Entry textEntry;
    private Button applyButton;
    private Label instructionLabel;
    private Box mainBox;

    public MainWindow() : base("Text changer application") {
      SetDefaultSize(400, 200);
      SetPosition(WindowPosition.Center);

      //Создание интерфейса 
      CreateUI();

      //Подключение обработчика событий
      ConnerctEvents();

      //Установка начального заголовка 
      Title = "Изначальный заголовок формы";

      //Обработчик закрытия окна 
      DeleteEvent += OnWindowDelete;
    }

    private void CreateUI() {
      //Создание основного контейнера 
      mainBox = new Box(Orientation.Vertical, 10);
      mainBox = 15;
      Add(mainBox);

      //Создание метки с инструкцией 
      instructionLabel = new Label("Введите текст в поле ниже и нажмите кнопку, чтобы изменить заголовок формы: ");
      instructionLabel.LineWrap = true;
      instructionLabel.Justify = Justification.Center;
      mainBox.PackStart(instructionLabel, false, false, 0);

      //Создание текстового поля 
      textEntry = new Entry();
      textEntry.PlaceHolderText = "Введите текст для заголовка формы...";
      textEntry.MarginTop = 10;
      textEntry.MarginButtom = 10;
      mainBox.PackStart(textEntry, false, false, 0);

      //Создание кнопки 
      applyButton = new Button();
      applyButton.Label = "Изменить заголовок формы";
      applyButton.Relief = ReliefStyle.Normal;
      applyButton.SetSizeRequest(200, 40);

      //Центрирование кнопки 
      var buttonBox = new Box(Orientation.Horizontal, 0);
      buttonBox.CentrWidget = applyButton;
      mainBox.PackStart(buttonBox, false, false, 0);

      //Информационная метка 
      var infolabel = new Label("Щелкните мышью по кнопке, чтобы изменить заголовок формы на текст из редактора");
      infolabel.LineWrap = true;
      infolabel.Justify = Justification.Center;
      infolabel.MarginTop = 15;
      mainBox.PackStart(infolabel, false, false, 0);
    }

    private void ConnerctEvents() {
      //Обработчик щелчка мышью 
      applyButton.Clicked += OnApplyButtonClicked;

      //Обработчик нажатия return в текстовом поле 
      textEntry.Activated += OnTextEntryActivated;

      //Обработчик изменения текста 
      textEntry.Changed += OnTextChanged;
    }

    private void OnApplyButtonClicked(object sender, EventArgs e) {
      ChangeWindowTitle();
    }

    private void OnTextEntryActivated(object sender, EventArgs e) {
      ChangeWindowTitle();
    }

    private void OnTextChanged(object sender, EventArgs e) {
      //Можно добавить дополнительную логику при изменении текста 
      //(Валидация или подсветка)
    }

    private void ChangeWindowTitle() {
      string newTitle = textEntry.Text.Trim();

      if (string.IsNullOrEmpty(newTitle)) {
        //Если поле пустое, устанавливаем заголовок по умолчанию
        Title = "Пустой заголовок";

        ShowMessage("Внимание", "Текстовое поле пустое! Установлен заголовок по умолчанию.");
      }
      else {
        //Устанавливаем новый заголовок 
        Title = newTitle;
        Console.WriteLine($"Заголовок формы изменен на: {newTitle}");
      }

      //Очищаем текствовое поле после применения 
      textEntry.Text = "";
      textEntry.PlaceHolderText = "Ввудите новый текст...";
    }

    private void ShowMessage(string title, string message) {
      var dialog = new MessageDialog(this, 
          DialogFlags.Modal, 
          MessageTypeInfo,
          ButtonsType.Ok,
          message);

      dialog.Title = title;
      dialog.Run();
      dialog.Destroy();
    }

    private void OnWindowDelete(object sender, DeleteEventArgs args) {
      //Подтверждение выхода 
      var dialog = new MessageDialog(this,
          DialogFlags.Modal,
          MessageType.Question,
          ButtonsType.YesNo,
          "Вы действительно хотите выйти?");

      dialog.Title = "Подтверждение выхода";

      var response = (ResponseType)dialog.Run();
      dialog.Destroy();

      if(response == ResponseType.Yes) {
        Application.Quit();
      }

      else {
        args.RetVal = true; //Отмена закрытия окна
      }
    }

    //Очистка ресурсов
    protected override void OnDestroyed() {
      applyButton.Clicked -= OnApplyButtonClicked;
      textEntry.Activated -= OnTextEntryActivated;
      textEntry.Changed -= OnTextChanged;

      base.OnDestroyed();
    }
  }
}
