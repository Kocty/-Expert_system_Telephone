using System;
using System.Windows.Forms;

namespace Курсовой_проект
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            form3 = new Settings();
        }
        Settings form3;

        private string Login = "admin";//объявление переменных с определенными данными
        private string Password = "12345";

        private void button1_Click(object sender, EventArgs e)
        {
            string Log = textBox1.Text;
            string Pas = textBox2.Text;
            if (Log==Login && Pas==Password)
            {
                new Settings().Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Ошибка ввода", "Попробуйте заново!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Menu().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
