using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace New_Control_System
{
    public partial class device_add : Form
    {
        Form1 dad;
        public device_add(Form1 _dad)
        {
            dad = _dad;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dad.Add_device(textBox1.Text, 50000);
            textBox1.Focus();
        }

        public void show_add()
        {
            this.Left = MousePosition.X + 20;
            this.Top = MousePosition.Y + 20;
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void device_add_Load(object sender, EventArgs e)
        {
            this.Deactivate += new EventHandler(device_add_Deactivate);
        }

        void device_add_Deactivate(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button2.PerformClick();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
