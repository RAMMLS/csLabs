using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab9_Task3
{
    public class Form1 : Form
    {
        private int width = 50;
        private int height = 50;
        private Color myColor = Color.Red;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Настройка формы
            this.Text = "Лабораторная работа №3 - Меню с горячими клавишами";
            this.BackColor = Color.White;
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            CreateMainMenu();
            CreateContextMenu();
        }

        private void CreateMainMenu()
        {
            // Создание главного меню
            MainMenu mainMenu = new MainMenu();
            
            // Пункт меню "Размер" с подменю
            MenuItem sizeMenu = new MenuItem("&Размер");
            
            // Создание пунктов подменю с горячими клавишами
            MenuItem bigItem = new MenuItem("&Большой", (s, e) => SetSize(150, 150, "Большой"));
            MenuItem mediumItem = new MenuItem("&Средний", (s, e) => SetSize(100, 100, "Средний")); 
            MenuItem smallItem = new MenuItem("&Маленький", (s, e) => SetSize(50, 50, "Маленький"));

            // Установка горячих клавиш
            bigItem.Shortcut = Shortcut.CtrlB;
            mediumItem.Shortcut = Shortcut.CtrlM;
            smallItem.Shortcut = Shortcut.CtrlS;

            // Включение отображения горячих клавиш
            bigItem.ShowShortcut = true;
            mediumItem.ShowShortcut = true;
            smallItem.ShowShortcut = true;

            // Добавление пунктов в меню
            sizeMenu.MenuItems.Add(bigItem);
            sizeMenu.MenuItems.Add(mediumItem);
            sizeMenu.MenuItems.Add(smallItem);
            
            // Добавление разделителя
            sizeMenu.MenuItems.Add(new MenuItem("-"));
            
            // Пункт выхода
            MenuItem exitItem = new MenuItem("&Выход", (s, e) => Application.Exit());
            exitItem.Shortcut = Shortcut.CtrlQ;
            exitItem.ShowShortcut = true;
            sizeMenu.MenuItems.Add(exitItem);

            mainMenu.MenuItems.Add(sizeMenu);
            this.Menu = mainMenu;
        }

        private void CreateContextMenu()
        {
            // Создание контекстного меню
            ContextMenu contextMenu = new ContextMenu();
            
            MenuItem redItem = new MenuItem("&Красный", (s, e) => SetColor(Color.Red));
            MenuItem blueItem = new MenuItem("&Синий", (s, e) => SetColor(Color.Blue));
            MenuItem greenItem = new MenuItem("&Зеленый", (s, e) => SetColor(Color.Green));

            // Установка горячих клавиш
            redItem.Shortcut = Shortcut.CtrlR;
            blueItem.Shortcut = Shortcut.CtrlL;
            greenItem.Shortcut = Shortcut.CtrlG;

            // Включение отображения горячих клавиш
            redItem.ShowShortcut = true;
            blueItem.ShowShortcut = true;
            greenItem.ShowShortcut = true;

            contextMenu.MenuItems.Add(redItem);
            contextMenu.MenuItems.Add(blueItem);
            contextMenu.MenuItems.Add(greenItem);

            this.ContextMenu = contextMenu;
            
            // Обработчик правой кнопки мыши
            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    contextMenu.Show(this, new Point(e.X, e.Y));
                }
            };
        }

        private void SetSize(int w, int h, string sizeName)
        {
            width = w;
            height = h;
            this.Text = $"Лабораторная работа №3 - {sizeName} прямоугольник";
            Invalidate();
        }

        private void SetColor(Color color)
        {
            myColor = color;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics dc = e.Graphics;
            
            // Очистка фона
            dc.Clear(this.BackColor);
            
            // Рисование прямоугольника
            using (Pen pen = new Pen(myColor, 3))
            {
                dc.DrawRectangle(pen, 50, 50, width, height);
            }
            
            // Отображение информации
            using (Font font = new Font("Arial", 10))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                string info = $"Размер: {width}x{height} | Цвет: {myColor.Name}";
                dc.DrawString(info, font, brush, 50, 20);
                
                string help = "Горячие клавиши:\n" +
                             "Размер: Ctrl+B, Ctrl+M, Ctrl+S\n" +
                             "Цвет: Ctrl+R, Ctrl+L, Ctrl+G\n" +
                             "Выход: Ctrl+Q\n" +
                             "Правый клик - контекстное меню";
                dc.DrawString(help, font, brush, 50, height + 70);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }
    }
}
