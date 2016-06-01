using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using NetSocket;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace New_Control_System
{
    public partial class Form1 : Form
    {
        public string title = "Radio Rack Application V2.3.13";
        public List<BigDad> list_dad = new List<BigDad>();
        public ListData ld = new ListData();
        public List<Device> Device_list = new List<Device>();
        public device_add da;
        public bool changed = false;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = title;
            da = new device_add(this);
            ld.init_list_data(8, 8);
            CheckForIllegalCrossThreadCalls = false;  
            load_before();

            da.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed == true)
            {
               DialogResult dr= MessageBox.Show("The list of devices is changed, do you want to save?", "Warning", MessageBoxButtons.YesNo);
               if (dr == DialogResult.Yes)
               {
                   saveToolStripMenuItem.PerformClick();
               }
               else if (dr == DialogResult.No)
               {

               }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private void quitQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void set_welcome(int i)
        {
            if (i == 1)
            {
                p_wel.Hide();
                tabControl1.Visible = true;
            }
            else
            {
                p_wel.Show();
                tabControl1.Visible = false;
            }
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process proc = new System.Diagnostics.Process();

            //设置外部程序名(记事本用 notepad.exe 计算器用 calc.exe) 
            info.FileName = "calc.exe";

            //设置外部程序的启动参数 

            info.Arguments = "";

            //设置外部程序工作目录为c:\windows 

            info.WorkingDirectory = "c:/windows/";

            try
            {
                // 
                //启动外部程序 
                // 
                proc = System.Diagnostics.Process.Start(info);
            }
            catch(Exception ae)
            {
                MessageBox.Show("Calculator can not be found", "Error!");
                LogContext.theInst.LogPrint(ae.ToString(), 2);
                return;
            } 
        }
        //=====================================Device list funcion======================================

        public bool Add_device(string ip, int port)
        {
            changed = true;
            try
            {
                string[] judge = ip.Split('.');
                if (judge.Length != 4)
                {
                    st_l1.Text = "Error";
                    st_l2.Text = "Illegal IP address.";
                    return false;
                }
                for (int i = 0; i < Device_list.Count; i++)
                {
                    if (Device_list[i].IP_info == ip && Device_list[i].Port_info == port)
                    {
                        st_l1.Text = "Error:";
                        st_l2.Text = "IP Address is already existed.";
                        return false;
                    }
                }
                Device current = new Device();
                current.set_IP(da.textBox1.Text, "50000");
                current.Set_dad(this);
                current.re_fresh();
                current.Left = 1;
                current.Top = lb_fpot.Top + Device_list.Count * (current.Height + 1);
                pl_d.Controls.Add(current);
                Device_list.Add(current);
                label1.Visible = false;
                return true;
            }
            catch(Exception eer)
            {
                LogContext.theInst.LogPrint(eer.ToString(), 2);
                return false;
            }

        }
        public int return_device_int(string ip)
        {
            for (int i = 0; i < Device_list.Count; i++)
            {
                if (Device_list[i].IP_info == ip)
                {
                    return i;
                }
            }
            return -1;
        }
        public void set_devices(int Sw)
        {
            for (int i = 0; i < Device_list.Count; i++)
            {
                if (Sw == 1)
                {
                    Device_list[i].button1.Enabled = true;
                }
                else
                {
                    Device_list[i].button1.Enabled = false;
                }
            }
        }

        public void re_fresh_device()
        {
            for (int i = 0; i < Device_list.Count; i++)
            {
                Device_list[i].re_fresh();
                Device_list[i].Left = 1;
                Device_list[i].Top = lb_fpot.Top + i * (Device_list[i].Height + 1);
            }
        }
        public void delete(string ip, int port)
        {
            for (int i = 0; i < Device_list.Count; i++)
            {
                if (Device_list[i].IP_info == ip && Device_list[i].Port_info == port)
                {
                    pl_d.Controls.Remove(Device_list[i]);
                    Device_list.RemoveAt(i);
                }
            }
            re_fresh_device();
        }
        private void load_before()
        {
            string name = Properties.Settings.Default.Address;
            if (name == "")
            {
                return;
            }
            FileStream filestream_s = new FileStream(name, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(filestream_s);
            try
            {
                Device_list.Clear();
                string read = "";
                read = sr.ReadLine();
                char[] fenhao_c = { ';' };
                string[] split_fenhao = read.Split(fenhao_c, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < split_fenhao.Length; i++)
                {
                    string[] info = split_fenhao[i].Split(' ');
                    Device current = new Device();
                    current.set_IP(info[0], info[1]);
                    current.Set_dad(this);
                    current.re_fresh();
                    current.Left = 1;
                    current.Top = 1 + Device_list.Count * (current.Height + 1);
                    pl_d.Controls.Add(current);
                    Device_list.Add(current);
                    label1.Visible = false;
                }
            }
            catch
            {
                sr.Close();
                filestream_s.Close();
            }
            sr.Close();
            filestream_s.Close();
        }

        private void bt_lod_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = ".\\";
            //ofd.RestoreDirectory = true;
            ofd.Filter = "(*.DAT)|*.DAT";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Properties.Settings.Default.Address = ofd.FileName;
                    Properties.Settings.Default.Save();
                    FileStream filestream_s = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                    StreamReader sr = new StreamReader(filestream_s);
                    try
                    {
                        Device_list.Clear();
                        string read="";
                        read = sr.ReadLine();
                        char[] fenhao_c = { ';' };
                        string[] split_fenhao = read.Split(fenhao_c, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < split_fenhao.Length; i++)
                        {
                            string[] info = split_fenhao[i].Split(' ');
                            Device current = new Device();
                            current.set_IP(info[0], info[1]);
                            current.Set_dad(this);
                            current.re_fresh();
                            current.Left = 1;
                            current.Top = 1 + Device_list.Count * (current.Height + 1);
                            pl_d.Controls.Add(current);
                            Device_list.Add(current);
                        }
                    }
                    catch(Exception er)
                    {
                        LogContext.theInst.LogPrint(er.ToString(), 2);
                        sr.Close();
                        filestream_s.Close();
                    }
                    sr.Close();
                    filestream_s.Close();
                }
                catch (Exception err)
                {
                    LogContext.theInst.LogPrint(err.ToString(), 2);
                    MessageBox.Show(err.Message);
                }
            }

        }

        private string saved_info()
        {
            string save = "";
            for (int i = 0; i < Device_list.Count; i++)
            {
                save += Device_list[i].IP_info + " " + Device_list[i].Port_info + ";";
            }
            return save;
        }

        private void bt_sav_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = ".\\";
            sfd.Filter = "(*.DAT)|*.DAT";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Properties.Settings.Default.Address = sfd.FileName;
                    Properties.Settings.Default.Save();
                    FileStream filestream = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
                    StreamWriter sw = new StreamWriter(filestream);
                    sw.WriteLine(saved_info());
                    sw.Close();
                    filestream.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    LogContext.theInst.LogPrint(err.ToString(), 2);
                }
                changed = false;
            }
        }

        private void st_l2_TextChanged(object sender, EventArgs e)
        {
            st_t.Text = DateTime.Now.ToShortTimeString();
        }
        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_setting aas = new Admin_setting();
            aas.Show();
        }

        private void addNewDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            da.show_add();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogContext.theInst.LogPrint("TEST", 0);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            login1.Width = tabControl1.Width;
            login1.Height = tabControl1.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int d = tabControl1.SelectedIndex;
            list_dad[d].check_user();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            button1.PerformClick();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            int d = tabControl1.SelectedIndex;
            if (d >= 0 && d < list_dad.Count)
                list_dad[d].check_user();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            da.show_add();
        }

        private void pl_d_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void pl_d_MouseClick(object sender, MouseEventArgs e)
        {
            da.show_add();
        }

        private void login1_Load(object sender, EventArgs e)
        {

        }

    }
}
