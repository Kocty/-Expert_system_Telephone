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
        
        /*Открытие форм и скрытие основной формы*/
        private void button1_Click(object sender, EventArgs e)
        {
            new Test().Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Admin().Show();
            Hide();
        }

        /*Закрывание программы и всех форм*/
        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
