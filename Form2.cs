using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;//библиотека для работы с запросами для бд
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Курсовой_проект
{
    public partial class Test : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Avto2.accdb";
        private OleDbConnection myConnection;
        public Test()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = null;
            int n = 0;
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            try
            {
                //блок проверки выбора марки и выбора ответа во всех вопросах
                if (radioButton13.Checked == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && (radioButton7.Checked == true || radioButton8.Checked == true || radioButton9.Checked == true) && (radioButton10.Checked == true || radioButton11.Checked == true || radioButton12.Checked == true))
                {
                    n = 1; //Toyota
                }
                else if (radioButton14.Checked == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && (radioButton7.Checked == true || radioButton8.Checked == true || radioButton9.Checked == true) && (radioButton10.Checked == true || radioButton11.Checked == true || radioButton12.Checked == true))
                {
                    n = 2; //BMW
                }
                else if (radioButton15.Checked == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && (radioButton7.Checked == true || radioButton8.Checked == true || radioButton9.Checked == true) && (radioButton10.Checked == true || radioButton11.Checked == true || radioButton12.Checked == true))
                {
                    n = 3; //Ford 
                }
                else if (radioButton16.Checked == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && (radioButton7.Checked == true || radioButton8.Checked == true || radioButton9.Checked == true) && (radioButton10.Checked == true || radioButton11.Checked == true || radioButton12.Checked == true))
                {
                    n = 4; //Kia
                }
                else if (radioButton17.Checked == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && (radioButton7.Checked == true || radioButton8.Checked == true || radioButton9.Checked == true) && (radioButton10.Checked == true || radioButton11.Checked == true || radioButton12.Checked == true))
                {
                    n = 5; //Lada
                }
                else if (radioButton18.Checked == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && (radioButton7.Checked == true || radioButton8.Checked == true || radioButton9.Checked == true) && (radioButton10.Checked == true || radioButton11.Checked == true || radioButton12.Checked == true))
                {
                    n = 9; //без марки
                };


                //блок выбора цены автомобиля и выполнения запроса к БД    ORDER BY RAND() LIMIT 1  ORDER BY RAND() LIMIT 1
                if (radioButton1.Checked == true)//до 1 млн цена
                {
                    switch (n)//проверка выбранной марки
                    {
                        case 1:
                            query = "SELECT NameAvto, Brand, PriceMin, PriceMax FROM cars WHERE Brand ='" + "Toyota" + "' AND PriceMax < 1000001";

                            break;

                        case 2:
                            query = "SELECT * FROM cars WHERE Brand ='" + "BMW" + "' AND PriceMax < 1000001";
                            break;

                        case 3:
                            query = "SELECT * FROM cars WHERE Brand ='" + "Ford" + "' AND PriceMax < 1000001";
                            break;

                        case 4:
                            query = "SELECT * FROM cars WHERE Brand ='" + "Kia" + "' AND PriceMax < 1000001";
                            break;

                        case 5:
                            query = "SELECT * FROM cars WHERE Brand ='" + "Lada" + "' AND PriceMax < 1000001";

                            break;

                        case 9:
                            query = "SELECT * FROM cars WHERE PriceMax < 1000001";
                            break;
                    }


                }
                else if (radioButton2.Checked == true)//от 1 до 3 млн цена
                {
                    switch (n)
                    {
                        case 1:
                            query = "SELECT * FROM cars WHERE Brand ='" + "Toyota" + "' AND PriceMin > 999999 AND PriceMax < 3000001 ";

                            break;

                        case 2:
                            query = "SELECT * FROM cars WHERE Brand ='" + "BMW" + "' AND PriceMin > 999999 AND PriceMax < 3000001 ";

                            break;

                        case 3:
                            query = "SELECT * FROM cars WHERE Brand ='" + "Ford" + "' AND PriceMin > 999999 AND PriceMax < 3000001 ";
                            break;

                        case 4:
                            query = "SELECT * FROM cars WHERE Brand ='" + "Kia" + "' AND PriceMin > 999999 AND PriceMax < 3000001 ";
                            break;

                        case 5:
                            query = "SELECT * FROM cars WHERE Brand ='" + "Lada" + "' AND PriceMin > 999999 AND PriceMax < 3000001 ";

                            break;

                        case 9:
                            query = "SELECT * FROM cars WHERE PriceMin > 999999 AND PriceMax < 3000001 ";
                            break;

                    }

                }
                else if (radioButton3.Checked == true)//от 3 до 5 млн цена Toyota BMW Ford Kia Lada
                {
                    switch (n)
                    {
                        case 1:
                            query = "SELECT * FROM cars WHERE Brand ='" + "Toyota" + "' AND PriceMin > 2999999 AND PriceMax < 5000001 ";

                            break;

                        case 2:
                            query = "SELECT * FROM cars WHERE Brand ='" + "BMW" + "' AND PriceMin > 2999999 AND PriceMax < 5000001 ";

                            break;

                        case 3:
                            query = "SELECT * FROM cars WHERE Brand ='" + "Ford" + "' AND PriceMin > 2999999 AND PriceMax < 5000001 ";
                            break;

                        case 4:
                            query = "SELECT * FROM cars WHERE Brand ='" + "Kia" + "' AND PriceMin > 2999999 AND PriceMax < 5000001 ";
                            break;

                        case 5:
                            query = "SELECT * FROM cars WHERE Brand ='" + "Lada" + "' AND PriceMin > 2999999 AND PriceMax < 5000001 ";

                            break;

                        case 9:
                            query = "SELECT * FROM cars WHERE PriceMin > 2999999 AND PriceMax < 5000001";
                            break;
                    }

                }

                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();


                if (reader.HasRows == false) // блок проверки результата если он отсутствует то выводится сообщением об этом
                {
                    MessageBox.Show("Подходящий автомобиль отсутствует в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    while (reader.Read())//запись значений в столбци таблицы
                    {
                        dataGridView1.Rows.Add(reader["NameAvto"], reader["Brand"], reader["PriceMin"], reader["PriceMax"]);

                        //короче тема такая либо чекни видос индуса в ютубе сохранил и делай вывод значений в отдельные textbox по нажатию строки в datagridview либо 
                        //выводи только id в datagridview считывай их и через какой нибудь цикл  for выводи textbox прямо из бд но как это делать полный хз так что пробуй костыль по первому способу 
                        //хоть как нибудь сделать потому что надо уже заканчивать с тестом и делать добавления машин в бд
                    }
                }
                this.carsTableAdapter.Fill(this.avto2DataSet.cars);

            }
            catch
            {
                MessageBox.Show("Проверьте варианты ответов в каждом вопросе должен быть выбрат ответ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        

        private void carsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.carsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.avto2DataSet);

        }

        private void Test_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avto2DataSet.cars". При необходимости она может быть перемещена или удалена.
            this.carsTableAdapter.Fill(this.avto2DataSet.cars);

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();//при закрытии формы закрывает соединение с БД
            new Menu().Show();  

        }

        private void button3_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
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
            dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
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
    }
}
