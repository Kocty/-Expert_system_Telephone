using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовой_проект
{
    public partial class Settings : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Avto2.accdb";
        private OleDbConnection myConnection;
        public Settings()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comboBox1.SelectedItem = "Toyota"; //делает Toyota значением по умолчанию
        }


        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                string NameAvto = textBox1.Text;
                string Brand = comboBox1.Text;
                int PriceMin = 0, PriceMax = 0;
                
                
                try {
                    PriceMin = Convert.ToInt32(textBox2.Text);
                }
                catch
                {
                    MessageBox.Show("Введено неверное значение в поле минимальная цена! Пожалуйста, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Text = "";
                    return;
                }

                try
                {
                    PriceMax = Convert.ToInt32(textBox3.Text);
                }
                catch
                {
                    MessageBox.Show("Введено неверное значение в поле максимальная цена! Пожалуйста, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Text = "";
                    return;
                }
                
                if (PriceMax < PriceMin)
                {
                    MessageBox.Show("Максимальная цена не может быть меньше минимальной цены! Пожалуйста, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    this.carsTableAdapter.Fill(this.avto2DataSet.cars);
                    string query = "INSERT INTO cars (NameAvto, Brand, PriceMin, PriceMax) VALUES ('" + NameAvto + "','" + Brand + "','" + PriceMin + "','" + PriceMax + "')";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    this.carsTableAdapter.Fill(this.avto2DataSet.cars);
                    MessageBox.Show("Автомобиль добавлен ", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Проверьте заполнение всех полей ввода или такой автомобиль уже существует в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void carsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.carsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.avto2DataSet);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avto2DataSet.cars". При необходимости она может быть перемещена или удалена.
            this.carsTableAdapter.Fill(this.avto2DataSet.cars);
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
            this.carsTableAdapter.Fill(this.avto2DataSet.cars);
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 50;//максимальная длина числа в поле
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; // выпадающий список с выбором операций
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.MaxLength = 7;//максимальная длина числа в поле
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.MaxLength = 7;//максимальная длина числа в поле
        }
        private void carsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
