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

namespace project2test
{
    public partial class Createticket : Form
    {
        string[] status_seat = { "", "", "", "", "", "", "", "", "", "" };
        
        public Createticket()
        {
            InitializeComponent();
        }

        private void Createticket_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=user");
            try 
            {
                connection.Open();
                string sql = "SELECT * FROM seat";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while(reader.Read())
                {
                    status_seat[i] = reader.GetString("status");
                    i = i + 1;
                }
                connection.Close();
                if(status_seat[0] == "")
                {
                    comboBox2.Items.Add("A01");
                    
                }
                if(status_seat[1] == "")
                {
                    comboBox2.Items.Add("A02");
                }
                if(status_seat[2] == "")
                {
                    comboBox2.Items.Add("A03");

                }
                if(status_seat[3] == "")
                {
                    comboBox2.Items.Add("A04");
                }
                if(status_seat[4] == "")
                {
                    comboBox2.Items.Add("A05");

                }
                if(status_seat[5] == "")
                {
                    comboBox2.Items.Add("A06");
                }
                if(status_seat[6] == "")
                {
                    comboBox2.Items.Add("A07");

                }
                if (status_seat[7] == "")
                {
                    comboBox2.Items.Add("A08");
                }
                if(status_seat[8] == "")
                {
                    comboBox2.Items.Add("A09");

                }
                if(status_seat[9] == "")
                {
                    comboBox2.Items.Add("A10");
                }



            }
            catch
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเชื่อมต่อฐานข้อมูลที่นั่ง");
            }

           
            
            

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int rakabus = 500;
            int food = 0;
            int drink = 0;
            int snack = 0;
            int special;
            int sum = 0;

            if(checkBox1.Checked)
            {
                food = 100;
            }
            if(checkBox2.Checked)
            {
                drink = 50;
            }
            if(checkBox3.Checked)
            {
                snack = 30;
            }

            special = food + drink + snack;
            sum =  rakabus + special; 

            textBox3.Text = sum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Detailticket dtfrm = new Detailticket();
            dtfrm.textBox1.Text = textBox1.Text;
            dtfrm.textBox2.Text = label9.Text;
            dtfrm.textBox3.Text = comboBox2.Text;
            dtfrm.textBox4.Text = textBox3.Text;
            dtfrm.textBox5.Text = label10.Text;
            dtfrm.textBox6.Text = label11.Text;
            dtfrm.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm loginfrm = new LoginForm();
            loginfrm.Show();
            this.Hide();
        }
    }
}
