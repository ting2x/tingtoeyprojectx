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
    public partial class LoginForm : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=test_user");
        public LoginForm()
        {
            InitializeComponent();
        }


        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {

           

            DB conn = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            String query = "SELECT * FROM `userreal` WHERE `username`=@usn AND `password`=@pass";

            command.CommandText = query;
            command.Connection = conn.GetConnection();

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox2.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                MainForm mainform = new MainForm();
                mainform.Show();
            }
            else
            {
                if(textBox1.Text.Trim().Equals(""))
                {
                    MessageBox.Show("ENTER YOUR USERNAME TO LOGIN","EMPTY USERNAME",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else if (textBox2.Text.Trim().Equals(""))
                {
                    MessageBox.Show("ENTER YOUR PASSWORD TO LOGIN", "EMPTY PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("WRONG USERNAME OR PASSWORD", "WRONG DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerform = new RegisterForm();
            registerform.Show();

        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Yellow;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }
    }
}


//MainForm mfrm = new MainForm();
//mfrm.textBox1.Text = textBox1.Text;
//mfrm.Show();