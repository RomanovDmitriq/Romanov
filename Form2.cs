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
    public partial class Form2 : Form
    {

        DB db = new DB();
        public Form2()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            DB db = new DB();

            DataTable table = new DataTable();
            try
            {
                dataGridView1.AllowUserToAddRows = false;
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT клиенты.id_клиента AS id, клиенты.Паспортные_данные AS Паспорт, клиенты.Фамилия AS Фамилия, клиенты.Имя AS Имя, клиенты.Отчество AS Отчество, клиенты.Пол AS Пол, клиенты.Дата_рождения AS Дата_рождения, клиенты.Номер_клиента AS Номер, клиенты.Почта_клиента AS Почта  FROM клиенты", db.GetConnection());
                adapter.SelectCommand = command;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "клиенты");

                dataGridView1.DataSource = dataSet.Tables["клиенты"];
                dataGridView1.AutoResizeColumns();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            LoadData();
        }
       

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }


                
              
        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT клиенты.id_клиента AS id, клиенты.Паспортные_данные AS Паспорт, клиенты.Фамилия AS Фамилия, клиенты.Имя AS Имя, клиенты.Отчество AS Отчество, клиенты.Пол AS Пол, клиенты.Дата_рождения AS Дата_рождения, клиенты.Номер_клиента AS Номер, клиенты.Почта_клиента AS Почта  FROM клиенты", db.GetConnection());

                string Паспортные_данные = textBox1.Text;
                string Фамилия = textBox2.Text;
                string Имя = textBox3.Text;
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
                string Номер_клиента = textBox7.Text;
                string Почта_клиента = textBox8.Text;

                adapter.SelectCommand = command;

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("insert `клиенты` ( `Паспортные_данные`, `Фамилия`, `Имя`, `Отчество`, `Пол`, `Дата_рождения`, `Номер_клиента`, `Почта_клиента`) VALUES (@1U, @2U, @3U, @4U,@5U, @6U, @7U, @8U)", db.GetConnection());

                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = Паспортные_данные;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Фамилия;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = Имя;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = Отчество;
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = Пол;
                command1.Parameters.Add("@6U", MySqlDbType.VarChar).Value = Дата_рождения;
                command1.Parameters.Add("@7U", MySqlDbType.VarChar).Value = Номер_клиента;
                command1.Parameters.Add("@8U", MySqlDbType.VarChar).Value = Почта_клиента;


                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "клиенты");

                adapter1.Fill(dataSet, "клиенты");
                dataSet.Tables["клиенты"].Clear();
                adapter.Fill(dataSet, "клиенты");
                
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataSet.Tables["клиенты"];
                dataGridView1.AutoResizeColumns();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                
                try
                {

                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    MySqlCommand command = new MySqlCommand("SELECT клиенты.id_клиента AS id, клиенты.Паспортные_данные AS Паспорт, клиенты.Фамилия AS Фамилия, клиенты.Имя AS Имя, клиенты.Отчество AS Отчество, клиенты.Пол AS Пол, клиенты.Дата_рождения AS Дата_рождения, клиенты.Номер_клиента AS Номер, клиенты.Почта_клиента AS Почта  FROM клиенты", db.GetConnection());
                    adapter.SelectCommand = command;

                    string id_клиента = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                    MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                    MySqlCommand command1 = new MySqlCommand("DELETE FROM `клиенты` WHERE `id_клиента` = @lU", db.GetConnection());
                    command1.Parameters.Add("@lU", MySqlDbType.VarChar).Value = id_клиента;
                    adapter1.SelectCommand = command1;
        
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "клиенты");
                    adapter1.Fill(dataSet, "клиенты");
                    dataSet.Tables["клиенты"].Clear();
                    adapter.Fill(dataSet, "клиенты");
                    
                    dataGridView1.DataSource = dataSet.Tables["клиенты"];
                    dataGridView1.AutoResizeColumns();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT клиенты.id_клиента AS id, клиенты.Паспортные_данные AS Паспорт, клиенты.Фамилия AS Фамилия, клиенты.Имя AS Имя, клиенты.Отчество AS Отчество, клиенты.Пол AS Пол, клиенты.Дата_рождения AS Дата_рождения, клиенты.Номер_клиента AS Номер, клиенты.Почта_клиента AS Почта  FROM клиенты", db.GetConnection());
                adapter.SelectCommand = command;

                string id_клиента = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string Паспортные_данные = textBox1.Text;
                string Фамилия = textBox2.Text;
                string Имя = textBox3.Text;
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
                string Номер_клиента = textBox7.Text;
                string Почта_клиента = textBox8.Text;

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("UPDATE `клиенты` SET `id_клиента` = @0U, `Паспортные_данные` =  @1U ,  `Фамилия` = @2U  , `Имя`=@3U, `Отчество` = @4U, `Пол` = @5U, `Дата_рождения` = @6U, `Номер_клиента` = @7U, `Почта_клиента` = @8U WHERE `id_клиента` = @0U", db.GetConnection());
                command1.Parameters.Add("@0U", MySqlDbType.VarChar).Value = id_клиента;
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = Паспортные_данные;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Фамилия;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = Имя;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = Отчество;
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = Пол;
                command1.Parameters.Add("@6U", MySqlDbType.VarChar).Value = Дата_рождения;
                command1.Parameters.Add("@7U", MySqlDbType.VarChar).Value = Номер_клиента;
                command1.Parameters.Add("@8U", MySqlDbType.VarChar).Value = Почта_клиента;

                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "клиенты");

                adapter1.Fill(dataSet, "клиенты");
                dataSet.Tables["клиенты"].Clear();
                adapter.Fill(dataSet, "клиенты");
                
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataSet.Tables["клиенты"];
                dataGridView1.AutoResizeColumns();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT клиенты.id_клиента, клиенты.Паспортные_данные, клиенты.Фамилия, клиенты.Имя, клиенты.Отчество, клиенты.Пол, клиенты.Дата_рождения, клиенты.Номер_клиента, клиенты.Почта_клиента FROM клиенты WHERE клиенты.id_клиента = @a", db.GetConnection());
            adapter.SelectCommand = command;
            string ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
            command.Parameters.Add("@a", MySqlDbType.VarChar).Value = ID;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            string Паспортные_данные = dataSet.Tables[0].Rows[0]["Паспортные_данные"].ToString(); 
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
            string Номер_клиента = dataSet.Tables[0].Rows[0]["Номер_клиента"].ToString();
            string Почта_клиента = dataSet.Tables[0].Rows[0]["Почта_клиента"].ToString();

          
            
                textBox1.Text = Паспортные_данные;
                textBox2.Text = Фамилия;
                textBox3.Text = Имя;
                textBox4.Text = Отчество;
                comboBox1.Text = Пол;
                dateTimePicker1.Text = Дата_рождения;
                textBox7.Text = Номер_клиента;
                textBox8.Text = Почта_клиента;
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
