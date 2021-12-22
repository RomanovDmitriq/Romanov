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
    public partial class Form6 : Form
    {
        DB db = new DB();
        public Form6()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            MySqlDataAdapter adapterC = new MySqlDataAdapter();
            MySqlDataAdapter adapterG = new MySqlDataAdapter();
            MySqlCommand commandC = new MySqlCommand("SELECT Название_тура FROM туры", db.GetConnection());
            MySqlCommand commandG = new MySqlCommand("SELECT Название_гостиницы  FROM гостиницы", db.GetConnection());

            adapterC.SelectCommand = commandC;
            adapterG.SelectCommand = commandG;

            DataSet dataSetC = new DataSet();
            DataSet dataSetG = new DataSet();
            adapterC.Fill(dataSetC, "туры");
            adapterG.Fill(dataSetG, "гостиницы");

            for (int i = 0; i < dataSetC.Tables["туры"].Rows.Count; i++)
            {
                comboBox1.Items.Add(dataSetC.Tables["туры"].Rows[i]["Название_тура"]);
            }

            for (int i = 0; i < dataSetG.Tables["гостиницы"].Rows.Count; i++)
            {
                comboBox3.Items.Add(dataSetG.Tables["гостиницы"].Rows[i]["Название_гостиницы"]);
            }
        

        DataTable table = new DataTable();
            try
            {
                dataGridView3.AllowUserToAddRows = false;
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT ваучеры.id_брони AS id, ваучеры.id_тура, ваучеры.Дата_заезда, ваучеры.Тип_размещения AS Размещение, ваучеры.Колво_ночей, ваучеры.Колво_гостей AS Гости, ваучеры.Стоимость_номера AS Стоимость, ваучеры.Фамилия, ваучеры.Имя, ваучеры.Отчество, ваучеры.Номер_клиента, ваучеры.id_гостиницы FROM ваучеры", db.GetConnection());
                adapter.SelectCommand = command;

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "ваучеры");

                dataGridView3.DataSource = dataSet.Tables["ваучеры"];
                dataGridView3.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            }
        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tableC = new DataTable();
                DataTable tableG = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlDataAdapter adapterC = new MySqlDataAdapter();
                MySqlDataAdapter adapterG = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT ваучеры.id_брони AS id, ваучеры.id_тура, ваучеры.Дата_заезда, ваучеры.Тип_размещения AS Размещение, ваучеры.Колво_ночей, ваучеры.Колво_гостей AS Гости, ваучеры.Стоимость_номера AS Стоимость, ваучеры.Фамилия, ваучеры.Имя, ваучеры.Отчество, ваучеры.Номер_клиента, ваучеры.id_гостиницы FROM ваучеры", db.GetConnection());

                string id_тура = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string id_гостиницы = comboBox3.Items[comboBox3.SelectedIndex].ToString();

                MySqlCommand commandC = new MySqlCommand("SELECT id_тура FROM туры WHERE Название_тура = @CT", db.GetConnection());
                MySqlCommand commandG = new MySqlCommand("SELECT id_гостиницы FROM гостиницы WHERE Название_гостиницы = @GT", db.GetConnection());

                adapterC.SelectCommand = commandC;
                adapterG.SelectCommand = commandG;

                commandC.Parameters.Add("@CT", MySqlDbType.VarChar).Value = id_тура;
                commandG.Parameters.Add("@GT", MySqlDbType.VarChar).Value = id_гостиницы;

                adapterC.Fill(tableC);
                adapterG.Fill(tableG);

                string Дата_заезда = dateTimePicker1.Text;
                if (Дата_заезда != "")
                {
                    Дата_заезда = DateTime.Parse(Дата_заезда).ToString("yyyyMMdd");
                }
                else
                {
                    Дата_заезда = null;
                }

                string Тип_размещения = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                string Колво_ночей = textBox4.Text;
                string Колво_гостей = textBox5.Text;
                string Стоимость_номера = textBox6.Text;
                string Фамилия = textBox7.Text;
                string Имя = textBox8.Text;
                string Отчество = textBox9.Text;
                string Номер_клиента = textBox10.Text;

                int cntry = tableC.Rows[0].Field<int>("id_тура");
                int gen = tableG.Rows[0].Field<int>("id_гостиницы");

                adapter.SelectCommand = command;

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("insert `ваучеры` ( `id_тура`, `Дата_заезда`,`Тип_размещения`, `Колво_ночей`,`Колво_гостей`, `Стоимость_номера`,`Фамилия`, `Имя`,`Отчество`, `Номер_клиента`, `id_гостиницы`) VALUES (@1U, @2U,@3U, @4U,@5U, @6U,@7U, @8U,@9U, @10U, @11U)", db.GetConnection());
                
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = cntry;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Дата_заезда;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = Тип_размещения;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = Колво_ночей;
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = Колво_гостей;
                command1.Parameters.Add("@6U", MySqlDbType.VarChar).Value = Стоимость_номера;
                command1.Parameters.Add("@7U", MySqlDbType.VarChar).Value = Фамилия;
                command1.Parameters.Add("@8U", MySqlDbType.VarChar).Value = Имя;
                command1.Parameters.Add("@9U", MySqlDbType.VarChar).Value = Отчество;
                command1.Parameters.Add("@10U", MySqlDbType.VarChar).Value = Номер_клиента;
                command1.Parameters.Add("@11U", MySqlDbType.VarChar).Value = gen;

                adapter1.SelectCommand = command1;                          
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "ваучеры");
                adapter1.Fill(dataSet, "ваучеры");
                dataSet.Tables["ваучеры"].Clear();
                adapter.Fill(dataSet, "ваучеры");        
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = dataSet.Tables["ваучеры"];
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
                DataTable tableC = new DataTable();
                DataTable tableG = new DataTable();
               
                MySqlDataAdapter adapterC = new MySqlDataAdapter();
                MySqlDataAdapter adapterG = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT ваучеры.id_брони AS id, ваучеры.id_тура, ваучеры.Дата_заезда, ваучеры.Тип_размещения AS Размещение, ваучеры.Колво_ночей, ваучеры.Колво_гостей AS Гости, ваучеры.Стоимость_номера AS Стоимость, ваучеры.Фамилия, ваучеры.Имя, ваучеры.Отчество, ваучеры.Номер_клиента, ваучеры.id_гостиницы FROM ваучеры", db.GetConnection());
                adapter.SelectCommand = command;

                string id_тура = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string id_гостиницы = comboBox3.Items[comboBox3.SelectedIndex].ToString();

                MySqlCommand commandC = new MySqlCommand("SELECT id_тура FROM туры WHERE Название_тура = @CT", db.GetConnection());
                MySqlCommand commandG = new MySqlCommand("SELECT id_гостиницы FROM гостиницы WHERE Название_гостиницы = @GT", db.GetConnection());

                adapterC.SelectCommand = commandC;
                adapterG.SelectCommand = commandG;

                commandC.Parameters.Add("@CT", MySqlDbType.VarChar).Value = id_тура;
                commandG.Parameters.Add("@GT", MySqlDbType.VarChar).Value = id_гостиницы;

                adapterC.Fill(tableC);
                adapterG.Fill(tableG);
                string id_брони = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                string Дата_заезда = dateTimePicker1.Text;
                if (Дата_заезда != "")
                {
                    Дата_заезда = DateTime.Parse(Дата_заезда).ToString("yyyyMMdd");
                }
                else
                {
                    Дата_заезда = null;
                }

                string Тип_размещения = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                string Колво_ночей = textBox4.Text;
                string Колво_гостей = textBox5.Text;
                string Стоимость_номера = textBox6.Text;
                string Фамилия = textBox7.Text;
                string Имя = textBox8.Text;
                string Отчество = textBox9.Text;
                string Номер_клиента = textBox10.Text;

                int cntry = tableC.Rows[0].Field<int>("id_тура");
                int gen = tableG.Rows[0].Field<int>("id_гостиницы");

               

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("UPDATE `ваучеры` SET `id_брони`= @0U, `id_тура` = @1U, `Дата_заезда` =  @2U ,  `Тип_размещения` = @3U,  `Колво_ночей` = @4U,  `Колво_гостей` = @5U,  `Стоимость_номера` = @6U,  `Фамилия` = @7U,  `Имя` = @8U,  `Отчество` = @9U,  `Номер_клиента` = @10U,  `id_гостиницы` = @11U WHERE `id_брони` = @0U", db.GetConnection());

                command1.Parameters.Add("@0U", MySqlDbType.VarChar).Value = id_брони;
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = cntry;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = Дата_заезда;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = Тип_размещения;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = Колво_ночей;
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = Колво_гостей;
                command1.Parameters.Add("@6U", MySqlDbType.VarChar).Value = Стоимость_номера;
                command1.Parameters.Add("@7U", MySqlDbType.VarChar).Value = Фамилия;
                command1.Parameters.Add("@8U", MySqlDbType.VarChar).Value = Имя;
                command1.Parameters.Add("@9U", MySqlDbType.VarChar).Value = Отчество;
                command1.Parameters.Add("@10U", MySqlDbType.VarChar).Value = Номер_клиента;
                command1.Parameters.Add("@11U", MySqlDbType.VarChar).Value = gen;

                adapter1.SelectCommand = command1;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "ваучеры");
                adapter1.Fill(dataSet, "ваучеры");
                dataSet.Tables["ваучеры"].Clear();
                adapter.Fill(dataSet, "ваучеры");
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = dataSet.Tables["ваучеры"];
                dataGridView3.AutoResizeColumns();
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

                MySqlCommand command = new MySqlCommand("SELECT ваучеры.id_брони AS id, ваучеры.id_тура, ваучеры.Дата_заезда, ваучеры.Тип_размещения AS Размещение, ваучеры.Колво_ночей, ваучеры.Колво_гостей AS Гости, ваучеры.Стоимость_номера AS Стоимость, ваучеры.Фамилия, ваучеры.Имя, ваучеры.Отчество, ваучеры.Номер_клиента, ваучеры.id_гостиницы FROM ваучеры", db.GetConnection());

                string id_брони = dataGridView3.CurrentRow.Cells[0].Value.ToString();

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("DELETE FROM `ваучеры` WHERE `id_брони` = @lU", db.GetConnection());
                command1.Parameters.Add("@lU", MySqlDbType.VarChar).Value = id_брони;
                adapter1.SelectCommand = command1;
                adapter.SelectCommand = command;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "ваучеры");
                adapter1.Fill(dataSet, "ваучеры");
                dataSet.Tables["ваучеры"].Clear();
                adapter.Fill(dataSet, "ваучеры");

                dataGridView3.DataSource = dataSet.Tables["ваучеры"];
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

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataTable tableC = new DataTable();
            DataTable tableG = new DataTable();
            MySqlDataAdapter adapterC = new MySqlDataAdapter();
            MySqlDataAdapter adapterG = new MySqlDataAdapter();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT ваучеры.id_брони, ваучеры.id_тура, ваучеры.Дата_заезда, ваучеры.Тип_размещения, ваучеры.Колво_ночей, ваучеры.Колво_гостей, ваучеры.Стоимость_номера, ваучеры.Фамилия, ваучеры.Имя, ваучеры.Отчество, ваучеры.Номер_клиента, ваучеры.id_гостиницы FROM ваучеры WHERE id_брони=@a ", db.GetConnection());
            MySqlCommand commandC = new MySqlCommand("SELECT Название_тура FROM туры WHERE id_тура = @CT", db.GetConnection());
            MySqlCommand commandG = new MySqlCommand("SELECT Название_гостиницы FROM гостиницы WHERE id_гостиницы = @GT", db.GetConnection());
            adapter.SelectCommand = command;
            string ID = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            
            command.Parameters.Add("@a", MySqlDbType.VarChar).Value = ID;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            string id_тура = dataSet.Tables[0].Rows[0]["id_тура"].ToString();
            string id_гостиницы = dataSet.Tables[0].Rows[0]["id_гостиницы"].ToString();
            string Дата_заезда = dataSet.Tables[0].Rows[0]["Дата_заезда"].ToString();
            if (Дата_заезда != "")
            {
                Дата_заезда = DateTime.Parse(Дата_заезда).ToString("dd.MM.yyyy");
            }
            else
            {
                Дата_заезда = null;
            }

            string Тип_размещения = dataSet.Tables[0].Rows[0]["Тип_размещения"].ToString();
            string Колво_ночей = dataSet.Tables[0].Rows[0]["Колво_ночей"].ToString();
            string Колво_гостей = dataSet.Tables[0].Rows[0]["Колво_гостей"].ToString();
            string Стоимость_номера = dataSet.Tables[0].Rows[0]["Стоимость_номера"].ToString();
            string Фамилия = dataSet.Tables[0].Rows[0]["Фамилия"].ToString();
            string Имя = dataSet.Tables[0].Rows[0]["Имя"].ToString();
            string Отчество = dataSet.Tables[0].Rows[0]["Отчество"].ToString();
            string Номер_клиента = dataSet.Tables[0].Rows[0]["Номер_клиента"].ToString();

            


            comboBox1.Text = id_тура;
            dateTimePicker1.Text = Дата_заезда;
            comboBox2.Text = Тип_размещения;
            textBox4.Text = Колво_ночей;
            textBox5.Text = Колво_гостей;
            textBox6.Text = Стоимость_номера;
            textBox7.Text = Фамилия;
            textBox8.Text = Имя;
            textBox9.Text = Отчество;
            textBox10.Text = Номер_клиента;
            comboBox3.Text = id_гостиницы;
        }
    }
    }

