using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace New_Control_System
{
    public partial class newaccount : Form
    {
        string pass;
        BigDad dad;
        public newaccount(BigDad _dad)
        {
            InitializeComponent();
            dad = _dad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newaccount_Load(object sender, EventArgs e)
        {
            pass = Properties.Settings.Default.Password;
            if (pass == "")
            {
                pass = "ACCESS";
                Properties.Settings.Default.Password = pass;
                Properties.Settings.Default.Save();
            }
            dad.Enabled = false;
            textBox2.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == pass)
            {
                if (dad.cs.sendvalue("USER ADMIN", 1000,"LOGIN", false))
                {
                    dad.Text = dad.dad.title + " USER:Admin";
                    dad.cs.sendvalue("ULIST", 1000, "ULIST", false);
                    dad.adm.Show();
                    dad.ct.Hide();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Administrator login failed!");
                }
            }
            else
            {
                dad.st_l1.Text = "Error:";
                dad.st_l2.Text = "Wrong Password!";
                textBox2.Text = "";
                textBox2.Focus();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void newaccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            dad.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label3.Text != "New Password")
            {
                if (textBox2.Text == pass)
                {
                    textBox2.Text = "";
                    label3.Text = "New Password";
                    button1.Enabled = false;
                    button3.Text = "Confirm";
                }
                else
                {
                    dad.st_l1.Text = "Error:";
                    dad.st_l2.Text = "Wrong Password!";
                    textBox2.Text = "";
                    textBox2.Focus();
                }
            }
            else
            {
                
                label3.Text = "Administrator Login";
                pass = textBox2.Text;
                textBox2.Text = "";
                Properties.Settings.Default.Password = pass;
                Properties.Settings.Default.Save();
                button1.Enabled = true;
            }
        }
    }
}
