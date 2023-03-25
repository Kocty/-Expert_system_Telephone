using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private string Login = "admin";
        private string Password = "12345";

        private void button1_Click(object sender, EventArgs e)
        {
            string Log = textBox1.Text;
            string Pas = textBox2.Text;
            if (Log==Login && Pas==Password)
            {
                form3.Show();
            }
            else
            {
                MessageBox.Show("Ошибка ввода", "Попробуйте заново!");
            }
            
        }
    }
}
