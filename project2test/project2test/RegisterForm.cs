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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            String fname = textBox1.Text;
            if (fname.Equals("First name"))
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void panel1_Leave(object sender, EventArgs e)
        {
            String fname = textBox1.Text;
            if(fname.Equals("First name") || fname.Trim().Equals(""))
            {
                textBox1.Text = "First name";
                textBox1.ForeColor = Color.Gray;
            }


        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            String lname = textBox3.Text;
            if (lname.Equals("Last name"))
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            String lname = textBox3.Text;
            if (lname.Equals("First name") || lname.Trim().Equals(""))
            {
                textBox3.Text = "Last name";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            String email = textBox4.Text;
            if (email.Equals("Email address"))
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            String email = textBox4.Text;
            if (email.Equals("Email address") || email.Trim().Equals(""))
            {
                textBox4.Text = "Email address";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            String fname = textBox1.Text;
            if(fname.Equals("First name") || fname.Trim().Equals(""))
            {
                textBox1.Text = "First name";
                textBox1.ForeColor = Color.Gray;
            }
        }


        private void textBox5_Enter(object sender, EventArgs e)
        {
            String username = textBox5.Text;
            if (username.Equals("Username"))
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            String username = textBox5.Text;
            if (username.Equals("Username") || username.Trim().Equals(""))
            {
                textBox5.Text = "Username";
                textBox5.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            String password = textBox2.Text;
            if (password.Equals("Password"))
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            String password = textBox2.Text;
            if (password.Equals("Password") || password.Trim().Equals(""))
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            String cmpassword = textBox6.Text;
            if (cmpassword.Equals("Confirm password"))
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            String cmpassword = textBox6.Text;
            if (cmpassword.Equals("Confirm password") || cmpassword.Trim().Equals(""))
            {
                textBox6.Text = "Confirm password";
                textBox6.ForeColor = Color.Gray;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void label2_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label2_Leave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `userreal`(`firstname`, `lastname`, `emailaddress`, `username`, `password`) VALUES (@fn, @ln, @email, @usn, @pass)", db.GetConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@email", MySqlDbType.Text).Value = textBox4.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox2.Text;

            db.openConnection();


            if(!checkTextBoxesValues())
            {
                if(textBox2.Text.Equals(textBox6.Text))
                {
                    if (checkUsername())
                    {
                        MessageBox.Show("This Username Already Exists, Select A Difrent One","Duplicate Username",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("YOUR ACCOUNT HAS BEEN CREATED!","ACCOUNT",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ERROR!");
                        }

                    }
                    

                }
                else
                {
                    MessageBox.Show("WRONG CONFIRM PASSWORD","PASSWORD ERROR",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
            }
                
            else
            {
                MessageBox.Show("ENTER YOUR INFORMATION FIRST","Empty Data",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }

            db.closeConnection();
        }

        public Boolean checkUsername()
        {
            DB db = new DB();
            String username = textBox5.Text;
            

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `userreal` WHERE `username` = @usn", db.GetConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public Boolean checkTextBoxesValues()
        {
            String fname = textBox1.Text;
            String lname = textBox3.Text;
            String email = textBox4.Text;
            String uname = textBox5.Text;
            String pass = textBox2.Text;

            if (fname.Equals("First name") || lname.Equals("Last name") ||
                email.Equals("Email addrress") || uname.Equals("Username") 
                || pass.Equals("Password"))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Yellow;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginform = new LoginForm();
            loginform.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
