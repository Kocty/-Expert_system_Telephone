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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
