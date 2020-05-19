using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace project2test
{
    public partial class Detailticket : Form
    {
        public Detailticket()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            //MessageBox.Show("'"+textBox1.Text +"'" + " " + "'" + textBox3.Text + "'");
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `tingticket`(`namelastname`, `location`, `seatnum`, `price`,`date`,`time`) VALUES (@nm, @lc, @sn, @pc,@date,@time)", db.GetConnection());

            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@lc", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@sn", MySqlDbType.Text).Value = textBox3.Text;
            command.Parameters.Add("@pc", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@time", MySqlDbType.VarChar).Value = textBox6.Text;


            db.openConnection();

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=user");
            connection.Open();
            string sql = "UPDATE seat SET status = '" + textBox1.Text + "' WHERE seatno = '" + textBox3.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteReader();
            
            //MessageBox.Show("บันทึกข้อมูลเรียบร้อย");
            connection.Close();




            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("จองตั๋วสำเร็จ", "ACCOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR!");
            }
            db.closeConnection();
        }

        private void Detailticket_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Createticket creatfrm = new Createticket();
            creatfrm.Show();
            this.Hide();
            
        }

        private void label4_Click(object sender, EventArgs e)
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

