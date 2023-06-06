using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Курсовой_проект
{
    public partial class Settings : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Avto2.accdb";//строка подключения к бд
        private OleDbConnection myConnection;//создание открытого подключения к бд
        public Settings()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);//задаем строку подключения
            myConnection.Open();//открываем подключение к бд
            comboBox1.SelectedItem = "Toyota"; //делает Toyota значением по умолчанию в выпадающем списке
            
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
                string NameAvto = textBox1.Text;//объявление переменных
                string Brand = comboBox1.Text;
                int PriceMin = 0, PriceMax = 0;
                /*проверка правильности ввода в полях для ввода данных*/
                try 
                {
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
                
                if (PriceMax < PriceMin)//проверека того что минимальная цена меньше максимальной 
                {
                    MessageBox.Show("Максимальная цена не может быть меньше минимальной цены! Пожалуйста, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {//запрос на добаление данных
                    string query = "INSERT INTO cars (NameAvto, Brand, PriceMin, PriceMax) VALUES ('" + NameAvto + "','" + Brand + "','" + PriceMin + "','" + PriceMax + "')";
                    OleDbCommand command = new OleDbCommand(query, myConnection);//выполнение запроса
                    command.ExecuteNonQuery();//возвращение затронутых строк
                    MessageBox.Show("Автомобиль добавлен ", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.carsTableAdapter.Fill(this.avto2DataSet.cars);
                }
            }
            catch
            {
                MessageBox.Show("Проверьте заполнение всех полей ввода или такой автомобиль уже существует в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            textBox1.Text = "";//очистка полей ввода после выполнения запроса
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(textBox4.Text);
                string query = "DELETE FROM cars WHERE Id = " + Id;//удаление строки данных
                OleDbCommand command = new OleDbCommand(query, myConnection);//выполнение запроса
                command.ExecuteNonQuery();
                MessageBox.Show("Автомобиль удален ", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.carsTableAdapter.Fill(this.avto2DataSet.cars);
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
                int PriceMin = 0, PriceMax = 0;
                /*проверка правильности ввода в полях для ввода данных*/
                try
                {
                    PriceMin = Convert.ToInt32(textBox6.Text);
                }
                catch
                {
                    MessageBox.Show("Введено неверное значение в поле новая минимальная цена! Пожалуйста, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox6.Text = "";
                    return;
                }

                try
                {
                    PriceMax = Convert.ToInt32(textBox7.Text);
                }
                catch
                {
                    MessageBox.Show("Введено неверное значение в поле новая максимальная цена! Пожалуйста, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox7.Text = "";
                    return;
                }

                if (PriceMax < PriceMin)
                {
                    MessageBox.Show("Максимальная цена не может быть меньше минимальной цены! Пожалуйста, попробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string query = "UPDATE cars SET PriceMin='" + PriceMin + "', PriceMax= '" + PriceMax + "' WHERE Id=" + Id;//изменение данных в определенной строке
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные изменены ", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.carsTableAdapter.Fill(this.avto2DataSet.cars);
                }
            }
            catch
            {
                MessageBox.Show("Проверьте заполнение полей Id для изменения или ввода цен автомобиля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
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
            this.carsTableAdapter.Fill(this.avto2DataSet.cars);//обновление таблицы
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
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.MaxLength = 4;//максимальная длина числа в поле
        }
        
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.MaxLength = 4;//максимальная длина числа в поле
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.MaxLength = 7;//максимальная длина числа в поле
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.MaxLength = 7;//максимальная длина числа в поле
        }

        private void carsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
