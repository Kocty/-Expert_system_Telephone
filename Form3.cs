using System;
using System.Data.OleDb;
using System.Text.RegularExpressions;//библиотека для регулярных выражений
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Курсовой_проект
{
    public partial class Settings : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Telephone.accdb";//строка подключения к бд
        private OleDbConnection myConnection;//создание открытого подключения к бд
        Regex rx = new Regex(@"\D", RegexOptions.IgnoreCase);//переменная для textbox запрещающая писать всё кроме цифр
        public string query = null;
        public Settings()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);//задаем строку подключения
            myConnection.Open();//открываем подключение к бд
            comboBox1.SelectedItem = "Apple"; //делает Apple значением по умолчанию в выпадающем списке
            comboBox2.SelectedItem = "6.2-6.5";
            comboBox3.SelectedItem = "64";
            comboBox4.SelectedItem = "AMOLED";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string NamePhone = textBox1.Text;
            string Brand = comboBox1.Text;//объявление переменных
            string Diagonal = comboBox2.Text;
            string Memory = comboBox3.Text;
            string ScreenType = comboBox4.Text;
            
            try
            {
                int Price = Convert.ToInt32(textBox2.Text);
                if ((Price <= 0) || (Price > 200000))//проверка того что минимальная цена меньше максимальной 
                {
                    MessageBox.Show("Цена не может быть меньше 0 или больше 200000", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else //запрос на добавление данных
                {
                    pictureBox1.Image.Save(@"foto\" + textBox1.Text + ".png", ImageFormat.Png);
                    query = "INSERT INTO phones (NamePhone, Brand, ScreenDiagonal, Memory, ScreenType, Price) VALUES ('" + NamePhone + "','" + Brand + "','" + Diagonal + "','" + Memory + "','" + ScreenType + "','" + Price.ToString() + "')";
                    OleDbCommand command = new OleDbCommand(query, myConnection);//выполнение запроса
                    command.ExecuteNonQuery();//возвращение затронутых строк
                    MessageBox.Show("Телефон добавлен ", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.phonesTableAdapter.Fill(this.telephoneDataSet.phones);
                }
            }
            catch
            {
                MessageBox.Show("Проверьте выбор изображения и  заполнение всех полей ввода или такой автомобиль уже существует в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Text = "";//очистка полей ввода после выполнения запроса
            textBox2.Text = "";
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(textBox4.Text);
                string query = "DELETE FROM phones WHERE Id = " + Id; //удаление строки данных
                OleDbCommand command = new OleDbCommand(query, myConnection);//выполнение запроса
                command.ExecuteNonQuery();
                MessageBox.Show("Телефон удален ", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.phonesTableAdapter.Fill(this.telephoneDataSet.phones);
            }
            catch
            {
                MessageBox.Show("Проверьте заполнение поля Id для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox4.Text = "";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(textBox5.Text);
                int Price = Convert.ToInt32(textBox6.Text);
                if ((Price <= 0) || (Price > 200000))//проверека того что минимальная цена меньше максимальной 
                {
                    MessageBox.Show("Цена не может быть меньше 0 или больше 200000", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string query = "UPDATE phones SET Price ='" + Price + "' WHERE Id=" + Id;//изменение данных в определенной строке
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные изменены ", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.phonesTableAdapter.Fill(this.telephoneDataSet.phones);
                }
            }
            catch
            {
                MessageBox.Show("Проверьте заполнение полей Id для изменения или ввода цены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            textBox5.Text = "";
            textBox6.Text = "";
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "telephoneDataSet.phones". При необходимости она может быть перемещена или удалена.
            this.phonesTableAdapter.Fill(this.telephoneDataSet.phones);
        }
        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();//при закрытии формы закрывает соединение с БД
            new Menu().Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.phonesTableAdapter.Fill(this.telephoneDataSet.phones);//обновление таблицы
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 50;//максимальная длина числа в поле
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; // выпадающий список с выбором операций
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; 
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.MaxLength = 6;//максимальная длина числа в поле
            try
            {
                int value = Convert.ToInt32(textBox2.Text);
                if (value > 200000)
                {
                    textBox2.Text = "200000";
                }
            }
            catch
            {
                textBox2.Text = rx.Replace(textBox2.Text, "");
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = rx.Replace(textBox4.Text, "");
            textBox4.MaxLength = 4;//максимальная длина числа в поле
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = rx.Replace(textBox5.Text, "");
            textBox5.MaxLength = 4;//максимальная длина числа в поле
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.MaxLength = 6;//максимальная длина числа в поле
            try
            {
                int value = Convert.ToInt32(textBox6.Text);
                if (value > 200000)
                {
                    textBox6.Text = "200000";
                }
            }
            catch
            {
                textBox6.Text = rx.Replace(textBox6.Text, "");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
           
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                DialogResult dr = openFileDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Image file = Image.FromFile(openFileDialog.FileName);
                    pictureBox1.Image = file;
                }

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pictureBox2.Visible = false;
        }
    }
}