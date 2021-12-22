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
    public partial class Form4 : Form
    {
        DB db = new DB();
        public Form4()
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

                MySqlCommand command = new MySqlCommand("SELECT мероприятия.id_мероприятия AS id, мероприятия.Название_мероприятия AS Название, мероприятия.Описание AS Описание FROM мероприятия", db.GetConnection());
                adapter.SelectCommand = command;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "мероприятия");

                dataGridView2.DataSource = dataSet.Tables["мероприятия"];
                dataGridView2.AutoResizeColumns();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT мероприятия.id_мероприятия AS id, мероприятия.Название_мероприятия AS Название, мероприятия.Описание AS Описание  FROM мероприятия", db.GetConnection());

                string Название_мероприятия = textBox1.Text;
                string Описание = textBox2.Text;
                

                adapter.SelectCommand = command;

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("insert `мероприятия` ( `Название_мероприятия`, `Описание`) VALUES (@1U, @2U)", db.GetConnection());

                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = Название_мероприятия;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Описание;
              
                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "мероприятия");

                adapter1.Fill(dataSet, "мероприятия");
                dataSet.Tables["мероприятия"].Clear();
                adapter.Fill(dataSet, "мероприятия");
                
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = dataSet.Tables["мероприятия"];
                dataGridView2.AutoResizeColumns();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT мероприятия.id_мероприятия AS id, мероприятия.Название_мероприятия AS Название, мероприятия.Описание AS Описание  FROM мероприятия", db.GetConnection());
                adapter.SelectCommand = command;

                string id_клиента = dataGridView2.CurrentRow.Cells[0].Value.ToString();

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("DELETE FROM `мероприятия` WHERE `id_мероприятия` = @lU", db.GetConnection());
                command1.Parameters.Add("@lU", MySqlDbType.VarChar).Value = id_клиента;
                adapter1.SelectCommand = command1;

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "мероприятия");
                adapter1.Fill(dataSet, "мероприятия");
                dataSet.Tables["мероприятия"].Clear();
                adapter.Fill(dataSet, "мероприятия");
               
                dataGridView2.DataSource = dataSet.Tables["мероприятия"];
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

                MySqlCommand command = new MySqlCommand("SELECT мероприятия.id_мероприятия AS id, мероприятия.Название_мероприятия AS Название, мероприятия.Описание AS Описание  FROM мероприятия", db.GetConnection());
                adapter.SelectCommand = command;

                string id_мероприятия = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                string Название_мероприятия = textBox1.Text;
                string Описание = textBox2.Text;


                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("UPDATE `мероприятия` SET `id_мероприятия` = @0U, `Название_мероприятия` =  @1U ,  `Описание` = @2U WHERE `id_мероприятия` = @0U", db.GetConnection());
                command1.Parameters.Add("@0U", MySqlDbType.VarChar).Value = id_мероприятия;
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = Название_мероприятия;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Описание;
               

                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "мероприятия");

                adapter1.Fill(dataSet, "мероприятия");
                dataSet.Tables["мероприятия"].Clear();
                adapter.Fill(dataSet, "мероприятия");
                
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = dataSet.Tables["мероприятия"];
                dataGridView2.AutoResizeColumns();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form4_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT мероприятия.id_мероприятия, мероприятия.Название_мероприятия , мероприятия.Описание  FROM мероприятия WHERE мероприятия.id_мероприятия=@a", db.GetConnection());
            adapter.SelectCommand = command;
            string ID = dataGridView2.CurrentRow.Cells[0].Value.ToString();

            command.Parameters.Add("@a", MySqlDbType.VarChar).Value = ID;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            string Название_мероприятия = dataSet.Tables[0].Rows[0]["Название_мероприятия"].ToString();
            string Описание = dataSet.Tables[0].Rows[0]["Описание"].ToString();
            
            

            if (ID == null)
            {
                textBox1.Text = null;
                textBox2.Text = null;  
            }

            textBox1.Text = Название_мероприятия;
            textBox2.Text = Описание;

        }
    }
    
}
