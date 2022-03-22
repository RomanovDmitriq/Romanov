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
    public partial class Form5 : Form
    {
        DB db = new DB();
        public Form5()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            MySqlDataAdapter adapterC = new MySqlDataAdapter();
            
            MySqlCommand commandC = new MySqlCommand("SELECT Фамилия FROM клиенты", db.GetConnection());
          

            adapterC.SelectCommand = commandC;
           

            DataSet dataSetC = new DataSet();
            
            adapterC.Fill(dataSetC, "клиенты");
            

            for (int i = 0; i < dataSetC.Tables["клиенты"].Rows.Count; i++)
            {
                comboBox1.Items.Add(dataSetC.Tables["клиенты"].Rows[i]["Фамилия"]);
            }


            DataTable table = new DataTable();
            try
            {
                dataGridView3.AllowUserToAddRows = false;
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT билеты.id_билета AS id, билеты.id_клиента, билеты.Дата_отправки, билеты.Дата_окончания, билеты.Пункт_отправки, билеты.Пункт_прибытия, билеты.Стоимость_билета AS Стоимость, билеты.Перевозчик, билеты.Номер, билеты.Место, билеты.Вид, билеты.Статус FROM билеты", db.GetConnection());
                adapter.SelectCommand = command;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "билеты");

                dataGridView3.DataSource = dataSet.Tables["билеты"];
                dataGridView3.AutoResizeColumns();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT билеты.id_билета AS id, билеты.id_клиента, билеты.Дата_отправки, билеты.Дата_окончания, билеты.Пункт_отправки, билеты.Пункт_прибытия, билеты.Стоимость_билета AS Стоимость, билеты.Перевозчик, билеты.Номер, билеты.Место, билеты.Вид, билеты.Статус FROM билеты", db.GetConnection());
                adapter.SelectCommand = command;

                string id_клиента = dataGridView3.CurrentRow.Cells[0].Value.ToString();

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("DELETE FROM `билеты` WHERE `id_билета` = @lU", db.GetConnection());
                command1.Parameters.Add("@lU", MySqlDbType.VarChar).Value = id_клиента;
                adapter1.SelectCommand = command1;

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "билеты");
                adapter1.Fill(dataSet, "билеты");
                dataSet.Tables["билеты"].Clear();
                adapter.Fill(dataSet, "билеты");

                dataGridView3.DataSource = dataSet.Tables["билеты"];
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
                DataTable tableC = new DataTable();
              
                MySqlDataAdapter adapterC = new MySqlDataAdapter();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT билеты.id_билета AS id, билеты.id_клиента, билеты.Дата_отправки, билеты.Дата_окончания, билеты.Пункт_отправки, билеты.Пункт_прибытия, билеты.Стоимость_билета AS Стоимость, билеты.Перевозчик, билеты.Номер, билеты.Место, билеты.Вид, билеты.Статус FROM билеты", db.GetConnection()); db.GetConnection();
                MySqlCommand commandC = new MySqlCommand("SELECT id_клиента  FROM клиенты WHERE Фамилия= @CT", db.GetConnection());
                adapter.SelectCommand = command;
                string id_клиента = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                commandC.Parameters.Add("@CT", MySqlDbType.VarChar).Value = id_клиента;
                adapterC.SelectCommand = commandC;
               
                adapterC.Fill(tableC);
                string id_билета = dataGridView3.CurrentRow.Cells[0].Value.ToString();
             
                string Дата_отправки = dateTimePicker1.Text;
                if (Дата_отправки != "")
                {
                    Дата_отправки = DateTime.Parse(Дата_отправки).ToString("yyyyMMdd");
                }
                else
                {
                    Дата_отправки = null;
                }
                string Дата_окончания = dateTimePicker2.Text;
                if (Дата_окончания != "")
                {
                    Дата_окончания = DateTime.Parse(Дата_окончания).ToString("yyyyMMdd");
                }
                else
                {
                    Дата_окончания = null;
                }
                string Пункт_отправки = textBox4.Text;
                string Пункт_прибытия = textBox5.Text;
                string Стоимость_билета = textBox6.Text;
                string Перевозчик = textBox7.Text;
                string Номер = textBox8.Text;
                string Место = textBox9.Text;
                string Вид = comboBox2.Items[comboBox1.SelectedIndex].ToString();
                string Статус = comboBox3.Items[comboBox1.SelectedIndex].ToString();

                int gen = tableC.Rows[0].Field<int>("id_клиента");
                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("UPDATE `билеты` SET  `id_билета` = @0U,`id_клиента` = @1U, `Дата_отправки` =  @2U ,  `Дата_окончания` = @3U,  `Пункт_отправки` = @4U,  `Пункт_прибытия` = @5U,  `Стоимость_билета` = @6U,  `Перевозчик` = @7U,  `Номер` = @8U,  `Место` = @9U,  `Вид` = @10U,  `Статус` = @11U WHERE `id_билета` = @0U", db.GetConnection());
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = gen;
                command1.Parameters.Add("@0U", MySqlDbType.VarChar).Value = id_билета;
                
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Дата_отправки;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = Дата_окончания;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = Пункт_отправки;
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = Пункт_прибытия;
                command1.Parameters.Add("@6U", MySqlDbType.VarChar).Value = Стоимость_билета;
                command1.Parameters.Add("@7U", MySqlDbType.VarChar).Value = Перевозчик;
                command1.Parameters.Add("@8U", MySqlDbType.VarChar).Value = Номер;
                command1.Parameters.Add("@9U", MySqlDbType.VarChar).Value = Место;
                command1.Parameters.Add("@10U", MySqlDbType.VarChar).Value = Вид;
                command1.Parameters.Add("@11U", MySqlDbType.VarChar).Value = Статус;


                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "билеты");

                adapter1.Fill(dataSet, "билеты");
                dataSet.Tables["билеты"].Clear();
                adapter.Fill(dataSet, "билеты");

                dataGridView3.DataSource = null;
                dataGridView3.DataSource = dataSet.Tables["билеты"];
                dataGridView3.AutoResizeColumns();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tableC = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlDataAdapter adapterC = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT билеты.id_билета AS id, билеты.id_клиента, билеты.Дата_отправки, билеты.Дата_окончания, билеты.Пункт_отправки, билеты.Пункт_прибытия, билеты.Стоимость_билета AS Стоимость, билеты.Перевозчик, билеты.Номер, билеты.Место, билеты.Вид, билеты.Статус FROM билеты", db.GetConnection());
                string id_клиента = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                MySqlCommand commandC = new MySqlCommand("SELECT id_клиента  FROM клиенты WHERE Фамилия= @CT", db.GetConnection());
                adapterC.SelectCommand = commandC;
                commandC.Parameters.Add("@CT", MySqlDbType.VarChar).Value = id_клиента;
                adapterC.Fill(tableC);
                string Дата_отправки = dateTimePicker1.Text;
                if (Дата_отправки != "")
                {
                    Дата_отправки = DateTime.Parse(Дата_отправки).ToString("yyyyMMdd");
                }
                else
                {
                    Дата_отправки = null;
                }
                string Дата_окончания = dateTimePicker2.Text;
                if (Дата_окончания != "")
                {
                    Дата_окончания = DateTime.Parse(Дата_окончания).ToString("yyyyMMdd");
                }
                else
                {
                    Дата_окончания = null;
                }
                string Пункт_отправки = textBox4.Text;
                string Пункт_прибытия = textBox5.Text;
                string Стоимость_билета = textBox6.Text;
                string Перевозчик = textBox7.Text;
                string Номер = textBox8.Text;
                string Место = textBox9.Text;
                string Вид = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                string Статус = comboBox3.Items[comboBox3.SelectedIndex].ToString();

                int gen = tableC.Rows[0].Field<int>("id_клиента");

                adapter.SelectCommand = command;

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("insert `билеты` ( `id_клиента`, `Дата_отправки`,`Дата_окончания`, `Пункт_отправки`,`Пункт_прибытия`, `Стоимость_билета`,`Перевозчик`, `Номер`,`Место`, `Вид`, `Статус`) VALUES (@1U, @2U,@3U, @4U,@5U, @6U,@7U, @8U,@9U, @10U, @11U)", db.GetConnection());

                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = gen;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Дата_отправки;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = Дата_окончания;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = Пункт_отправки;     
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = Пункт_прибытия;
                command1.Parameters.Add("@6U", MySqlDbType.VarChar).Value = Стоимость_билета;
                command1.Parameters.Add("@7U", MySqlDbType.VarChar).Value = Перевозчик;
                command1.Parameters.Add("@8U", MySqlDbType.VarChar).Value = Номер;
                command1.Parameters.Add("@9U", MySqlDbType.VarChar).Value = Место;
                command1.Parameters.Add("@10U", MySqlDbType.VarChar).Value = Вид;
                command1.Parameters.Add("@11U", MySqlDbType.VarChar).Value = Статус;

                adapter1.SelectCommand = command1;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "билеты");

                adapter1.Fill(dataSet, "билеты");
                dataSet.Tables["билеты"].Clear();
                adapter.Fill(dataSet, "билеты");

                dataGridView3.DataSource = null;
                dataGridView3.DataSource = dataSet.Tables["билеты"];
                dataGridView3.AutoResizeColumns();

        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT билеты.id_билета, билеты.id_клиента, билеты.Дата_отправки, билеты.Дата_окончания, билеты.Пункт_отправки, билеты.Пункт_прибытия, билеты.Стоимость_билета, билеты.Перевозчик, билеты.Номер, билеты.Место, билеты.Вид, билеты.Статус FROM билеты WHERE id_билета=@a", db.GetConnection());  
            adapter.SelectCommand = command;
            string ID = dataGridView3.CurrentRow.Cells[0].Value.ToString();

            command.Parameters.Add("@a", MySqlDbType.VarChar).Value = ID;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);



            string id_клиента = dataSet.Tables[0].Rows[0]["id_клиента"].ToString(); 
            string Дата_отправки = dataSet.Tables[0].Rows[0]["Дата_отправки"].ToString();
            if (Дата_отправки != "")
            {
                Дата_отправки = DateTime.Parse(Дата_отправки).ToString("dd.MM.yyyy");
            }
            else
            {
                Дата_отправки = null;
            }
            string Дата_окончания = dataSet.Tables[0].Rows[0]["Дата_окончания"].ToString();
            if (Дата_окончания != "")
            {
                Дата_окончания = DateTime.Parse(Дата_окончания).ToString("dd.MM.yyyy");
            }
            else
            {
                Дата_окончания = null;
            }
            string Пункт_отправки = dataSet.Tables[0].Rows[0]["Пункт_отправки"].ToString();
            string Пункт_прибытия = dataSet.Tables[0].Rows[0]["Пункт_прибытия"].ToString();
            string Стоимость_билета = dataSet.Tables[0].Rows[0]["Стоимость_билета"].ToString();
            string Перевозчик = dataSet.Tables[0].Rows[0]["Перевозчик"].ToString();
            string Номер = dataSet.Tables[0].Rows[0]["Номер"].ToString();
            string Место = dataSet.Tables[0].Rows[0]["Место"].ToString();
            string Вид = dataSet.Tables[0].Rows[0]["Вид"].ToString();
            string Статус = dataSet.Tables[0].Rows[0]["Статус"].ToString();

            comboBox1.Text = id_клиента;
            dateTimePicker1.Text = Дата_отправки;
            dateTimePicker2.Text = Дата_окончания;
            textBox4.Text = Пункт_отправки;
            textBox5.Text = Пункт_прибытия;
            textBox6.Text = Стоимость_билета;
            textBox7.Text = Перевозчик;
            textBox8.Text = Номер;
            textBox9.Text = Место;
            comboBox2.Text = Вид;
            comboBox3.Text = Статус;
        }



    }
}
