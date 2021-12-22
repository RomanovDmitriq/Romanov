using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PraktikaRomanov
{
    public partial class Form3 : Form
    {
        DB db = new DB();
        public Form3()
        {
            InitializeComponent();
        }
        private void LoadData()
        {


            DataTable table = new DataTable();
            try
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView3.AllowUserToAddRows = false;
                dataGridView4.AllowUserToAddRows = false;
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT клиенты.id_клиента AS id, клиенты.Паспортные_данные AS Паспорт, клиенты.Фамилия AS Фамилия, клиенты.Имя AS Имя, клиенты.Номер_клиента AS Номер, клиенты.Почта_клиента AS Почта  FROM клиенты", db.GetConnection());
                adapter.SelectCommand = command;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "клиенты");

                dataGridView2.DataSource = dataSet.Tables["клиенты"];
                dataGridView2.AutoResizeColumns();

                MySqlDataAdapter adapter2 = new MySqlDataAdapter();

                MySqlCommand command2 = new MySqlCommand("SELECT мероприятия.id_мероприятия AS id, мероприятия.Название_мероприятия AS Название, мероприятия.Описание AS Описание FROM мероприятия", db.GetConnection());
                adapter2.SelectCommand = command2;


                DataSet dataSet2 = new DataSet();
                adapter2.Fill(dataSet2, "мероприятия");

                dataGridView1.DataSource = dataSet2.Tables["мероприятия"];
                dataGridView1.AutoResizeColumns();


                MySqlDataAdapter adapter3 = new MySqlDataAdapter();

                MySqlCommand command3 = new MySqlCommand("SELECT туры.id_тура AS id, туры.Название_тура AS Название, туры.Дата_начала, туры.Дата_завершения, туры.Стоимость_тура, туры.Пункт_отправки, туры.Пункт_прибытия, туры.Вид_тура AS Вид, туры.id_клиента,туры.id_гида,туры.id_мероприятия FROM туры", db.GetConnection());
                adapter3.SelectCommand = command3;


                DataSet dataSet3 = new DataSet();
                adapter3.Fill(dataSet3, "туры");

                dataGridView3.DataSource = dataSet3.Tables["туры"];
                dataGridView3.AutoResizeColumns();



                MySqlDataAdapter adapter4 = new MySqlDataAdapter();

                MySqlCommand command4 = new MySqlCommand("SELECT гиды.id_гида AS id, гиды.Фамилия, гиды.Имя, гиды.Номер_гида AS Номер, гиды.Почта_гида AS Почта FROM гиды", db.GetConnection());
                adapter4.SelectCommand = command4;


                DataSet dataSet4 = new DataSet();
                adapter4.Fill(dataSet4, "гиды");

                dataGridView4.DataSource = dataSet4.Tables["гиды"];
                dataGridView4.AutoResizeColumns();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            LoadData();


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT туры.id_тура AS id, туры.Название_тура AS Название, туры.Дата_начала, туры.Дата_завершения, туры.Стоимость_тура, туры.Пункт_отправки, туры.Пункт_прибытия, туры.Вид_тура AS Вид, туры.id_клиента,туры.id_гида,туры.id_мероприятия FROM туры", db.GetConnection());

                string Название_тура = textBox1.Text;
                string Дата_начала = dateTimePicker1.Text;
                if (Дата_начала != "")
                {
                    Дата_начала = DateTime.Parse(Дата_начала).ToString("yyyyMMdd");
                }
                else
                {
                    Дата_начала = null;
                }
                string Дата_завершения = dateTimePicker2.Text;
                if (Дата_завершения != "")
                {
                    Дата_завершения = DateTime.Parse(Дата_завершения).ToString("yyyyMMdd");
                }
                else
                {
                    Дата_завершения = null;
                }
                string Стоимость_тура = textBox4.Text;
                string Пункт_отправки = textBox5.Text;
                string Пункт_прибытия = textBox6.Text;
                string Вид_тура = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string id_клиента = textBox10.Text;
                string id_гида = textBox9.Text;
                string id_мероприятия = textBox8.Text;



                adapter.SelectCommand = command;

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("insert `туры` ( `Название_тура`, `Дата_начала`,`Дата_завершения`, `Стоимость_тура`,`Пункт_отправки`, `Пункт_прибытия`,`Вид_тура`, `id_клиента`,`id_гида`, `id_мероприятия`) VALUES (@1U, @2U,@3U, @4U,@5U, @6U,@7U, @8U,@9U, @10U)", db.GetConnection());

                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = Название_тура;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Дата_начала;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = Дата_завершения;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = Стоимость_тура;
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = Пункт_отправки;
                command1.Parameters.Add("@6U", MySqlDbType.VarChar).Value = Пункт_прибытия;
                command1.Parameters.Add("@7U", MySqlDbType.VarChar).Value = Вид_тура;
                command1.Parameters.Add("@8U", MySqlDbType.VarChar).Value = id_клиента;
                command1.Parameters.Add("@9U", MySqlDbType.VarChar).Value = id_гида;
                command1.Parameters.Add("@10U", MySqlDbType.VarChar).Value = id_мероприятия;

                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "туры");

                adapter1.Fill(dataSet, "туры");
                dataSet.Tables["туры"].Clear();
                adapter.Fill(dataSet, "туры");
                
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = dataSet.Tables["туры"];
                dataGridView3.AutoResizeColumns();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT туры.id_тура AS id, туры.Название_тура AS Название, туры.Дата_начала, туры.Дата_завершения, туры.Стоимость_тура, туры.Пункт_отправки, туры.Пункт_прибытия, туры.Вид_тура AS Вид, туры.id_клиента,туры.id_гида,туры.id_мероприятия FROM туры", db.GetConnection());
                adapter.SelectCommand = command;

                string id_клиента = dataGridView3.CurrentRow.Cells[0].Value.ToString();

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("DELETE FROM `туры` WHERE `id_тура` = @lU", db.GetConnection());
                command1.Parameters.Add("@lU", MySqlDbType.VarChar).Value = id_клиента;
                adapter1.SelectCommand = command1;

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "туры");
                adapter1.Fill(dataSet, "туры");
                dataSet.Tables["туры"].Clear();
                adapter.Fill(dataSet, "туры");
                
                dataGridView3.DataSource = dataSet.Tables["туры"];
                dataGridView3.AutoResizeColumns();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT туры.id_тура AS id, туры.Название_тура AS Название, туры.Дата_начала, туры.Дата_завершения, туры.Стоимость_тура, туры.Пункт_отправки, туры.Пункт_прибытия, туры.Вид_тура AS Вид, туры.id_клиента,туры.id_гида,туры.id_мероприятия FROM туры", db.GetConnection());
                adapter.SelectCommand = command;
                string id_тура = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                string Название_тура = textBox1.Text;
                string Дата_начала = dateTimePicker1.Text;
                if (Дата_начала != "")
                {
                    Дата_начала = DateTime.Parse(Дата_начала).ToString("dd.MM.yyyy");
                }
                else
                {
                    Дата_начала = null;
                }
                string Дата_завершения = dateTimePicker2.Text;
                if (Дата_завершения != "")
                {
                    Дата_завершения = DateTime.Parse(Дата_завершения).ToString("dd.MM.yyyy");
                }
                else
                {
                    Дата_завершения = null;
                }
                string Стоимость_тура = textBox4.Text;
                string Пункт_отправки = textBox5.Text;
                string Пункт_прибытия = textBox6.Text;
                string Вид_тура = comboBox1.Text;
                string id_клиента = textBox10.Text;
                string id_гида = textBox9.Text;
                string id_мероприятия = textBox8.Text;


                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("UPDATE `туры` SET `id_тура` =  @0U , `Название_тура` =  @1U ,  `Дата_начала` = @2U  , `Дата_завершения`=@3U, `Стоимость_тура` = @4U, `Пункт_отправки` = @5U, `Пункт_прибытия` = @6U, `Вид_тура` = @7U, `id_клиента` = @8U, `id_гида` = @9U, `id_мероприятия` = @10U WHERE `id_тура` = @0U", db.GetConnection());
                command1.Parameters.Add("@0U", MySqlDbType.VarChar).Value = id_тура;
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = Название_тура;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Дата_начала;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = Дата_завершения;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = Стоимость_тура;
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = Пункт_отправки;
                command1.Parameters.Add("@6U", MySqlDbType.VarChar).Value = Пункт_прибытия;
                command1.Parameters.Add("@7U", MySqlDbType.VarChar).Value = Вид_тура;
                command1.Parameters.Add("@8U", MySqlDbType.VarChar).Value = id_клиента;
                command1.Parameters.Add("@9U", MySqlDbType.VarChar).Value = id_гида;
                command1.Parameters.Add("@10U", MySqlDbType.VarChar).Value = id_мероприятия;

                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "туры");

                adapter1.Fill(dataSet, "туры");
                dataSet.Tables["туры"].Clear();
                adapter.Fill(dataSet, "туры");
                
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = dataSet.Tables["туры"];
                dataGridView3.AutoResizeColumns();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT туры.id_тура, туры.Название_тура, туры.Дата_начала, туры.Дата_завершения, туры.Стоимость_тура, туры.Пункт_отправки, туры.Пункт_прибытия, туры.Вид_тура, туры.id_клиента,туры.id_гида,туры.id_мероприятия FROM туры where туры.id_тура=@a ", db.GetConnection());
            adapter.SelectCommand = command;
            string ID = dataGridView3.CurrentRow.Cells[0].Value.ToString();

            command.Parameters.Add("@a", MySqlDbType.VarChar).Value = ID;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            string Название_тура = dataSet.Tables[0].Rows[0]["Название_тура"].ToString();
            string Дата_начала = dataSet.Tables[0].Rows[0]["Дата_начала"].ToString();
            if (Дата_начала != "")
            {
                Дата_начала = DateTime.Parse(Дата_начала).ToString("dd.MM.yyyy");
            }
            else
            {
                Дата_начала = null;
            }
            string Дата_завершения = dataSet.Tables[0].Rows[0]["Дата_завершения"].ToString();
            if (Дата_завершения != "")
            {
                Дата_завершения = DateTime.Parse(Дата_завершения).ToString("dd.MM.yyyy");
            }
            else
            {
                Дата_завершения = null;
            }
            string Стоимость_тура = dataSet.Tables[0].Rows[0]["Стоимость_тура"].ToString();
            string Пункт_отправки = dataSet.Tables[0].Rows[0]["Пункт_отправки"].ToString();
            string Пункт_прибытия = dataSet.Tables[0].Rows[0]["Пункт_прибытия"].ToString();
            string Вид_тура = dataSet.Tables[0].Rows[0]["Вид_тура"].ToString();
            string id_клиента = dataSet.Tables[0].Rows[0]["id_клиента"].ToString();
            string id_гида = dataSet.Tables[0].Rows[0]["id_гида"].ToString();
            string id_мероприятия = dataSet.Tables[0].Rows[0]["id_мероприятия"].ToString();
            
          

            

            textBox1.Text = Название_тура;
            dateTimePicker1.Text = Дата_начала;
            dateTimePicker2.Text = Дата_завершения;
            textBox4.Text = Стоимость_тура;
            textBox5.Text = Пункт_отправки;
            textBox6.Text = Пункт_прибытия;
            comboBox1.Text = Вид_тура;
            textBox8.Text = id_мероприятия;
            textBox9.Text = id_гида;
            textBox10.Text = id_клиента;


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
    
    
