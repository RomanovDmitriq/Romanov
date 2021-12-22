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
    public partial class Form7 : Form
    {
        DB db = new DB();
        public Form7()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            

            DataTable table = new DataTable();
            try
            {
                dataGridView2.AllowUserToAddRows = false;
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT гиды.id_гида AS id, гиды.Фамилия, гиды.Имя, гиды.Отчество, гиды.Пол, гиды.Дата_рождения, гиды.Номер_гида AS Номер, гиды.Почта_гида AS Почта  FROM гиды", db.GetConnection());
                adapter.SelectCommand = command;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "гиды");

                dataGridView2.DataSource = dataSet.Tables["гиды"];
                dataGridView2.AutoResizeColumns();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT гиды.id_гида AS id, гиды.Фамилия, гиды.Имя, гиды.Отчество, гиды.Пол, гиды.Дата_рождения, гиды.Номер_гида AS Номер, гиды.Почта_гида AS Почта  FROM гиды", db.GetConnection());
                string Фамилия = textBox1.Text;
                string Имя = textBox2.Text;
                string Отчество = textBox4.Text;
                string Пол = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string Дата_рождения = dateTimePicker1.Text;
                if (Дата_рождения != "")
                {
                    Дата_рождения = DateTime.Parse(Дата_рождения).ToString("yyyyMMdd");
                }
                else
                {
                    Дата_рождения = null;
                }
                string Номер_гида = textBox5.Text;
                string Почта_гида = textBox7.Text;
                


                adapter.SelectCommand = command;

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("insert `гиды` ( `Фамилия`, `Имя`, `Отчество`, `Пол`, `Дата_рождения`, `Номер_гида`, `Почта_гида`) VALUES (@1U, @2U, @3U, @4U, @5U, @6U, @7U)", db.GetConnection());

                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = Фамилия;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Имя;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = Отчество;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = Пол;
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = Дата_рождения;
                command1.Parameters.Add("@6U", MySqlDbType.VarChar).Value = Номер_гида;
                command1.Parameters.Add("@7U", MySqlDbType.VarChar).Value = Почта_гида;

                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "гиды");

                adapter1.Fill(dataSet, "гиды");
                dataSet.Tables["гиды"].Clear();
                adapter.Fill(dataSet, "гиды");
                
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = dataSet.Tables["гиды"];
                dataGridView2.AutoResizeColumns();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT гиды.id_гида AS id, гиды.Фамилия, гиды.Имя, гиды.Отчество, гиды.Пол, гиды.Дата_рождения, гиды.Номер_гида AS Номер, гиды.Почта_гида AS Почта  FROM гиды", db.GetConnection());
                adapter.SelectCommand = command;

                string id_гида = dataGridView2.CurrentRow.Cells[0].Value.ToString();

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("DELETE FROM `гиды` WHERE `id_гида` = @lU", db.GetConnection());
                command1.Parameters.Add("@lU", MySqlDbType.VarChar).Value = id_гида;
                adapter1.SelectCommand = command1;

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "гиды");
                adapter1.Fill(dataSet, "гиды");
                dataSet.Tables["гиды"].Clear();
                adapter.Fill(dataSet, "гиды");
               
                dataGridView2.DataSource = dataSet.Tables["гиды"];
                dataGridView2.AutoResizeColumns();


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

                MySqlCommand command = new MySqlCommand("SELECT гиды.id_гида AS id, гиды.Фамилия, гиды.Имя, гиды.Отчество, гиды.Пол, гиды.Дата_рождения, гиды.Номер_гида AS Номер, гиды.Почта_гида AS Почта  FROM гиды", db.GetConnection());
                adapter.SelectCommand = command;

                string id_гида = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                string Фамилия = textBox1.Text;
                string Имя = textBox2.Text;
                string Отчество = textBox4.Text;
                string Пол = comboBox1.Text;
                string Дата_рождения = dateTimePicker1.Text;
                if (Дата_рождения != "")
                {
                    Дата_рождения = DateTime.Parse(Дата_рождения).ToString("yyyyMMdd");
                }
                else
                {
                    Дата_рождения = null;
                }
                string Номер_гида = textBox5.Text;
                string Почта_гида = textBox7.Text;


                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("UPDATE `гиды` SET `id_гида` = @0U, `Фамилия` =  @1U ,  `Имя` = @2U,  `Отчество` = @3U,  `Пол` = @4U,  `Дата_рождения` = @5U,  `Номер_гида` = @6U,  `Почта_гида` = @7U WHERE `id_гида` = @0U", db.GetConnection());
                command1.Parameters.Add("@0U", MySqlDbType.VarChar).Value = id_гида;
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = Фамилия;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Имя;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = Отчество;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = Пол;
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = Дата_рождения;
                command1.Parameters.Add("@6U", MySqlDbType.VarChar).Value = Номер_гида;
                command1.Parameters.Add("@7U", MySqlDbType.VarChar).Value = Почта_гида;


                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "гиды");

                adapter1.Fill(dataSet, "гиды");
                dataSet.Tables["гиды"].Clear();
                adapter.Fill(dataSet, "гиды");
                
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = dataSet.Tables["гиды"];
                dataGridView2.AutoResizeColumns();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT гиды.id_гида, гиды.Фамилия, гиды.Имя, гиды.Отчество, гиды.Пол, гиды.Дата_рождения, гиды.Номер_гида, гиды.Почта_гида FROM гиды WHERE гиды.id_гида=@a", db.GetConnection());
            adapter.SelectCommand = command;
            string ID = dataGridView2.CurrentRow.Cells[0].Value.ToString();

            command.Parameters.Add("@a", MySqlDbType.VarChar).Value = ID;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            string Фамилия = dataSet.Tables[0].Rows[0]["Фамилия"].ToString();
            string Имя = dataSet.Tables[0].Rows[0]["Имя"].ToString();
            string Отчество = dataSet.Tables[0].Rows[0]["Отчество"].ToString();
            string Пол = dataSet.Tables[0].Rows[0]["Пол"].ToString();
            string Дата_рождения = dataSet.Tables[0].Rows[0]["Дата_рождения"].ToString();
            if (Дата_рождения != "")
            {
                Дата_рождения = DateTime.Parse(Дата_рождения).ToString("dd.MM.yyyy");
            }
            else
            {
                Дата_рождения = null;
            }
            string Номер_гида = dataSet.Tables[0].Rows[0]["Номер_гида"].ToString();
            string Почта_гида = dataSet.Tables[0].Rows[0]["Почта_гида"].ToString();

            textBox1.Text = Фамилия;
            textBox2.Text = Имя;
            comboBox1.Text = Пол;
            textBox4.Text = Отчество;
            textBox5.Text = Номер_гида;
            dateTimePicker1.Text = Дата_рождения;
            textBox7.Text = Почта_гида;

        }
    }
    }
    

