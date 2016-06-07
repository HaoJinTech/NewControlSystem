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
    public partial class Admin : UserControl
    {
        BigDad dad;
        public Label[] port_in = new Label[8];
        public Label[] port_out = new Label[8];
        public Label[,] channel = new Label[8, 8];
        int io_height = 0, io_length = 0;
        int space_x = 3, space_y = 3;
        string admin_see_ID = "";
        public Admin(BigDad _dad)
        {
            dad = _dad;
            InitializeComponent();        
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }


        public void initial_view(int pi, int po)
        {
            int big_x = panel1.Width;
            int big_y = panel1.Height;
            int xiuzheng = 10;
            io_height = (big_y - space_y * (po + 1)) / (po + 1);
            io_length = (big_x - space_x * (pi + 1) + xiuzheng) / (pi + 1);
            for (int x = 0; x < port_in.Length; x++)
            {
                port_in[x] = new Label();
                port_in[x].Width = io_length - xiuzheng;
                port_in[x].Height = io_height;
                port_in[x].Left = space_x;
                port_in[x].Top = space_y + (io_height + space_y) * (x + 1);
                port_in[x].BackColor = Color.FromArgb(255, 75, 75, 75);
                port_in[x].ForeColor = Color.White;
                port_in[x].Text = "IN " + (x + 1).ToString();
                port_in[x].TextAlign = ContentAlignment.MiddleCenter;
                panel1.Controls.Add(port_in[x]);
            }
            for (int y = 0; y < port_out.Length; y++)
            {
                port_out[y] = new Label();
                port_out[y].Width = io_length;
                port_out[y].Height = io_height;
                port_out[y].Top = space_y;
                port_out[y].Left = space_x + (io_length + space_x) * (y + 1) - xiuzheng;
                port_out[y].BackColor = Color.FromArgb(255, 75, 75, 75);
                port_out[y].ForeColor = Color.White;
                port_out[y].Text = "OUT" + (y + 1).ToString();
                port_out[y].TextAlign = ContentAlignment.MiddleCenter;
                panel1.Controls.Add(port_out[y]);
            }
            for (int a = 0; a < port_in.Length; a++)
            {
                for (int b = 0; b < port_out.Length; b++)
                {
                    channel[a, b] = new Label();
                    channel[a, b].AutoSize = false;
                    channel[a, b].Width = io_length;
                    channel[a, b].Height = io_height;
                    channel[a, b].Top = port_in[a].Top;
                    channel[a, b].Left = port_out[b].Left;
                    if (dad.ld.list_data[a, b].channel_reverse == admin_see_ID)
                    {
                        channel[a, b].Text = dad.ld.list_data[a, b].channel_reverse.ToString();
                        channel[a, b].BackColor = Color.LightGreen;
                    }
                    else
                    {
                        channel[a, b].Text = dad.ld.list_data[a, b].channel_reverse.ToString();
                        channel[a, b].BackColor = Color.LightGray;
                    }
                    channel[a, b].Font = dad.ct.p_u.Font;

                    channel[a, b].Tag = a * 8 + b;
                    channel[a, b].TextAlign = ContentAlignment.MiddleCenter;
                    panel1.Controls.Add(channel[a, b]);
                }
            }
        }
        public void re_new(int pi, int po)
        {
            for (int a = 0; a < pi; a++)
            {
                for (int b = 0; b < po; b++)
                {
                    if (dad.ld.list_data[a, b].channel_reverse == admin_see_ID)
                    {
                        channel[a, b].Text = dad.ld.list_data[a, b].channel_reverse.ToString();
                        channel[a, b].BackColor = dad.ct.p_u.BackColor;
                    }
                    else
                    {
                        channel[a, b].Text = dad.ld.list_data[a, b].channel_reverse.ToString();
                        channel[a, b].BackColor = Color.LightGray;
                    }
                }
            }
        }
        public void set_ch(int channel, int bt, int device)
        {

        }

        private void bt_ck_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }
            string usr = listBox1.SelectedItem.ToString();
            string[] user = usr.Split(' ');
            if (user.Length == 2)
            {
                string name = user[0];
                char[] csa = { 'U', 'S', 'E', 'R' };
                string[] ids = name.Split(csa, StringSplitOptions.RemoveEmptyEntries);
                if (ids.Length == 1)
                {
                    admin_see_ID = ids[0];
                }
            }
            dad.cs.sendvalue("ALLCH", 1000, "ALLCH", false);
        }

        private void bt_koff_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }
            string str = "UKICK ";
            string neirong = listBox1.SelectedItem.ToString();
            string[] insplit = neirong.Split(' ');
            if (insplit.Length == 2)
            {
                string added = insplit[1];
                str += added;
                if (dad.cs.sendvalue(str, 1000, "UKICK", false))
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
        }

        public void re_size(int i, int o)
        {
            if (panel1.Width < 10 || panel1.Height < 10)
            {
                return;
            }
            int big_x = panel1.Width;
            int big_y = panel1.Height;
            int xiuzheng = 28;
            io_height = (big_y - space_y * (o + 1)) / (o + 1);
            io_length = (big_x - space_x * (i + 1) + xiuzheng) / (i + 1);
            for (int x = 0; x < port_in.Length; x++)
            {
                port_in[x].Width = io_length - xiuzheng;
                port_in[x].Height = io_height;
                port_in[x].Left = space_x;
                port_in[x].Top = space_y + (io_height + space_y) * (x + 1);
            }
            for (int y = 0; y < port_out.Length; y++)
            {
                port_out[y].Width = io_length;
                port_out[y].Height = io_height;
                port_out[y].Top = space_y;
                port_out[y].Left = space_x + (io_length + space_x) * (y + 1) - xiuzheng;
            }
            for (int a = 0; a < port_in.Length; a++)
            {
                for (int b = 0; b < port_out.Length; b++)
                {
                    channel[a, b].Width = io_length;
                    channel[a, b].Height = io_height;
                    channel[a, b].Top = port_in[a].Top;
                    channel[a, b].Left = port_out[b].Left;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dad.cs.sendvalue("LOGOUT", 1000, "logout", false);
            dad.Text = "Radio Rack Application 8X8 V1.8.8";
            dad.login_id = "0";
            dad.ct.lb_user.Text = "USER:";
            this.Hide();
            dad.ct.Show();
            dad.ct.re_new(8, 8);
            dad.Re_set();
            dad.ct.Set_canbe(0);
        }

        private void bt_re_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            dad.cs.sendvalue("ALLCH", 1000, "ALLCH", false);
            Thread.Sleep(200);
            dad.cs.sendvalue("ULIST", 1000, "ULIST", false);
        }

        private void Admin_SizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.Size.ToString());
            if (dad.login_id == "'ADMIN'")
            {
                re_size(8, 8);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dad.cs.sendvalue("FTR", 1000, "FTR", false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dad.cs.sendvalue("SETALL " + ((int)(dad.MaximumATT / dad.ATTStep)).ToString(), 1000, "SETALL", false);
        }

    }
}
