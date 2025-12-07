using System;
using System.Drawing;
using System.Windows.Forms;

namespace TransparentFormApp
{
    public class TransparentForm : Form
    {
        private Button clickButton;
        
        public TransparentForm()
        {
            InitializeForm();
            InitializeButton();
        }
        
        private void InitializeForm()
        {
            // Настройки формы
            this.Text = "Прозрачная форма";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            
            // Начальная прозрачность (1.0 = полностью непрозрачная)
            this.Opacity = 1.0;
            this.BackColor = Color.LightBlue;
        }
        
        private void InitializeButton()
        {
            // Создание кнопки
            clickButton = new Button();
            clickButton.Text = "Нажми меня!\nПрозрачность: 100%";
            clickButton.Size = new Size(150, 80);
            clickButton.Location = new Point(
                (this.ClientSize.Width - clickButton.Width) / 2,
                (this.ClientSize.Height - clickButton.Height) / 2
            );
            clickButton.Anchor = AnchorStyles.None;
            clickButton.Font = new Font("Arial", 10, FontStyle.Bold);
            clickButton.BackColor = Color.White;
            clickButton.ForeColor = Color.DarkBlue;
            clickButton.FlatStyle = FlatStyle.Flat;
            clickButton.FlatAppearance.BorderColor = Color.DarkBlue;
            clickButton.FlatAppearance.BorderSize = 2;
            
            // Обработчик события щелчка мыши
            clickButton.Click += OnButtonClick;
            clickButton.MouseClick += OnButtonMouseClick;
            
            // Добавление кнопки на форму
            this.Controls.Add(clickButton);
            
            // Обновляем текст при изменении размера формы
            this.SizeChanged += (s, e) => {
                clickButton.Location = new Point(
                    (this.ClientSize.Width - clickButton.Width) / 2,
                    (this.ClientSize.Height - clickButton.Height) / 2
                );
            };
        }
        
        private void OnButtonClick(object sender, EventArgs e)
        {
            UpdateTransparency();
        }
        
        private void OnButtonMouseClick(object sender, MouseEventArgs e)
        {
            // Обработка именно щелчка мыши
            if (e.Button == MouseButtons.Left)
            {
                UpdateTransparency();
            }
        }
        
        private void UpdateTransparency()
        {
            try
            {
                // Увеличиваем прозрачность в 2 раза (делим Opacity на 2)
                double newOpacity = this.Opacity / 2.0;
                
                // Не даем прозрачности упасть ниже минимального значения
                if (newOpacity < 0.05)
                {
                    newOpacity = 1.0; // Возвращаем к полной непрозрачности
                    MessageBox.Show("Достигнута максимальная прозрачность!\nВозврат к 100%.",
                                  "Информация",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                
                // Применяем новую прозрачность
                this.Opacity = newOpacity;
                
                // Обновляем текст кнопки
                int transparencyPercent = (int)(newOpacity * 100);
                clickButton.Text = $"Нажми меня!\nПрозрачность: {transparencyPercent}%";
                
                // Меняем цвет кнопки в зависимости от прозрачности
                UpdateButtonColor(newOpacity);
                
                Console.WriteLine($"Прозрачность изменена: {newOpacity:F2} ({transparencyPercent}%)");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void UpdateButtonColor(double opacity)
        {
            // Меняем цвет кнопки в зависимости от прозрачности
            int redValue = (int)(255 * (1 - opacity));
            int greenValue = (int)(255 * opacity);
            int blueValue = 200;
            
            clickButton.BackColor = Color.FromArgb(redValue, greenValue, blueValue);
            clickButton.ForeColor = opacity > 0.5 ? Color.DarkBlue : Color.White;
        }
        
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TransparentForm());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка запуска приложения: {ex.Message}");
                Environment.Exit(1);
            }
        }
    }
}
