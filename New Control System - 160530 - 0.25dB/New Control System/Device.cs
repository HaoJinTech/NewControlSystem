using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace New_Control_System
{
    public partial class Device : UserControl
    {
        Form1 dad;
        BigDad newdad;
        public Device()
        {
            InitializeComponent();
        }

        public void Set_dad(Form1 _dad)
        {
            dad = _dad;
        }
        public bool connection = false;
        public string IP_info = "";
        public int Port_info = 0;
        public void re_fresh()
        {
            if (connection)
            {
                button1.Image = Properties.Resources.connectbt1;
            }
            else
            {
                button1.Image = Properties.Resources.disconnectbt2;
            }
        }
        public void set_IP(string ip,string port)
        {
            IP_info = ip;
            Port_info = int.Parse(port);
            button1.Text = ip;
        }
       

        public void close()
        {
            for (int i = 0; i < dad.list_dad.Count; i++)
            {
                if (dad.list_dad[i].IPaddress == IP_info)
                {
                    dad.list_dad[i].ct.timer_refresh.Enabled = false;
                    dad.list_dad[i].ct.sweep1.timer_run.Enabled = false;
                    dad.list_dad[i].cs.closeConnect();
                    dad.list_dad[i].Logt_out();
                    dad.list_dad.RemoveAt(i);
                    dad.tabControl1.TabPages.RemoveAt(i);
                    connection = false;
                }
            }
            bool doit = true;
            for (int i = 0; i < dad.Device_list.Count; i++)
            {
                if (dad.Device_list[i].connection)
                { doit = false; }
            }
            if (doit)
            { dad.set_welcome(0); }
            dad.set_devices(1);
            re_fresh();
            System.GC.Collect();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            dad.changed = true;
            
            if(connection)
            {
            close();
            }
            
            dad.delete(IP_info, Port_info);
        }


        private void Device_DoubleClick(object sender, EventArgs e)
        {

            dad.set_devices(0);
            if (!connection)
            {
                newdad = new BigDad(dad);
                newdad.set_dad(IP_info, Port_info);
                if (newdad.Link_socket())
                {
                    dad.st_l1.Text = "Message:";
                    dad.st_l2.Text = "Connected to " + IP_info;
                    dad.tabControl1.TabPages.Add(IP_info);
                    dad.tabControl1.TabPages[dad.tabControl1.TabPages.Count - 1].Controls.Add(newdad);
                    newdad.Dock = DockStyle.Fill;
                    dad.list_dad.Add(newdad);
                    dad.set_welcome(1);
                    newdad.lg.Hide();
                    newdad.ct.Show();
                    newdad.toolStripStatusLabel1.Text = IP_info + ":" + Port_info;
                    newdad.toolStripStatusLabel1.ForeColor = Color.Green;
                    newdad.ct.ccok = true;
                    newdad.ct.re_size(8, 8);
                    newdad.adm.re_size(8, 8);
                    newdad.dad.button1.Enabled = true;
                    newdad.dad.listBox1.Enabled = true;
                    newdad.ct.bt_admin.Enabled = true;

                    newdad.cs.sendvalue("CHA", 1000, "CHA", false);
                    dad.tabControl1.SelectedIndex = dad.tabControl1.TabCount - 1;
                    newdad.cs.sendvalue("ALLCH", 1000, "ALLCH", false);
                    connection = true;
                    newdad.ct.timer_refresh.Enabled = true;
                }
                else
                {
                    newdad.Dispose();
                    connection = false;
                }
            }
            else
            {
                close();
            }
            dad.set_devices(1);
            re_fresh();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.PowderBlue;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.LightSkyBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.PowderBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dad.tabControl1.TabPages.Count; i++)
            {
                if (dad.tabControl1.TabPages[i].Text == IP_info)
                    dad.tabControl1.SelectedIndex = i;
            }
                
        }

     
     
    }
}
