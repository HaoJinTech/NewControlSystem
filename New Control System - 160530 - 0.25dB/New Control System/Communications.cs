using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;
using NetSocket;
using New_Control_System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace NetSocket
{
    public class Communication
    {
        /// <summary>
        /// ////////////////////
        /// 
        /// 
        /// ////////////////////////////////////////////
        public  Socket ClientSocket;
        public  IPEndPoint ServerInfo;
        public  ulong ulAnsy = 0;
        public  ulong uldefAnsy = 0;
        public  bool bConnected = false;
        public  int i = 0;
        public  int cc = 0;
        public  String packetvalue="";
        public  String typess="";
        public  int two_to_ten = 0;
        public  int size;
        public  SocketFlags socketFlags;
        public  Boolean canwrite=false;       
        public int[] values = new int[8];
        public   Thread t;
        public  Thread tc;
        public  byte[] buffer = new byte[50000];
        public  List<string> List_compile = new List<string>();
        public  bool complete_compile = false;
        public  Boolean flag = false;
        public  String SN_NO;
        public  String TYPE;
        public bool willbeover = false;
        int[] c_catch_value = new int[60000];
        String[] data_channel_name = new String[10];
        public static String valuestr = "";
        public bool instant = true;
        string[] ethernet = new string[4];
        public TimeOutSocket IOSocket = new TimeOutSocket();
        public TimeOutSocket[] List_socket = new TimeOutSocket[2];
        BigDad dad;
        public Communication(BigDad _dad)
        {
            dad = _dad;
            for (int i = 0; i < List_socket.Length; i++)
            {
                List_socket[i] = new TimeOutSocket();
            }
        }

//===========================建立与关闭连接============================
        public bool connect_newsocket(string ip,int port,int timout)
        {
            try
            {
                if (bConnected == false)
                {

                    ServerInfo = new IPEndPoint(IPAddress.Parse(ip), port);
                    if (IOSocket.Connect(ServerInfo, timout))
                    {
                        bConnected = true;
                        //startthread();
                        return true;
                    }
                    else
                    {
                        bConnected = false;
                        return false;
                    }

                }
                else
                {
                    if (closeConnect())
                    {
                        Thread.Sleep(500);
                        ServerInfo = new IPEndPoint(IPAddress.Parse(ip), port);
                        if (IOSocket.Connect(ServerInfo, timout))
                        {
                            bConnected = true;
                            //startthread();
                            dad.ucc.timer1.Enabled = true;
                            return true;
                        }
                        else
                        {
                            bConnected = false;
                            return false;
                        }
                    }
                    return false;
                }
            }
            catch(Exception e)
            {
                dad.dad.st_l1.Text = "Error:";
                dad.dad.st_l2.Text = "Creat new socket failed!";
                LogContext.theInst.LogPrint(e.ToString(), 2);
                return false;
            }
        }
        public bool closeConnect()
        {

            try
            {
                dad.dad.button1.Enabled = false;
                dad.dad.listBox1.Enabled = false;
                dad.ct.bt_admin.Enabled = false;
                dad.ct.sweep1.panel2.Controls.Clear();
                dad.ucc.timer1.Enabled = false;
                willbeover = true;
                IOSocket.tcpclient.Close();
                bConnected = false;
                willbeover = false;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Closing the Connect Failed: " + e.Message);
                LogContext.theInst.LogPrint(e.ToString(), 2);
                return false;
            }
        }
//=====================================================================
//=====================================================================
/*        //FIFO收包整合
        private void Compile_package()
        {
            string mess = "";
            string curr = "";
            int index;
            try
            {
                if (complete_compile == true)
                {
                    t.Abort();
                    t.DisableComObjectEagerCleanup();
                }
                while (!complete_compile)
                {
                    Thread.Sleep(5);
                    if (List_compile.Count > 0)
                    {
                        while (true)
                        {
                            index = List_compile[0].IndexOf('\r');
                            if (index == -1)
                            { break; }
                            if (curr == "")
                            { mess = List_compile[0].Substring(0, index); }
                            else
                            { mess = curr + List_compile[0].Substring(0, index); }
                            read_Value(mess);
                            if (index + 2 < List_compile[0].Length)
                            { List_compile[0] = List_compile[0].Substring(index + 2); }
                            else
                            { List_compile[0] = ""; }
                            if (!List_compile[0].Contains("\r\n"))
                            { break; }
                        }
                        curr = List_compile[0];
                        List_compile.RemoveAt(0);
                    }
                }
            }
            catch (Exception e)
            {
                dad.st_l1.Text = "Error:";
                dad.st_l2.Text = "Compile:"+ e.ToString();
                Compile_package();
            }
        }
        public void startthread()
        {
            //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            t = new Thread(new ThreadStart(get_value));
            t.IsBackground = true;
            t.Priority = ThreadPriority.AboveNormal;
            t.Start(); 
            //tc = new Thread(new ThreadStart(Compile_package));
            //tc.IsBackground = true;
            //tc.Priority = ThreadPriority.AboveNormal;
            //complete_compile = false;
            //tc.Start();
        }
        public void get_value()
        {
            byte[] buffer = new byte[2000];
            int couting = 0;

            while (true)
            {
                try
                {
                    if (willbeover == true)
                    {
                        //sendvalue("LOGOUT");
                        return;
                    }
                    else
                    {
                        buffer = new byte[2000];
                        IOSocket.tcpclient.Client.Receive(buffer, 2000, 0);
                        string str = Encoding.Default.GetString(buffer);
                        str = str.Replace("\0", "");
                        //List_compile.Add(str);//解包方法
                        if (str == "")
                        {
                            couting += 1;
                            if (couting == 5)
                            {
                                
                                IOSocket.tcpclient.Close();
                                bConnected = false;
                                t.Abort();
                            }
                        }
                        else
                        {
                            read_Value(str);
                        }
                    }
                }
                catch (Exception e)
                {
                    dad.st_l1.Text = "Error:";
                    dad.st_l2.Text="Failed to listen the connection:" + e.Message;
                    dad.Logt_out();
                    //Application.ExitThread();
                    //Application.Exit();
                }
            }

        }
*/
//=====================================================================

        int Count(int n)//要几次方就传递多少
        {
            int result;
            if (n == 0)
            {
                return 1;
            }
            result = 2 * Count(n - 1);
            return result;
        }
//解包收到的信息=======================================================
//=====================================================================

        public void read_Value(string _buffer)
        {

            string info = _buffer;
            char[] c_s1={'\r','\n'};
            //根据回车分包解内容
            string[] split1 = info.Split(c_s1, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split1.Length; i++)
            {
                //每个回车内的包进行解析

                //USER解包
                if (split1[i].StartsWith("USER"))
                {
                    string[] str_i = split1[i].Split(' ');
                    if (str_i.Length == 3)
                    {
                        // ID = str_i[1], 刷新control界面
                        dad.st_l1.Text = "Receive:";
                        dad.st_l2.Text = split1[i];
                        dad.login_id = str_i[1];
                    }
                }

                //ALLCH解包
                else if (split1[i].StartsWith("ALLCH") || split1[i].StartsWith("UQUE"))
                {
                    char[] cha = { ';' };
                    string[] fenhao = split1[i].Split(cha, StringSplitOptions.RemoveEmptyEntries);
                    for (int f = 0; f < fenhao.Length; f++)
                    {
                        string[] first_info = fenhao[f].Split(' ');
                        if (first_info.Length == 5)
                        {
                            int data_in = (int)(int.Parse(first_info[1]) - 1);
                            int data_out = (int)(int.Parse(first_info[2]) - 1);
                            dad.ld.list_data[data_in, data_out].channel_value = int.Parse(first_info[3]);
                            dad.ld.list_data[data_in, data_out].channel_reverse = first_info[4];
                            dad.ucc.SET_VALUE(data_in * 8 + data_out, (float)(float.Parse(first_info[3]) * dad.ATTStep));
                        }
                        else if (first_info.Length == 4)
                        {
                            int data_in = int.Parse(first_info[0]) - 1;
                            int data_out = int.Parse(first_info[1]) - 1;
                            dad.ld.list_data[data_in, data_out].channel_value = int.Parse(first_info[2]);
                            dad.ld.list_data[data_in, data_out].channel_reverse = first_info[3];
                            dad.ucc.SET_VALUE(data_in * 8 + data_out, (float)(float.Parse(first_info[2]) * dad.ATTStep));
                        }
                    }

                    dad.ct.re_new(8, 8);
                    dad.adm.re_new(8, 8);
                }

                //RES解包
                else if (split1[i].StartsWith("RES"))
                {
                    bool in_off = false;
                    int set_in = 0;
                    int set_out = 0;
                    char[] charen = { ' ', ';', ':' };
                    string[] value_read = split1[i].Split(charen, StringSplitOptions.RemoveEmptyEntries);
                    for (int v = 1; v < value_read.Length; v++)
                    {
                        if (!value_read[v].Contains("BUSY"))
                        {
                            int dates = int.Parse(value_read[v]);
                            if (in_off == false)
                            {
                                set_in = dates;
                                in_off = true;
                            }
                            else
                            {
                                set_out = dates;
                                in_off = false;
                                dad.ld.list_data[set_in - 1, set_out - 1].channel_reverse = dad.login_id;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    dad.ct.re_new(8, 8);
                    dad.adm.re_new(8, 8);
                    //dad.Re_set();
                }

                //REL解包
                else if (split1[i].StartsWith("REL"))
                {
                    for (int a = 0; a < 8; a++)
                    {
                        for (int b = 0; b < 8; b++)
                        {
                            if (dad.ld.list_data[a, b].channel_reverse == dad.login_id)
                            { dad.ld.list_data[a, b].channel_reverse = "0"; }
                        }
                    }
                    dad.ct.re_new(8, 8);
                    dad.adm.re_new(8, 8);
                    //dad.Re_set();
                }
                else if (split1[i].StartsWith("FTR"))
                {
                    dad.st_l1.Text = "Message:";
                    dad.st_l2.Text = "Forced to release all channels.";
                    for (int a = 0; a < 8; a++)
                    {
                        for (int b = 0; b < 8; b++)
                        {
                            if (dad.ld.list_data[a, b].channel_reverse != "Null")
                            { dad.ld.list_data[a, b].channel_reverse = "0"; }
                        }
                    }
                    dad.ct.re_new(8, 8);
                    dad.adm.re_new(8, 8);
                    //dad.Re_set();
                }
                //QUE解包
                else if (split1[i].StartsWith("QUE"))
                {
                    dad.st_l1.Text = "Receive:";
                    dad.st_l2.Text = split1[i];
                }
                //ATT解包
                else if (split1[i].StartsWith("ATT"))
                {
                    split1[i] = split1[i].Replace("ATT", "");
                    char[] charr = { ';' };
                    string[] fenhao = split1[i].Split(charr, StringSplitOptions.RemoveEmptyEntries);
                    for (int f = 0; f < fenhao.Length; f++)
                    {
                        char[] cca = { ' ' };
                        string[] ATT_info = fenhao[f].Split(cca, StringSplitOptions.RemoveEmptyEntries);
                        if (ATT_info.Length == 3)
                        {
                            int data_in = int.Parse(ATT_info[0]) - 1;
                            int data_out = int.Parse(ATT_info[1]) - 1;
                            if (!ATT_info[2].Contains("N"))
                            {
                                int value = int.Parse(ATT_info[2]);
                                dad.ld.list_data[data_in, data_out].channel_value = value;
                                dad.ct.Set_ATT(data_in, data_out, value);
                                dad.ucc.SET_VALUE(data_in * 8 + data_out, (float)((float)value * dad.ATTStep));
                            }
                        }
                        else if (ATT_info.Length == 2)
                        {
                            int data_ch = int.Parse(ATT_info[0]) - 1;
                            int data_in = data_ch / 8;
                            int data_out = data_ch % 8;
                            if (!ATT_info[1].Contains("N"))
                            {
                                int value = int.Parse(ATT_info[1]);
                                dad.ld.list_data[data_in, data_out].channel_value = value;
                                dad.ct.Set_ATT(data_in, data_out, value);
                                dad.ucc.SET_VALUE(data_in * 8 + data_out, (float)((float)value * dad.ATTStep));
                            }
                        }
                    }
                }
                else if (split1[i].StartsWith("   "))
                {
                    if (split1[i].Contains("MAC"))
                    {
                        string[] informac = split1[i].Split(':');
                        if (informac.Length == 2)
                        {
                            ethernet[0] = informac[1];
                        }
                    }
                    else if (split1[i].Contains("IPv4"))
                    {
                        string[] informac = split1[i].Split(':');
                        if (informac.Length == 2)
                        {
                            ethernet[1] = informac[1];
                        }
                    }
                    else if (split1[i].Contains("Mask"))
                    {
                        string[] informac = split1[i].Split(':');
                        if (informac.Length == 2)
                        {
                            ethernet[2] = informac[1];
                        }
                    }
                    else if (split1[i].Contains("Gateway"))
                    {
                        string[] informac = split1[i].Split(':');
                        if (informac.Length == 2)
                        {
                            ethernet[3] = informac[1];
                        }
                    }
                    if (ethernet[0] != null && ethernet[1] != null && ethernet[2] != null && ethernet[3] != null)
                    {
                        dad.ct.read_ethernet(ethernet[0], ethernet[1], ethernet[2], ethernet[3]);
                    }
                }
                else if (split1[i].Contains("ULIST"))
                {
                    dad.adm.listBox1.Items.Clear();
                    char[] cassa = { ';' };
                    string[] data_ulist = split1[i].Split(cassa, StringSplitOptions.RemoveEmptyEntries);
                    for (int u = 0; u < data_ulist.Length; u++)
                    {
                        string[] kongge = data_ulist[u].Split(' ');
                        if (kongge.Length == 3)
                        {
                            string ulist_ip = kongge[1];
                            string ulist_user = kongge[2];
                            if (ulist_user == "USER9")
                            { ulist_user = "ADMIN"; }
                            else if (ulist_user == "USER0")
                            { ulist_user = "Guest"; }
                            dad.adm.listBox1.Items.Add(ulist_user + " " + ulist_ip);
                        }
                        else if (kongge.Length == 2)
                        {
                            string ulist_ip = kongge[0];
                            string ulist_user = kongge[1];
                            if (ulist_user == "USER9")
                            { ulist_user = "ADMIN"; }
                            else if (ulist_user == "USER0")
                            { ulist_user = "Guest"; }
                            dad.adm.listBox1.Items.Add(ulist_user + " " + ulist_ip);
                        }
                    }
                }
                else if (split1[i].StartsWith("Occupied"))
                {
                    string[] occu = split1[i].Split(' ');
                    if (occu.Length == 2)
                    {
                        MessageBox.Show(dad, "The user is occupied by " + occu[1]);
                    }
                }
                else if (split1[i].StartsWith("CHA"))
                {
                    string[] countmes = split1[i].Split(' ');
                    if (countmes.Length == 4)
                    {
                        int county =  Count(int.Parse(countmes[3]));
                        
                        dad.ATTStep = 1.0 / (double)county;
                        dad.MaximumATT = double.Parse(countmes[2]);
                        //dad.ct.numericUpDown1.Value=
                    }
                }
                else if (split1[i].StartsWith("KICKED"))
                {
                    dad.Text = dad.dad.title;
                    dad.login_id = "0";
                    dad.adm.Hide();
                    dad.ct.re_new(8, 8);
                    dad.ct.checkBox3.Checked = false;
                    dad.Re_set();
                    dad.ct.Set_canbe(0);
                    for (int s = 0; s < dad.ct.sweep1.list_sweep.Count; s++)
                    {
                        if (dad.ct.sweep1.list_sweep[s].timer1.Enabled == true)
                        {
                            dad.ct.sweep1.stop(s);
                        }
                    }
                    dad.dad.listBox1.Enabled = true;
                    dad.dad.button1.Enabled = true;
                    dad.reserved = false;
                    dad.ct.sweep1.reserve_state(false);
                    //开收包进行验证
                    receive_value();
                    read_Value(receivedata);
                    dad.st_l1.Text = "Warning:";
                    dad.st_l2.Text = "You have been kicked!";
                }
                else
                {
                    dad.st_l1.Text = "Message:";
                    dad.st_l2.Text = split1[i];
                }


            }
        }      
//=====================================================================
//通过socket发送指令 参数 ： 指令字符串 (不用加入0D0A)
//=====================================================================

        public void receive_value()
        {
            try
            {
                byte[] receivebyte = new byte[5120];
                receivedata = "";
                int readByte = IOSocket.tcpclient.Client.Receive(receivebyte);
                if (readByte <= 0)
                {
                    int id = dad.dad.return_device_int(dad.IPaddress);
                    if (id != -1)
                    {
                        dad.dad.Device_list[id].close();
                    }
                    return;
                }
                receivedata = Encoding.Default.GetString(receivebyte);
                receivedata = receivedata.Replace("\0", "");
            }
            catch (SocketException)
            {
                return;
            }
        }

        int fail_time = 0;
        string receivedata = "";

        public bool sendvalue(string data, int interval, string check, bool needlogin)
        {
            bool doublecheck = false;
            try
            {
                IOSocket.tcpclient.Client.ReceiveTimeout = interval;
                if (needlogin)
                {
                    IOSocket.tcpclient.Client.Send(Encoding.ASCII.GetBytes("USER " + dad.login_id + "\r\n"));
                loop1:
                    receive_value();
                    read_Value(receivedata);
                    if (!receivedata.Contains("LOGIN"))
                    {
                        if (!doublecheck)
                        {
                            doublecheck = true;
                            goto loop1;
                        }
                        LogContext.theInst.LogPrint("Wrong Receive:" + receivedata + ".\r\n", 2);
                        return false;
                    }
                }
                data += "\r\n";
                IOSocket.tcpclient.Client.Send(Encoding.ASCII.GetBytes(data));
                doublecheck = false;
                loop2:
                receive_value();
                read_Value(receivedata);
                if (!receivedata.Contains(check))
                {
                    if (!doublecheck)
                    {
                        doublecheck = true;
                        goto loop2;
                    }
                    LogContext.theInst.LogPrint("Wrong Receive:" + receivedata + ".\r\n", 2);
                    return false;
                }
                if (needlogin)
                {
                    IOSocket.tcpclient.Client.Send(Encoding.ASCII.GetBytes("LOGOUT" + "\r\n"));
                    receive_value();
                    read_Value(receivedata);
                    if (receivedata.Contains("logout"))
                    {
                        return true;
                    }
                    else
                    {
                        LogContext.theInst.LogPrint("Wrong Receive:" + receivedata + ".\r\n", 2);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                dad.st_l1.Text = "Error:";
                dad.st_l2.Text = e.ToString();
                LogContext.theInst.LogPrint(receivedata + "\r\n" + e.ToString(), 2);
                if (fail_time >= 1)
                {
                    int id = dad.dad.return_device_int(dad.IPaddress);
                    if (id != -1)
                    {
                        dad.dad.Device_list[id].close();
                    }
                }
                fail_time++;
                return false;
            }
        }


        //public bool sendvalue(string data, int interval, string check)
        //{
        //    try
        //    {

        //        data += "\r\n";
        //        IOSocket.tcpclient.Client.Send(Encoding.ASCII.GetBytes(data));
        //        //开收包进行验证
        //        fail_time = 0;
        //        if (receive_value())
        //        {
        //            if (receivedata.Contains(check))
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            dad.st_l1.Text = "Error:";
        //            dad.st_l2.Text = receivedata;
        //            return false;
        //        }
        //    }
        //    catch (SocketException se)
        //    {
        //        dad.st_l1.Text = "Error:";
        //        dad.st_l2.Text = se.Message.ToString();
        //        LogContext.theInst.LogPrint(receivedata + "\r\n" + se.ToString(), 2);
        //        if (fail_time == 5)
        //        {
        //            int id = dad.dad.return_device_int(dad.IPaddress);
        //            if (id != -1)
        //            {
        //                dad.dad.Device_list[id].close();
        //            }
        //        }
        //        fail_time++;
        //        return false;
        //    }
        //    catch(Exception e) 
        //    {
        //        dad.st_l1.Text = "Error:";
        //        dad.st_l2.Text = e.Message.ToString();
        //        LogContext.theInst.LogPrint(receivedata + "\r\n" + e.ToString(), 2);
        //        if (fail_time == 5)
        //        {
        //            int id = dad.dad.return_device_int(dad.IPaddress);
        //            if (id != -1)
        //            {
        //                dad.dad.Device_list[id].close();
        //            }
        //        }
        //        fail_time++;
        //        return false;
        //    }
        //}
        //public bool sendvalue(string data, int interval, bool login)
        //{
        //    try
        //    {
        //        receivedata = "";
        //        byte[] receivebyte = new byte[1024];
        //        if (login == true)
        //        {
        //            IOSocket.tcpclient.Client.Send(Encoding.ASCII.GetBytes("USER " + dad.login_id + "\r\n"));
        //            IOSocket.tcpclient.Client.Receive(receivebyte);
        //            receivedata = Encoding.Default.GetString(receivebyte);
        //            receivedata = receivedata.Replace("\0", "");
        //            fail_time = 0;
        //            if (receivedata.Contains("LOGIN"))
        //            {
        //                read_Value(receivedata);
        //                data += "\r\n";
        //                IOSocket.tcpclient.Client.Send(Encoding.ASCII.GetBytes(data));
        //                //开收包进行验证
        //                receivedata = "";
        //                receivebyte = new byte[1024];
        //                IOSocket.tcpclient.Client.Receive(receivebyte);
        //                receivedata = Encoding.Default.GetString(receivebyte);
        //                receivedata = receivedata.Replace("\0", "");
        //                fail_time = 0;
        //                if (receivedata.Contains("SYNTAX") || receivedata.Contains("Invalid") || receivedata.Contains("Occupied") || receivedata.Contains("Not"))
        //                {
        //                    read_Value(receivedata);
        //                    dad.st_l1.Text = "Error:";
        //                    dad.st_l2.Text = "Command Error!";
        //                    return false;
        //                }
        //                else if (receivedata == "")
        //                {
        //                    int id = dad.dad.return_device_int(dad.IPaddress);
        //                    if (id != -1)
        //                    {
        //                        dad.dad.Device_list[id].close();
        //                    }
        //                    return false;
        //                }
        //                else
        //                {
        //                    read_Value(receivedata);
        //                    IOSocket.tcpclient.Client.Send(Encoding.ASCII.GetBytes("LOGOUT\r\n"));
        //                    receivedata = "";
        //                    receivebyte = new byte[1024];
                            
        //                    IOSocket.tcpclient.Client.Receive(receivebyte);
        //                    receivedata = Encoding.Default.GetString(receivebyte);
        //                    receivedata = receivedata.Replace("\0", "");
        //                    fail_time = 0;
        //                    if (receivedata.Contains("logout"))
        //                    {
        //                        read_Value(receivedata);
        //                        return true;
        //                    }
        //                    else
        //                    {
        //                        dad.st_l1.Text = "Error:";
        //                        dad.st_l2.Text = "User Logout Error!";
        //                        read_Value(receivedata);
        //                        return false;
        //                    }
        //                }
        //            }
        //            else if (receivedata.Contains("Occupied"))
        //            {
        //                read_Value(receivedata);
        //                receivedata = receivedata.Substring(8);
        //                dad.st_l1.Text = "Error:";
        //                dad.st_l2.Text = "USER is Occupied " + receivedata;
        //                return false;
        //            }
        //            else if (receivedata == "")
        //            {
        //                int id = dad.dad.return_device_int(dad.IPaddress);
        //                if (id != -1)
        //                {
        //                    dad.dad.Device_list[id].close();
        //                    dad.dad.st_l1.Text = "Error:";
        //                    dad.dad.st_l2.Text = dad.dad.Device_list[id].IP_info + " is been closed by the remote host!";
        //                }
        //                return false;
        //            }
        //            return false;
        //        }
        //        else
        //        {
        //            data += "\r\n";
        //            IOSocket.tcpclient.Client.Send(Encoding.ASCII.GetBytes(data));
        //            //开收包进行验证
        //            receivedata = "";
        //            receivebyte = new byte[1024];
        //            IOSocket.tcpclient.Client.Receive(receivebyte);
        //            receivedata = Encoding.Default.GetString(receivebyte);
        //            receivedata = receivedata.Replace("\0", "");
        //            fail_time = 0;
        //            if (receivedata.Contains("SYNTAX") || receivedata.Contains("Invalid") || receivedata.Contains("Occupied") || receivedata.Contains("Not"))
        //            {
        //                read_Value(receivedata);
        //                dad.st_l1.Text = "Error:";
        //                dad.st_l2.Text = "Sending Command Error!";
        //                return false;
        //            }
        //            else if (receivedata == "")
        //            {
        //                int id = dad.dad.return_device_int(dad.IPaddress);
        //                if (id != -1)
        //                {
        //                    dad.dad.Device_list[id].close();
        //                    dad.dad.st_l1.Text = "Error:";
        //                    dad.dad.st_l2.Text = dad.dad.Device_list[id].IP_info + " is been closed by the remote host!";
        //                }
        //                return false;
        //            }

        //            else
        //            {
        //                read_Value(receivedata);
        //                return true;
        //            }
        //        }
        //    }
        //    catch (SocketException se)
        //    {
        //        dad.st_l1.Text = "Error:";
        //        dad.st_l2.Text = se.Message.ToString();
        //        LogContext.theInst.LogPrint(receivedata + "\r\n" + se.ToString(), 2);
        //        if (fail_time == 5)
        //        {
        //            int id = dad.dad.return_device_int(dad.IPaddress);
        //            if (id != -1)
        //            {
        //                dad.dad.Device_list[id].close();
        //            }
        //        }
        //        fail_time++;
        //        return false;
        //    }
        //    catch (Exception e)
        //    {
        //        dad.st_l1.Text = "Error:";
        //        dad.st_l2.Text = e.Message.ToString();
        //        LogContext.theInst.LogPrint(receivedata + "\r\n" + e.ToString(), 2);
        //        if (fail_time == 5)
        //        {
        //            int id = dad.dad.return_device_int(dad.IPaddress);
        //            if (id != -1)
        //            {
        //                dad.dad.Device_list[id].close();
        //            }
        //        }
        //        fail_time++;
        //        return false;
        //    }
        //}
    }
}
