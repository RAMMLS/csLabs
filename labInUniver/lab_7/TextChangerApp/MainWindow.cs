using System;
using System.Drawing;
using System.Windows.Forms;

namespace TextChangerApp
{
    public class MainWindow : Form
    {
        private TextBox textEntry;
        private Button applyButton;
        private Label instructionLabel;
        private Label infoLabel;

        public MainWindow()
        {
            // Настройка формы
            this.Text = "Изначальный заголовок формы";
            this.Size = new Size(450, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Padding = new Padding(15);
            
            CreateUI();
            ConnectEvents();
        }
        
        private void CreateUI()
        {
            // Метка с инструкцией
            instructionLabel = new Label();
            instructionLabel.Text = "Введите текст в поле ниже и нажмите кнопку,\nчтобы изменить заголовок формы";
            instructionLabel.TextAlign = ContentAlignment.MiddleCenter;
            instructionLabel.AutoSize = true;
            instructionLabel.Location = new Point(20, 20);
            instructionLabel.Size = new Size(400, 30);
            this.Controls.Add(instructionLabel);
            
            // Текстовое поле
            textEntry = new TextBox();
            textEntry.Location = new Point(20, 60);
            textEntry.Size = new Size(400, 20);
            this.Controls.Add(textEntry);
            
            // Кнопка
            applyButton = new Button();
            applyButton.Text = "Изменить заголовок формы";
            applyButton.Location = new Point(20, 100);
            applyButton.Size = new Size(400, 30);
            this.Controls.Add(applyButton);
            
            // Информационная метка
            infoLabel = new Label();
            infoLabel.Text = "Щелкните мышью по кнопке, чтобы изменить заголовок формы на текст из редактора";
            infoLabel.TextAlign = ContentAlignment.MiddleCenter;
            infoLabel.AutoSize = false;
            infoLabel.Size = new Size(400, 40);
            infoLabel.Location = new Point(20, 150);
            this.Controls.Add(infoLabel);
        }
        
        private void ConnectEvents()
        {
            // Обработчик щелчка мыши по кнопке
            applyButton.Click += OnApplyButtonClicked;
            
            // Обработчик закрытия формы
            this.FormClosing += OnFormClosing;
        }
        
        private void OnApplyButtonClicked(object sender, EventArgs e)
        {
            string newTitle = textEntry.Text.Trim();
            
            if (string.IsNullOrEmpty(newTitle))
            {
                this.Text = "Пустой заголовок";
            }
            else
            {
                this.Text = newTitle;
            }
            
            textEntry.Text = "";
            textEntry.Focus(); // Возвращаем фокус на текстовое поле
        }
        
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
