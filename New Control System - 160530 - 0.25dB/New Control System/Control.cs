using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace New_Control_System
{
    public partial class Control : UserControl
    {
        public BigDad dad;
        public Form_model fm;
        public Control(BigDad _dad)
        {
            InitializeComponent();
            dad = _dad;
        }
        public int select_in = -1, select_out = -1;
        public Sweep sweep1;
        public bool ccok = false;
        public att_button[,] grb= new att_button[8, 8];
        public Label[] port_in = new Label[8];
        public CheckBox[] port_out = new CheckBox[8];
        int io_length = 0;
        int io_height = 0;
        int space_x = 5;
        int space_y = 6;
        private void Control_Load(object sender, EventArgs e)
        {
          //dad.userControl_chart1.ADD_ALL_SERIES();
            sweep1 = new Sweep(dad);
            sweep1.Dock = DockStyle.Fill;
            this.tabControl1.TabPages[1].Controls.Add(sweep1);
            csv1.set_Dad(dad);
            dad.ucc = new UserControl_chart();
            dad.ucc.Dock = DockStyle.Fill;
            sweep1.panel2.Controls.Add(dad.ucc);
            dad.cs.sendvalue("CHA", 1000, "CHA", false);
            tbar1.Maximum = dad.Count_ATT(dad.MaximumATT);
            numericUpDown1.Maximum = (decimal)dad.MaximumATT;
            numericUpDown2.Minimum = (decimal)(dad.ATTStep);
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown1.DecimalPlaces = 2;
            sweep1.n_end.Maximum = (decimal)dad.MaximumATT;
            sweep1.n_end.Value = sweep1.n_end.Maximum;
            sweep1.n_step.Minimum = (decimal)(dad.ATTStep);
            sweep1.n_step.Value = sweep1.n_step.Minimum;
        }

        public void Set_canbe(int i)
        {
            if (i == 1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                checkBox1.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                checkBox3.Enabled = true;
                csv1.canbe(i);
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                checkBox1.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                checkBox3.Enabled = false;
                csv1.canbe(i);
            }
        }

        //public void Re_set()
        //{
        //    dad.panel2.Controls.Clear();
        //    dad.ucc = new UserControl_chart();
        //    dad.ucc.Dock = DockStyle.Fill;
        //    dad.panel2.Controls.Add(dad.ucc);
        //    dad.ucc.timer1.Enabled = true;
        //}

        public void re_new(int pi,int po)
        {
            for (int a = 0; a < pi; a++)
            {
                for (int b = 0; b < po; b++)
                {
                    if (a == 0)
                    { port_out[b].Text = "OUT " + (b + 1).ToString() + "\r\n" + "User " + dad.ld.list_data[a, b].channel_reverse.ToString(); }
                    if (dad.ld.list_data[a, b].channel_reverse == "0")
                    {
                        grb[a, b].USER = "";
                        grb[a, b].IS_SELECT = false;
                        grb[a, b].UNBAND_CONTROL();
                        bool nowstat = port_out[b].Checked;
                        port_out[b].Enabled = true;
                        port_out[b].Checked = nowstat;
                    }
                    else if (dad.ld.list_data[a, b].channel_reverse == dad.login_id)
                    {
                        bool nwsta = grb[a, b].IS_SELECT;
                        grb[a, b].USER = dad.ld.list_data[a, b].channel_reverse;
                        grb[a, b].Current_value = (float)dad.ld.list_data[a, b].channel_value * (float)dad.ATTStep;
                        grb[a, b].BAND_CONTROL();
                        grb[a, b].IS_SELECT = nwsta;
                        port_out[b].Checked = true;
                        port_out[b].Enabled = true;
                    }
                    else if (dad.ld.list_data[a, b].channel_reverse == "Null")
                    {
                        grb[a, b].USER = "Null";
                        grb[a, b].UN_ACTIVE_CONTROL();
                    }
                    else
                    {
                        grb[a, b].USER = dad.ld.list_data[a, b].channel_reverse;
                        grb[a, b].IS_SELECT = false;
                        grb[a, b].OTHER_BAND();
                        port_out[b].Checked = false;
                        port_out[b].Enabled = false;
                    }
                }
            }
        }

        public void init_show(int i, int o)
        {
            int big_x = panel1.Width;
            int big_y = panel1.Height;
            int xiuzheng = 28;
            io_height = (big_y - space_y * (o + 1)) / (o + 2);
            io_length = (big_x - space_x * (i + 1) + xiuzheng) / (i + 1);
            for (int x = 0; x < port_in.Length; x++)
            {
                port_in[x] = new Label();
                port_in[x].Width = io_length - xiuzheng;
                port_in[x].Height = io_height;
                port_in[x].Left = space_x / 2;
                port_in[x].Top = (io_height + space_y) * (x + 2) - space_y / 2;
                port_in[x].BackColor = Color.Gold;
                port_in[x].ForeColor = Color.Black;
                port_in[x].Text = "IN " + (x + 1).ToString();
                port_in[x].Font = p_u.Font;
                port_in[x].BorderStyle = BorderStyle.FixedSingle;
                port_in[x].TextAlign = ContentAlignment.MiddleCenter;
                panel1.Controls.Add(port_in[x]);
            }
            for (int y = 0; y < port_out.Length; y++)
            {
                port_out[y] = new CheckBox();
                port_out[y].Width = io_length;
                port_out[y].Height = io_height * 2;
                port_out[y].Top = space_y / 2;
                port_out[y].Left = space_x / 2 + (io_length + space_x) * (y + 1) - xiuzheng;
                port_out[y].BackColor = Color.Gold;
                port_out[y].ForeColor = Color.Black;
                port_out[y].Text = "OUT" + (y + 1).ToString();
                port_out[y].Font = p_u.Font;
                port_out[y].FlatStyle = FlatStyle.Flat;
                port_out[y].FlatAppearance.BorderColor = Color.Black;
                port_out[y].FlatAppearance.BorderSize = 2;
                port_out[y].FlatAppearance.CheckedBackColor = Color.Goldenrod;
                port_out[y].FlatAppearance.MouseOverBackColor = Color.Orange;
                port_out[y].FlatAppearance.MouseDownBackColor = Color.Yellow;
                port_out[y].Appearance = Appearance.Button;
                port_out[y].Tag = y;
                port_out[y].AutoCheck = false;
                port_out[y].TextAlign = ContentAlignment.MiddleCenter;
                port_out[y].Click += new EventHandler(Control_Click);
                panel1.Controls.Add(port_out[y]);
            }
            for (int a = 0; a < port_in.Length; a++)
            {
                for (int b = 0; b < port_out.Length; b++)
                {
                    grb[a, b] = new att_button(this);
                    grb[a, b].INIT(a + 1, b + 1);
                    grb[a, b].Current_value = (float)dad.ld.list_data[a, b].channel_value * (float)dad.ATTStep;
                    grb[a, b].Width = io_length;
                    grb[a, b].Height = io_height;
                    grb[a, b].Top = port_in[a].Top;
                    grb[a, b].Left = port_out[b].Left;
                    grb[a, b].CAN_CLICK = true;
                    grb[a, b].UNBAND_CONTROL();
                    grb[a, b].label_ATT.Text = "Null";
                    grb[a, b].Tag = a * 8 + b;
                    //grb[a, b].PreviewKeyDown += new PreviewKeyDownEventHandler(Control_PreviewKeyDown);
                    panel1.Controls.Add(grb[a, b]);
                }
            }
        }
        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CheckBox current=(CheckBox)sender;
                NumericUpDown tx = new NumericUpDown();
                tx.Tag = current.Tag;
                tx.Value = decimal.Parse(current.Text);
                tx.Minimum = 0;
                tx.Maximum = (decimal)dad.MaximumATT;
                tx.Increment = (decimal)(dad.ATTStep);
                tx.DecimalPlaces = 2;
                tx.ValueChanged += new EventHandler(tx_TextChanged);
                tx.KeyPress += new KeyPressEventHandler(tx_KeyPress);
                tx.Leave += new EventHandler(tx_LostFocus);
                tx.LostFocus += new EventHandler(tx_LostFocus);
                tx.AutoSize = false;
                tx.Left = current.Left;
                tx.Top = current.Top+3;
                tx.Size = current.Size;
                panel1.Controls.Add(tx);
                tx.Show();
                tx.BringToFront();
                tx.Focus();
                tx.Select(0, tx.Value.ToString().Length);
            }
        }

        void tx_LostFocus(object sender, EventArgs e)
        {
            NumericUpDown current = (NumericUpDown)sender;
            int ch = (int)current.Tag;
            int b_in = ch / 8 + 1;
            int b_out = ch % 8 + 1;
            dad.cs.sendvalue("ATT " + b_in + " " + b_out + " " + dad.Count_ATT((double)current.Value).ToString(), 1000, "ATT", !dad.reserved);
            current.Dispose();
        }

        void tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumericUpDown current = (NumericUpDown)sender;
            if (e.KeyChar == '\r')
            {
                int ch=(int)current.Tag;
                int b_in = ch / 8 + 1;
                int b_out = ch % 8 + 1;
                dad.cs.sendvalue("ATT " + b_in + " " + b_out + " " + dad.Count_ATT((double)current.Value).ToString(), 1000, "ATT", !dad.reserved);
                current.Dispose();
            }
            else if (e.KeyChar == 27)
            {
                current.Dispose();
            }
        }

        void tx_TextChanged(object sender, EventArgs e)
        {
            NumericUpDown current = (NumericUpDown)sender;
            try
            {
                string num = current.Value.ToString();
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
                    current.Value = (decimal)float.Parse(re_b);
                }
            }
            catch (Exception er)
            {
                LogContext.theInst.LogPrint(er.ToString(), 2);
                current.Value = 110.0M;
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            CheckBox current = (CheckBox)sender;
            int id = (int)current.Tag;
            bool allchecked = true;
            for (int i = 0; i < 8; i++)
            {
                if (grb[i, id].IS_SELECT == false)
                {
                    allchecked = false;
                    break;
                }
            }
            if (current.Checked == true && dad.login_id == dad.ld.list_data[0, id].channel_reverse)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (dad.ld.list_data[i, id].channel_reverse != "Null")
                    { grb[i, id].IS_SELECT = allchecked ? false : true; }
                }
            }
            else
            { current.Checked = !current.Checked; }
        }

        public void Set_ATT(int pin, int pou, int value)
        {
            if (dad.ld.list_data[pin, pou].channel_reverse == dad.login_id)
            {
                grb[pin, pou].Current_value = (float)value * (float)dad.ATTStep;
            }
            else
            {
                grb[pin, pou].label_ATT.Text = "Sweeping";
            }
        }

        //public void bst_Click(object sender, EventArgs e)
        //{
        //    att_button current = (att_button)sender;
        //    int ch = (int)current.Tag;
        //    int b_in = ch / 8 + 1;
        //    int b_out = ch % 8 + 1;
        //    float value = float.Parse(current.Text);
        //    numericUpDown1.Value = (decimal)value;
        //    //tbar1.Value = (int)(value * 2);
        //    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
        //    {
        //        grb[b_in - 1, b_out - 1].set_Select();
        //    }
        //    else
        //    {
        //        for (int i = 0; i < port_in.Length; i++)
        //        {
        //            if (i == (b_in - 1))
        //            {
        //                grb[i, b_out - 1].IS_SELECT = true;
        //            }
        //            else
        //            {
        //                grb[i, b_out - 1].IS_SELECT = false;
        //            }
        //        }
        //    }   
        //}

        //public void click_Click(object sender, EventArgs e)
        //{
        //    CheckBox current = (CheckBox)sender;
        //    int ch = (int)current.Tag;
        //    int b_in = ch / 8 + 1;
        //    int b_out = ch % 8 + 1;
        //    float value = float.Parse(current.Text);
        //    numericUpDown1.Value = (decimal)value;
        //    //tbar1.Value = (int)(value * 2);
        //    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
        //    {
        //        current.Checked = !current.Checked;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < 8; i++)
        //        {
        //            if (i == (b_in - 1))
        //            { grb[i, b_out - 1].IS_SELECT = !grb[i, b_out - 1].IS_SELECT; }
        //            else
        //            { grb[i, b_out - 1].IS_SELECT = false; }
        //        }
        //    }

        //}
        private void button2_Click(object sender, EventArgs e)
        {
            if (sweep1.timer_run.Enabled)
            {
                MessageBox.Show("Sweep is running, please stop the tasks first!");
                return;
            }
            button2.Enabled = false;
            //int id = dad.listBox1.SelectedIndex + 1;
            dad.cs.sendvalue("REL", 1000, "REL", !dad.reserved);
            sweep1.res_changed();
            dad.Re_set();
            button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sweep1.timer_run.Enabled)
            {
                MessageBox.Show("Sweep is running, please stop the tasks first!");
                return;
            }
            button1.Enabled = false;
            //int id = dad.listBox1.SelectedIndex + 1;
            bool ok = false;
            string str = "RES";
            for (int i = 0; i < port_out.Length; i++)
            {
                if (port_out[i].Checked)
                {
                    ok = true;
                    str += " " + (i + 1).ToString();
                }
            }
            if (ok)
            {
                dad.cs.sendvalue(str, 1000, "RES", !dad.reserved);
            }
            sweep1.res_changed();
            dad.Re_set();
            button1.Enabled = true;
        }
        public void re_size(int i,int o)
        {
            if (panel1.Width < 10 || panel1.Height < 10)
            {
                return;
            }
            int big_x = panel1.Width;
            int big_y = panel1.Height;
            int xiuzheng = 28;
            io_height = (big_y - space_y * (o + 1)) / (o + 2);
            io_length = (big_x - space_x * (i + 1) + xiuzheng) / (i + 1);
            for (int x = 0; x < port_in.Length; x++)
            {
                port_in[x].Width = io_length - xiuzheng;
                port_in[x].Height = io_height;
                port_in[x].Left = space_x / 2;
                port_in[x].Top = (io_height + space_y) * (x + 2) - space_y / 2;
            }
            for (int y = 0; y < port_out.Length; y++)
            {
                port_out[y].Width = io_length;
                port_out[y].Height = io_height * 2;
                port_out[y].Top = space_y / 2;
                port_out[y].Left = space_x / 2 + (io_length + space_x) * (y + 1) - xiuzheng;
            }
            for (int a = 0; a < port_in.Length; a++)
            {
                for (int b = 0; b < port_out.Length; b++)
                {
                    grb[a, b].Width = io_length;
                    grb[a, b].Height = io_height;
                    grb[a, b].Top = port_in[a].Top;
                    grb[a, b].Left = port_out[b].Left;
                }
            }
        }


        private void Control_SizeChanged(object sender, EventArgs e)
        {
            if (ccok == true)
            {
                re_size(8, 8);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                button4.Enabled = false;
            }
        }

        public void read_ethernet(string mac,string ip,string mask,string gateway)
        {
            textBox4.Text = mac;
            textBox1.Text = ip;
            textBox2.Text = mask;
            textBox3.Text = gateway;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dad.cs.sendvalue("rn", 1000, "   ", false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = "sn ";
            string oldip = dad.IPaddress;
            string newip = textBox1.Text;
            str += textBox1.Text + " " + textBox3.Text + " " + textBox2.Text;
            dad.cs.sendvalue(str, 3000, "", false);
            dad.cs.IOSocket.tcpclient.Client.Send(Encoding.ASCII.GetBytes("REBOOT\r\n"));
            dad.cs.IOSocket.tcpclient.Client.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            dad.cs.IOSocket.tcpclient.Client.Close();       
            //dad.Logt_out();     
            for (int i = 0; i < dad.dad.Device_list.Count; i++)
            {
                if (dad.dad.Device_list[i].IP_info == oldip)
                {
                    dad.dad.Device_list[i].close();
                    dad.dad.Device_list[i].set_IP(newip, "50000");
                }
            }
            //dad.set_dad(newip, 50000);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (ccok == true)
            {
                re_size(8, 8);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            bool ok = false;
            string str = "ATT";
            for (int i = 0; i < port_in.Length; i++)
            {
                for (int o = 0; o < port_out.Length; o++)
                {
                    if (grb[i, o].IS_SELECT)
                    {
                        ok = true;
                        if (str.Length >= 240)
                        {
                            dad.cs.sendvalue(str, 3000, "ATT", !dad.reserved);
                            Thread.Sleep(30);
                            str = "ATT " + (i + 1).ToString() + " " + (o + 1).ToString() + " " + dad.Count_ATT((double)numericUpDown1.Value).ToString();
                        }
                        str += " " + (i + 1).ToString() + " " + (o + 1).ToString() + " " + dad.Count_ATT((double)numericUpDown1.Value).ToString();
                    }
                }
            }
            if (ok)
            {
                dad.cs.sendvalue(str, 3000, "ATT", !dad.reserved);
            }
            button5.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            int id = dad.dad.listBox1.SelectedIndex + 1;
            bool ok = false;
            string str = "ATT";
            for (int i = 0; i < port_in.Length; i++)
            {
                for (int o = 0; o < port_out.Length; o++)
                {
                    if (grb[i, o].IS_SELECT)
                    {
                        ok = true;
                        if (str.Length >= 240)
                        {
                            dad.cs.sendvalue(str, 3000, "ATT", !dad.reserved);
                            Thread.Sleep(30);
                            str = "ATT " + (i + 1).ToString() + " " + (o + 1).ToString() + " " + dad.Count_ATT(dad.MaximumATT);
                        }
                        str += " " + (i + 1).ToString() + " " + (o + 1).ToString() + " " + dad.Count_ATT(dad.MaximumATT);
                    }
                }
            }
            if (ok)
            {
                dad.cs.sendvalue(str, 3000, "ATT", !dad.reserved);
            }
            button6.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            int id = dad.dad.listBox1.SelectedIndex + 1;
            bool ok = false;
            string str = "ATT";
            for (int i = 0; i < port_in.Length; i++)
            {
                for (int o = 0; o < port_out.Length; o++)
                {
                    if (grb[i, o].IS_SELECT)
                    {
                        ok = true;
                        if (str.Length >= 240)
                        {
                            dad.cs.sendvalue(str, 3000, "ATT", !dad.reserved);
                            Thread.Sleep(30);
                            str = "ATT " + (i + 1).ToString() + " " + (o + 1).ToString() + " 0";
                        }
                        str += " " + (i + 1).ToString() + " " + (o + 1).ToString() + " 0";
                    }
                }
            }
            if (ok)
            {
                dad.cs.sendvalue(str, 3000, "ATT", !dad.reserved);
            }
            button7.Enabled = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                for (int i = 0; i < port_in.Length; i++)
                {
                    for (int o = 0; o < port_out.Length; o++)
                    {
                        if (dad.ld.list_data[i, o].channel_reverse == dad.login_id)
                        {
                            grb[i, o].IS_SELECT = true;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < port_in.Length; i++)
                {
                    for (int o = 0; o < port_out.Length; o++)
                    {
                        if (dad.ld.list_data[i, o].channel_reverse == dad.login_id)
                        {
                            grb[i, o].IS_SELECT = false;
                        }
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            dad.cs.sendvalue("ALLCH", 1000, "ALLCH", false);
            Thread.Sleep(100);
            button8.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tbar1.Value = (int)(numericUpDown1.Value / (decimal)dad.ATTStep);
            if (dad.reserved)
            {
                bool ok = false;
                string str = "ATT";
                for (int i = 0; i < port_in.Length; i++)
                {
                    for (int o = 0; o < port_out.Length; o++)
                    {
                        if (grb[i, o].IS_SELECT)
                        {
                            ok = true;
                            if (str.Length >= 240)
                            {
                                dad.cs.sendvalue(str, 1000, "ATT", !dad.reserved);
                                Thread.Sleep(30);
                                str = "ATT " + (i + 1).ToString() + " " + (o + 1).ToString() + " " + dad.Count_ATT((double)numericUpDown1.Value).ToString();
                            }
                            else
                            {
                                str += " " + (i + 1).ToString() + " " + (o + 1).ToString() + " " + dad.Count_ATT((double)numericUpDown1.Value).ToString();
                            }
                        }
                    }
                }
                if (ok)
                {
                    dad.cs.sendvalue(str, 1000, "ATT", !dad.reserved);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dad.na = new newaccount(dad);
            dad.na.Left = MousePosition.X - dad.na.Width;
            dad.na.Top = MousePosition.Y;
            dad.na.Show();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Increment = numericUpDown2.Value;
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button5.PerformClick();
            }
        }

        public void reserved_Set()
        {
            if (!dad.reserved)
            {
                if (dad.cs.sendvalue("USER " + dad.login_id, 1000, "LOGIN", false))
                {
                    sweep1.user_changed(dad.login_id);
                    dad.reserved = true;
                    checkBox3.Checked = true;
                    button9.Enabled = true;
                    dad.dad.button1.Enabled = false;
                    dad.dad.listBox1.Enabled = false;
                }
                else
                {
                    sweep1.user_changed(dad.login_id);
                    checkBox3.Checked = false;
                    dad.reserved = false;
                    button9.Enabled = false;
                    dad.dad.button1.Enabled = true;
                    dad.dad.listBox1.Enabled = true;
                }
            }
            else
            {
                if (dad.cs.sendvalue("LOGOUT", 1000, "logout", false))
                {
                    sweep1.user_changed(dad.login_id);
                    dad.reserved = false;
                    dad.dad.button1.Enabled = true;
                    dad.dad.listBox1.Enabled = true;
                    checkBox3.Checked = false;
                }
                else
                {
                    sweep1.timer_run.Enabled = false;
                }
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            reserved_Set();
        }

        private void tbar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = (decimal)((float)tbar1.Value * (float)dad.ATTStep);
            //if (dad.reserved)
            //{
            //    bool ok = false;
            //    string str = "ATT";
            //    for (int i = 0; i < port_in.Length; i++)
            //    {
            //        for (int o = 0; o < port_out.Length; o++)
            //        {
            //            if (grb[i, o].IS_SELECT)
            //            {
            //                ok = true;
            //                if (str.Length >= 240)
            //                {
            //                    dad.cs.sendvalue(str, 1000, "ATT", !dad.reserved);
            //                    str = "ATT " + (i + 1).ToString() + " " + (o + 1).ToString() + " " + ((int)(numericUpDown1.Value * 2)).ToString(); 
            //                    Thread.Sleep(30);
            //                }
            //                else
            //                {
            //                    str += " " + (i + 1).ToString() + " " + (o + 1).ToString() + " " + ((int)(numericUpDown1.Value * 2)).ToString();
            //                }
            //            }
            //        }
            //    }
            //    if (ok)
            //    {
            //        dad.cs.sendvalue(str, 1000, "ATT", !dad.reserved);
            //    }
            //}
            Thread.Sleep(50);
        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            fm = new Form_model();
            fm.set_dad(this);
            fm.Show();
        }

        private void lb_user_Click(object sender, EventArgs e)
        {

        }

        private void tpg1_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void csv1_Load(object sender, EventArgs e)
        {

        }

        private void timer_refresh_Tick(object sender, EventArgs e)
        {
            dad.cs.sendvalue("ALLCH", 2000, "ALLCH", false);
        }
    }
}
