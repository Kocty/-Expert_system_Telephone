using System;
using System.Windows.Forms;
using System.Data.OleDb;//библиотека для работы с запросами для бд
using System.Text.RegularExpressions;//библиотека для регулярных выражений
using System.Drawing;

namespace Курсовой_проект
{
    public partial class Test : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Telephone.accdb";//строка подключения к бд
        private OleDbConnection myConnection;//создание открытого подключения к бд
        Regex rx = new Regex(@"\D", RegexOptions.IgnoreCase);//переменная для textbox запрещающая писать всё кроме цифр
        public Test()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);//задаем строку подключения
            myConnection.Open();//открываем подключение к бд
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string query = null;//объявление переменой для запроса
            string brand = null;//объявление переменных для запроса
            string Diagonal = null;
            string Memory = null;
            string ScreenType = null;
            string PriceMin = null;
            string PriceMax = null;

            dataGridView1.Rows.Clear();//очистка таблицы и полей вывода
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            pictureBox1.Image = null;

            try
            {
                if (trackBar1.Value >= 0 && trackBar2.Value <= 200000)//проверка для цены
                {
                    PriceMin = Convert.ToString(trackBar1.Value);
                    PriceMax = Convert.ToString(trackBar2.Value);
                }
                else
                {
                    MessageBox.Show("Цена не может быть меньше 0 и больше 200000", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };

                if (radioButton4.Checked == true)//диагональ экрана
                {
                    Diagonal = "5.6-6.1";
                }
                else if (radioButton5.Checked == true)
                {
                    Diagonal = "6.2-6.5";
                }
                else if (radioButton6.Checked == true)
                {
                    Diagonal = ">6.6";
                };

                if (radioButton1.Checked == true)//размер памяти
                {
                    Memory = "32";
                }
                else if (radioButton2.Checked == true)
                {
                    Memory = "64";
                }
                else if (radioButton3.Checked == true)
                {
                    Memory = "128";
                }
                else if (radioButton7.Checked == true)
                {
                    Memory = "256";
                }
                else if (radioButton8.Checked == true)
                {
                    Memory = "512";
                }
                else if (radioButton9.Checked == true)
                {
                    Memory = "1T";
                };

                if (radioButton10.Checked == true)//тип экрана
                {
                    ScreenType = "TFT/LCD";

                }
                else if (radioButton11.Checked == true)
                {
                    ScreenType = "IPS/PLS";

                }
                else if (radioButton12.Checked == true)
                {
                    ScreenType = "AMOLED";
                };

                if (radioButton13.Checked == true)//блок проверки выбора бренда и выбора ответа во всех вопросах
                {
                    brand = "Apple";
                }
                else if (radioButton14.Checked == true)
                {
                    brand = "Xiaomi";
                }
                else if (radioButton15.Checked == true)
                {
                    brand = "Samsung";
                }
                else if (radioButton16.Checked == true)
                {
                    brand = "Honor";
                }
                else if (radioButton17.Checked == true)
                {
                    brand = "Oppo";
                }
                else if (radioButton18.Checked == true)
                {
                    brand = "No"; //без бренда
                };

                if ((radioButton13.Checked == true || radioButton14.Checked == true || radioButton15.Checked == true || radioButton16.Checked == true || radioButton17.Checked == true || radioButton18.Checked == true) && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true || radioButton7.Checked == true || radioButton8.Checked == true || radioButton9.Checked == true) && (radioButton10.Checked == true || radioButton11.Checked == true || radioButton12.Checked == true))
                {
                    if(brand == "No")
                    {
                        query = "SELECT * FROM phones WHERE ScreenDiagonal ='" + Diagonal + "' AND Memory ='" + Memory + "' AND ScreenType ='" + ScreenType + "' AND Price >" + PriceMin + " AND Price <" + PriceMax + "";
                    }
                    else
                    {
                        query = "SELECT * FROM phones WHERE Brand ='" + brand + "' AND ScreenDiagonal ='" + Diagonal + "' AND Memory ='" + Memory + "' AND ScreenType ='" + ScreenType + "' AND Price >" + PriceMin + " AND Price <" + PriceMax + "";
                    }
                }

                OleDbCommand command = new OleDbCommand(query, myConnection);//выполнение запроса
                OleDbDataReader reader = command.ExecuteReader();//получение данных из бд

                if (reader.HasRows == false) // блок проверки результата если он отсутствует то выводится сообщением об этом
                {
                    MessageBox.Show("Подходящий телефон отсутствует в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    while (reader.Read())//запись значений в столбцы таблицы    
                    {
                        dataGridView1.Rows.Add(reader["NamePhone"], reader["Brand"], reader["ScreenDiagonal"], reader["Memory"], reader["ScreenType"], reader["Price"], reader["Color"]);
                    }
                }
                this.phonesTableAdapter.Fill(this.telephoneDataSet.phones);
            }
            catch
            {
                MessageBox.Show("Проверьте варианты ответов в каждом вопросе должен быть выбран ответ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox5.Text = "" + trackBar1.Value;
            trackBar1.Maximum = trackBar2.Value;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.MaxLength = 6;
            try
            {
                int value = Convert.ToInt32(textBox5.Text);
                if (trackBar1.Maximum < value)
                {
                    textBox5.Text = trackBar1.Value.ToString();
                }
                else
                {
                    trackBar1.Value = Convert.ToInt32(textBox5.Text);
                }
            }
            catch
            {
                textBox5.Text = rx.Replace(textBox5.Text, "");
            }
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox6.Text = "" + trackBar2.Value;
            trackBar2.Minimum = trackBar1.Value;
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.MaxLength = 6;
            try
            {
                int value = Convert.ToInt32(textBox6.Text);
                if (value > 200000)
                {
                    textBox6.Text = "200000";
                }
                else
                {
                    trackBar2.Value = Convert.ToInt32(textBox6.Text); 
                }
            }
            catch
            {
                textBox6.Text = rx.Replace(textBox6.Text, "");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();//закрытие формы
        }
        private void Test_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "telephoneDataSet.phones". При необходимости она может быть перемещена или удалена.
            this.phonesTableAdapter.Fill(this.telephoneDataSet.phones);

            ToolTip toolTip = new ToolTip();//всплывающие подсказки 
            toolTip.IsBalloon = true;
            toolTip.AutomaticDelay = 1000;
            toolTip.SetToolTip(radioButton10, "Дешевые матрицы для бюджетных телефонов с низкой контрастностью и яркостью ");
            toolTip.SetToolTip(radioButton11, "Матрицы для телефонов средней ценовой категории с хорошей передачей цвета и временем отклика ");
            toolTip.SetToolTip(radioButton12, "Современные матрицы с отличной контрастностью, работой с глубиной черного цвета и яркостью");
        }
        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();//при закрытии формы закрывает соединение с БД
            new Menu().Show();  
        }
        private void button3_Click(object sender, EventArgs e)//очистка всех полей
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            radioButton15.Checked = false;
            radioButton16.Checked = false;
            radioButton17.Checked = false;
            radioButton18.Checked = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            trackBar1.Value = 5000;
            trackBar2.Value = 10000;
            textBox5.Text = "5000";
            textBox6.Text = "10000";
            dataGridView1.Rows.Clear();
            pictureBox1.Image = null; 
        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)/*проверка на наличие записи при нажатии на строку в таблице, если отсутствует то выводит сообщение об этом*/
        {
            try
            {
                if (e.RowIndex >= 0)//если запись есть то выводи значения из таблицы в поля вывода
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox7.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox8.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString() + " ₽";// добавляем в конце строки знак рубля(правый alt + 8)
                    textBox9.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    pictureBox1.ImageLocation = @"foto\NULL2.jpg";
                    
                    if (pictureBox1.ImageLocation != null)
                    {
                        pictureBox1.ImageLocation = @"foto\" + textBox1.Text + ".jpg";
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("Вариант отсутствует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)//инструкция для прохождения теста
        {
            MessageBox.Show("Для прохождения теста выбирайте по одному варианту ответа на вопрос, после выбора всех ответов нажмите кнопку 'ПОДОБРАТЬ Телефон' подходящие телефоны появятся в табличке в правом верхнем углу, вы можете нажимать на подходящие варианты и получать информацию в полях под таблицей. ", "Как проходить тест", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}