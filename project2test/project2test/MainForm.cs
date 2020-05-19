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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Createticket createfrm = new Createticket();
            createfrm.Show();
            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm loginfrm = new LoginForm();
            loginfrm.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


//Createticket mfrm = new Createticket();
//mfrm.textBox1.Text = textBox1.Text;
//mfrm.Show();

