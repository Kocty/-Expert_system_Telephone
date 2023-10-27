using System;
using System.Windows.Forms;

namespace Курсовой_проект
{
    public partial class Menu : Form
    {
        /* инициализация и подключение форм к главной форме*/
        public Menu()
        {
            InitializeComponent();
            form2 = new Test();
            form3 = new Settings();
            form4 = new Admin();
        }
        Test form2;
        Settings form3;
        Admin form4;
        private void button1_Click(object sender, EventArgs e)/*Открытие форм и скрытие основной формы*/
        {
            new Test().Show();
            Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            new Admin().Show();
            Hide();
        }
        private void button3_Click(object sender, EventArgs e)/*Закрывание программы и всех форм*/
        {
            Environment.Exit(0);
        }
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
