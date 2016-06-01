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
    public partial class Setting_att : Form
    {
        int ch_in;
        int ch_out;
        BigDad dad;
        string value;
        public Setting_att(BigDad _dad,int _ch_in,int _ch_out,string _value)
        {
            InitializeComponent();
            ch_in = _ch_in;
            ch_out = _ch_out;
            dad = _dad;
            value = _value;
            lb_ch.Text = ch_in.ToString();
            lb_ch2.Text = ch_out.ToString();
            numericUpDown1.Value = (decimal)float.Parse(value);
            trackBar1.Value = (int)(numericUpDown1.Value * (decimal)dad.ATTStep);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string str="";
            string value = (numericUpDown1.Value * (decimal)dad.ATTStep).ToString();
            str = "ATT " + ch_in + " " + ch_out + " " + value;
            dad.cs.sendvalue(str, 1000, "ATT", !dad.reserved);
            this.Close();
        }

        private void Setting_att_Load(object sender, EventArgs e)
        {
            this.Left = dad.Left + dad.ct.Left + dad.ct.grb[ch_in - 1, ch_out - 1].Left;
            this.Top = dad.Top + dad.ct.Top + dad.ct.grb[ch_in - 1, ch_out - 1].Top;
            dad.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Setting_att_FormClosing(object sender, FormClosingEventArgs e)
        {
            dad.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string num = numericUpDown1.Value.ToString();
            string[] dot = num.Split('.');
            if (dot.Length == 2)
            {
                if (int.Parse(dot[1]) < 5)
                {
                    dot[1] = "0";
                }
                else
                {
                    dot[1] = "5";
                }
                string re_b = "";
                for (int i = 0; i < dot.Length; i++)
                {
                    re_b += dot[i] + ".";
                }
                re_b = re_b.Substring(0, re_b.Length - 1);
                numericUpDown1.Value = (decimal)float.Parse(re_b);
                trackBar1.Value = (int)(numericUpDown1.Value * (decimal)dad.ATTStep);
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Increment = numericUpDown2.Value;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = (decimal)((float)trackBar1.Value / (float)dad.ATTStep);
        }
    }
}
