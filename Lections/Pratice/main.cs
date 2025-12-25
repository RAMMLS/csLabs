using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Menu1
{
    public class Form1 : Form
    {
        // Объявление ссылок
        MainMenu MnMen1; 
        MenuItem pnkt1;
        MenuItem pnkt1_1; 
        MenuItem pnkt1_2; 
        MenuItem pnkt2;
        MenuItem pnkt2_1; 
        MenuItem pnkt2_2; 

        public Form1() 
        {
            // Убрали InitializeComponent(), так как всё создаем вручную ниже
            this.Text = "МЕНЮ";

            // Создаем первый пункт меню верхнего уровня
            pnkt1_1 = new MenuItem("Подпункт 1_1", new EventHandler(Msg1_1), Shortcut.Alt1);
            pnkt1_2 = new MenuItem("Подпункт 1_2", new EventHandler(Msg1_2), Shortcut.Alt2);
            pnkt1 = new MenuItem("Пункт 1", new MenuItem[] { pnkt1_1, pnkt1_2 });

            // Создаем второй пункт меню верхнего уровня
            pnkt2_1 = new MenuItem("Подпункт 2_1", new EventHandler(Msg2_1));
            pnkt2_2 = new MenuItem("Подпункт 2_2", new EventHandler(Msg2_2));
            pnkt2 = new MenuItem("Пункт 2", new MenuItem[] { pnkt2_1, pnkt2_2 });

            // Создаем главное меню
            MnMen1 = new MainMenu(new MenuItem[] { pnkt1, pnkt2 });
            this.Menu = MnMen1;
        }

        void Msg1_1(object sr, EventArgs e) { MessageBox.Show("Подпункт 1_1"); }
        void Msg1_2(object sr, EventArgs e) { MessageBox.Show("Подпункт 1_2"); }
        void Msg2_1(object sr, EventArgs e) { MessageBox.Show("Подпункт 2_1"); }
        void Msg2_2(object sr, EventArgs e) { MessageBox.Show("Подпункт 2_2"); }

        // Точка входа в программу
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}

