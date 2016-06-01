using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetSocket;
using System.Threading;

namespace New_Control_System
{
    public partial class BigDad : UserControl
    {
        public double MaximumATT = 125;
        public double ATTStep = 4;
        public string login_id = "0";
        public bool login = false;
        public Communication cs;
        public login lg;
        public Control ct;
        public Admin adm;
        public newaccount na;
        public ListData ld = new ListData();
        public UserControl_chart ucc;
        //public List<Device> Device_list = new List<Device>();
        public bool changed = false;
        public UserControl1 uc;
        public bool reserved = false;
        public Form1 dad;
        public string IPaddress;
        private int port;
        public int Count_ATT(double value)
        {
            return (int)(value * ATTStep);
        }
        public BigDad(Form1 _dad)
        {
            uc = new UserControl1(this);
            dad = _dad;
            InitializeComponent();
        }
        public void set_dad(string ip,int _port)
        {
            IPaddress = ip;
            port = _port;
            ld.init_list_data(8, 8);
            CheckForIllegalCrossThreadCalls = false;
            cs = new Communication(this);
            lg = new login();
            ct = new Control(this);
            adm = new Admin(this);
            ucc = new UserControl_chart();
            lg.Dock = DockStyle.Fill;
            ct.Dock = DockStyle.Fill;
            adm.Dock = DockStyle.Fill;
            ct.init_show(8, 8);
            adm.initial_view(8, 8);
            p1.Controls.Add(adm);
            p1.Controls.Add(ct);
            p1.Controls.Add(lg);
            ucc.Dock = DockStyle.Fill;
            adm.Hide();
            ct.Hide();
            lg.Show();
            ucc.Show();
        }
        private void BigDad_Load(object sender, EventArgs e)
        {
            //drow_8x81.set_off();
        }

        public void Logt_out()
        {
            dad.button1.Enabled = false;
            dad.listBox1.Enabled = false;
            ct.bt_admin.Enabled = false;
            ct.sweep1.panel2.Controls.Clear();
            ucc.timer1.Enabled = false;
            login_id = "0";
            login = false;
            ct.lb_user.Text = "USER: ";
            cs.flag = false;
            ct.Hide();
            lg.Show();
            ct.button1.Enabled = false;
            ct.button2.Enabled = false;
            ct.ccok = false;
            adm.Hide();
            if (ct.sweep1.timer_run.Enabled)
            {
                for (int i = 0; i < ct.sweep1.list_sweep.Count; i++)
                {
                    ct.sweep1.stop(i);
                }
            }
            for (int i = 0; i < dad.Device_list.Count; i++)
            {
                if(dad.Device_list[i].IP_info==IPaddress)
                {
                    dad.Device_list[i].connection = false;
                    dad.Device_list[i].re_fresh();
                }
            }
        }

        private void st_l2_TextChanged(object sender, EventArgs e)
        {
            string str = DateTime.Now.ToShortTimeString();
            st_t.Text = str;
        }
        public bool Link_socket()
        {
            try
            {
                if (cs.connect_newsocket(IPaddress, port, 3000))
                {
                    return true;
                }
                else
                {
                    st_l1.Text = "Error:";
                    st_l2.Text = "Connection failed!";
                    return false;
                }
            }
            catch(Exception err)
            {
                LogContext.theInst.LogPrint(err.ToString(), 2);
                return false;
            }
        }
        public void Re_set()
        {
            ct.sweep1.panel2.Controls.Clear();
            ucc = new UserControl_chart();
            ucc.Dock = DockStyle.Fill;
            ct.sweep1.panel2.Controls.Add(ucc);
            ucc.timer1.Enabled = true;
            for (int a = 0; a < 8; a++)
            {
                for (int b = 0; b < 8; b++)
                {
                    if (login_id != "0" && ld.list_data[a, b].channel_reverse == login_id)
                    {
                        ucc.SET_SHOW((int)(a * 8 + b));
                        ucc.SET_VALUE((int)(a * 8 + b), (float)((float)ld.list_data[a, b].channel_value / (float)ATTStep));
                    }
                }
            }
            ucc.timer1.Enabled = true;
        }
        private void listBox1_floatClick(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            dad.button1.PerformClick();
        }
        public void check_user()
        {
            if (login_id != (dad.listBox1.SelectedIndex + 1).ToString())
            {
                login_id = (dad.listBox1.SelectedIndex + 1).ToString();
                this.Text = dad.title + " USER: " + login_id;
                ct.lb_user.Text = "USER: " + login_id;
                ct.sweep1.lbl_swp.Text = "USER: " + login_id;
                if (login_id != "0")
                {
                    ct.Set_canbe(1);
                }
                cs.sendvalue("ALLCH", 1000, "ALLCH", false);
                ct.sweep1.res_changed();
                Re_set();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            check_user();
        }

        private void p1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
