﻿using System;
using System.Windows.Forms;
using System.Data.OleDb;//библиотека для работы с запросами для бд
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Курсовой_проект
{
    public partial class Test : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Telephone.accdb";//строка подключения к бд
        private OleDbConnection myConnection;//создание открытого подключения к бд
        public int Price = 0;
        public Test()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);//задаем строку подключения
            myConnection.Open();//открываем подключение к бд
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = null;//обьявление переменой для запроса
            string brand = null;
            string Diagonal = null;
            string Memory = null;
            string ScreenType = null;
            string Price1 = null;


            dataGridView1.Rows.Clear();//очистка таблицы и полей вывода
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            try
            {
                //блок проверки выбора бренда и выбора ответа во всех вопросах
                if (radioButton13.Checked == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && (radioButton7.Checked == true || radioButton8.Checked == true || radioButton9.Checked == true) && (radioButton10.Checked == true || radioButton11.Checked == true || radioButton12.Checked == true))
                {
                    brand = "Apple"; 
                }
                else if (radioButton14.Checked == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && (radioButton7.Checked == true || radioButton8.Checked == true || radioButton9.Checked == true) && (radioButton10.Checked == true || radioButton11.Checked == true || radioButton12.Checked == true))
                {
                    brand = "Xiaomi";
                }
                else if (radioButton15.Checked == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && (radioButton7.Checked == true || radioButton8.Checked == true || radioButton9.Checked == true) && (radioButton10.Checked == true || radioButton11.Checked == true || radioButton12.Checked == true))
                {
                    brand = "Samsung";
                }
                else if (radioButton16.Checked == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && (radioButton7.Checked == true || radioButton8.Checked == true || radioButton9.Checked == true) && (radioButton10.Checked == true || radioButton11.Checked == true || radioButton12.Checked == true || radioButton19.Checked == true || radioButton20.Checked == true || radioButton21.Checked == true))
                {
                    brand = "Honor";
                }
                else if (radioButton17.Checked == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && (radioButton7.Checked == true || radioButton8.Checked == true || radioButton9.Checked == true) && (radioButton10.Checked == true || radioButton11.Checked == true || radioButton12.Checked == true || radioButton19.Checked == true || radioButton20.Checked == true || radioButton21.Checked == true))
                {
                    brand = "Oppo";
                }
                else if (radioButton18.Checked == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && (radioButton7.Checked == true || radioButton8.Checked == true || radioButton9.Checked == true) && (radioButton10.Checked == true || radioButton11.Checked == true || radioButton12.Checked == true || radioButton19.Checked == true || radioButton20.Checked == true || radioButton21.Checked == true))
                {
                    brand = "nothing"; //без бренда
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

                if (radioButton1.Checked == true)
                {
                    Memory = "256";

                }
                else if (radioButton2.Checked == true)
                {
                    Memory = "512";

                }
                else if (radioButton3.Checked == true)
                {
                    Memory = "1T";

                }
                else if(radioButton7.Checked == true)//размер памяти
                {
                    Memory = "1T";
                }
                else if (radioButton8.Checked == true)
                {
                    Memory = "64";
                }
                else if (radioButton9.Checked == true)
                {
                    Memory = "128";
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

                Price1 = Convert.ToString(trackBar1.Value);
                query = "SELECT * FROM phones WHERE Brand ='" + brand + "' AND ScreenDiagonal ='" + Diagonal + "' AND Memory ='" + Memory + "' AND ScreenType ='" + ScreenType + "' AND Price <" + Price1 + " ";
                
                //query = "SELECT * FROM phones WHERE Brand ='" + brand + "' AND Price <" + Price1 + " ";

                //query = "SELECT * FROM phones WHERE Memory ='" + Memory + "'";

                //query = "SELECT * FROM phones WHERE Brand ='" + brand + "' AND ScreenDiagonal ='" + Diagonal + "' AND Memory ='" + Memory + "' AND ScreenType ='" + ScreenType + "' AND Price < 15001";
                //query = "SELECT * FROM phones WHERE Brand ='" + brand + "' AND Diagonal='" + Diagonal + "' AND Memory='" + Memory + "' AND ScreenType='" + ScreenType + "' AND PriceMax < 15001" ;
                //query = "SELECT * FROM phones WHERE Memory = '64'";

                //блок выбора цены автомобиля и выполнения запроса к БД 

                //if (radioButton1.Checked == true)//до 15001 тыс цена
                //{
                //    Price1 = "15001";
                //    query = "SELECT * FROM phones WHERE Brand ='" + brand + "' AND ScreenDiagonal ='" + Diagonal + "' AND Memory ='" + Memory + "' AND ScreenType ='" + ScreenType + "' AND Price <" + Price1 + "";
                //}
                //else if (radioButton2.Checked == true)//от 1 до 3 млн цена
                //{
                //    query = "SELECT * FROM phones WHERE Brand ='" + brand + "' AND ScreenDiagonal ='" + Diagonal + "' AND Memory ='" + Memory + "' AND ScreenType ='" + ScreenType + "' AND 15001 < Price > 50001 ";

                //}
                //else if (radioButton3.Checked == true)//от 3 до 5 млн цена 
                //{
                //    query = "SELECT * FROM phones WHERE Brand ='" + brand + "' AND ScreenDiagonal ='" + Diagonal + "' AND Memory ='" + Memory + "' AND ScreenType ='" + ScreenType + "' AND Price > 50001";

                //}


                OleDbCommand command = new OleDbCommand(query, myConnection);//выполнение запроса
                OleDbDataReader reader = command.ExecuteReader();//получение данных из бд

                textBox1.Text = brand;
                textBox2.Text = Memory;
                textBox3.Text = Convert.ToString(Price1);

                if (reader.HasRows == false) // блок проверки результата если он отсутствует то выводится сообщением об этом
                {
                    MessageBox.Show("Подходящий автомобиль отсутствует в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    while (reader.Read())//запись значений в столбцы таблицы    
                    {
                        dataGridView1.Rows.Add(reader["NamePhone"], reader["Brand"], reader["ScreenDiagonal"], reader["Memory"], reader["ScreenType"], reader["Price"]);
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
            Price = trackBar1.Value;
            textBox5.Text = "" + Price;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt32(textBox5.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();//закрытие формы
            
        }

        private void Test_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "telephoneDataSet.phones". При необходимости она может быть перемещена или удалена.
            this.phonesTableAdapter.Fill(this.telephoneDataSet.phones);
            
        }
       
        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();//при закрытии формы закрывает соединение с БД
            new Menu().Show();  

        }

        private void button3_Click(object sender, EventArgs e)//очистка всех полей
        {
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
            dataGridView1.Rows.Clear();
        }
        /*проверка на наличие записи при нажатии на строку в таблице, если отсутствует то выводит сообщение об этом*/
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)//если запись есть то выводи значения из таблицы в поля вывода
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox3.Text = textBox3.Text + " ₽";// добавляем в конце строки знак рубля(правый alt + 8)
                    textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox4.Text = textBox4.Text + " ₽";
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void phonesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.phonesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.telephoneDataSet);

        }

        
    }

}
