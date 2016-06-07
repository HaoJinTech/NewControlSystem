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
    public partial class att_button : UserControl
    {

        //=============================================================================
        bool bigger = false;
        private double current_value; //当前控件的衰减值
        public int IN_no;
        public int OUT_no;
        public Control dad;
        private bool IS_SELECT_bool = false; //当前控件是否被选中
        public string USER;
        public bool SHOW_USER = false;
        public bool IS_SELECT
        {
            get { return IS_SELECT_bool; }
            set
            {
                IS_SELECT_bool = value;
                if (IS_SELECT_bool)
                {
                    SELECT_CONTROL();
                }
                else
                {
                    UN_SELECT_CONTROL();
                }
            }
        }
        public bool CAN_CLICK = false; //当前控件能否被双击
        public bool IS_SHOW_PANEL = false;  //当前控件是否显示操作panel
        public Color COLOR_current_bg_color = new Color(); //当前控件的背景颜色
        public Color COLOR_SELECT_bg_color = new Color(); //被选中控件的背景颜色
        public Color COLOR_CATCH_bg_color = new Color(); //被当前用户占用的控件颜色
        public Color COLOR_FREE_bg_color = new Color(); //空闲控件的背景颜色
        public Color COLOR_LIMIT_bg_color = new Color(); //被其他用户占用控件的背景颜色
        public Color COLOR_UNACTIVE_bg_color = new Color(); //未启用空间的背景颜色
        


        public double Current_value //封装衰减值SET GET方法
        {
            get { return current_value; }
            set
            {
                if (value < 0.0)
                { current_value = 0.0; }
                else if (value > dad.dad.MaximumATT)
                { current_value = dad.dad.MaximumATT; }
                else
                { current_value = value; }
                if (!SHOW_USER)
                {
                    label_ATT.Text = current_value.ToString("0.00"); //获取以后直接显示
                }
                textBox_edit_value.Text = current_value.ToString("0.00");
            }
        }
        //===============================定义结束=========================================



        public void SEND(bool i,double send_value)//发送函数
        {
            //这里书写发送函数
            string str = "ATT " + IN_no + " " + OUT_no + " " + ((int)(send_value / dad.dad.ATTStep)).ToString();
            if (i)
            { dad.dad.cs.sendvalue(str, 1000, "ATT", !dad.dad.reserved); }
        }

        public void INIT(int IN,int OUT) //初始化控件
        {
            IN_no = IN;
            OUT_no = OUT;
        }
        public att_button(Control _Dad)
        {
            dad = _Dad;
            InitializeComponent(); 
        }

        private void DEFINE_INIT_COLOR() //初始化控件色彩选项
        {
            current_value = dad.dad.MaximumATT;
            COLOR_SELECT_bg_color = Color.Goldenrod;//被选中控件的背景颜色
            COLOR_CATCH_bg_color = Color.Gold; //被当前用户占用的控件颜色
            COLOR_FREE_bg_color = System.Drawing.SystemColors.Control; //空闲控件的背景颜色
            COLOR_LIMIT_bg_color = Color.FromArgb(255,170,170,170); //被其他用户占用控件的背景颜色
            COLOR_UNACTIVE_bg_color = Color.FromArgb(255, 100, 100, 100);
        }

        


        private void UserControl1_Load(object sender, EventArgs e)
        {
            DEFINE_INIT_COLOR();
            textBox_edit_value.LostFocus += new EventHandler(textBox_edit_value_LostFocus);
            IS_SHOW_PANEL = false;
            textBox_edit_value.Visible = false;
            label_ATT.Visible = true;
        }

        void textBox_edit_value_LostFocus(object sender, EventArgs e)
        {
            if (IS_SHOW_PANEL)
            {
                CONTROL_SMALLER();
            }
        }
        public Boolean BAND_CONTROL() //绑定通道
        {
            try
            {
                SHOW_USER = false;
                CONTROL_SMALLER();
                CAN_CLICK = true;
                IS_SELECT_bool = false;
                panel1.BackColor = COLOR_CATCH_bg_color;
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        public Boolean UN_ACTIVE_CONTROL()
        {
            try
            {
                SHOW_USER = false;
                CONTROL_SMALLER();
                CAN_CLICK = false;
                IS_SELECT_bool = false;
                panel1.BackColor = COLOR_UNACTIVE_bg_color;
                label_ATT.Text = "Null";
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        public Boolean UNBAND_CONTROL() //解绑通道
        {
            try
            {
                SHOW_USER = true;
                CONTROL_SMALLER();
                panel1.BackColor = COLOR_FREE_bg_color;
                IS_SELECT_bool = false;
                CAN_CLICK = false;
                label_ATT.Text = "Free";                
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        public Boolean OTHER_BAND() //其他用户绑定通道
        {
            try
            {
                SHOW_USER = true;
                CONTROL_SMALLER();
                panel1.BackColor = COLOR_LIMIT_bg_color;
                IS_SELECT_bool = false;
                CAN_CLICK = false;
                label_ATT.Text = "USER: " + USER;
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        public void set_Select()
        {
            if (CAN_CLICK)
            {
                if (IS_SELECT_bool == false)
                {
                    SELECT_CONTROL();
                }
                else
                {
                    UN_SELECT_CONTROL();
                }
            }
        }
        public void SELECT_CONTROL() //激活选中控件操作
        {
            if (CAN_CLICK)
            {
                panel1.BackColor = COLOR_SELECT_bg_color;
                IS_SELECT_bool = true;
            }
        }
        public void UN_SELECT_CONTROL()//激活取消选中控件操作
        {
            if (CAN_CLICK)
            {
                panel1.BackColor = COLOR_CATCH_bg_color;
                IS_SELECT_bool = false;
                CONTROL_SMALLER();
            }
        }

        private void UserControl1_MouseClick(object sender, MouseEventArgs e) //鼠标单击控件事件
        {
            if (CAN_CLICK)
            {
                if (!IS_SHOW_PANEL)
                {
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        dad.grb[IN_no - 1, OUT_no - 1].set_Select();
                    }
                    else
                    {
                        for (int i = 0; i < dad.port_in.Length; i++)
                        {
                            for (int o = 0; o < dad.port_out.Length; o++)
                            {
                                if (dad.dad.ld.list_data[i, o].channel_reverse == dad.dad.login_id)
                                {
                                    if (i == (IN_no - 1) && o == (OUT_no - 1))
                                    {
                                        dad.grb[i, o].IS_SELECT = true;
                                    }
                                    else
                                    {
                                        dad.grb[i, o].IS_SELECT = false;
                                    }
                                }
                            }
                        }
                    }
                }
                dad.select_in = IN_no - 1;
                dad.select_out = OUT_no - 1;
                this.Focus();
            }
        }


        public void CONTROL_BIGGER() //控件变大
        {
            label_ATT.Visible = false;
            textBox_edit_value.Text = current_value.ToString("0.00");
            textBox_edit_value.Visible = true;
            textBox_edit_value.BringToFront();
            textBox_edit_value.Focus();
            IS_SHOW_PANEL = true;
            textBox_edit_value.Show();
            bigger = true;
        }

        public void CONTROL_SMALLER()//控件变小
        {
            IS_SHOW_PANEL = false;
            textBox_edit_value.Visible = false;
            label_ATT.Visible = true;
            label_ATT.BringToFront();
            bigger = false;
            if (USER == dad.dad.login_id)
            {
                label_ATT.Text = ((double)dad.dad.ld.list_data[IN_no - 1, OUT_no - 1].channel_value * dad.dad.ATTStep).ToString("0.00");
            }
        }

        private void label_ATT_MousseDoubleClick(object sender, MouseEventArgs e) //鼠标双击事件
        {
            if (CAN_CLICK)
            {
                if (IS_SHOW_PANEL == false)
                    CONTROL_BIGGER();
                else
                    CONTROL_SMALLER();
            }
        }

        private void UserControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (dad.select_in != -1 && dad.select_out != -1)
                {
                    if (dad.select_in - 1 < 0)
                    {
                        Change_select(dad.select_in, dad.select_out);
                        return;
                    }
                    else
                    {
                        dad.select_in -= 1;
                        Change_select(dad.select_in, dad.select_out);
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (dad.select_in != -1 && dad.select_out != -1)
                {
                    if (dad.select_in + 1 > 7)
                    {
                        Change_select(dad.select_in, dad.select_out);
                        return;
                    }
                    dad.select_in += 1;
                    Change_select(dad.select_in, dad.select_out);
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                int count = 0;
            la:
                if (dad.select_out - 1 < 0)
                {
                    dad.select_out = dad.select_out + count;
                    Change_select(dad.select_in, dad.select_out);
                    return;
                }
                if (dad.grb[dad.select_in, dad.select_out - 1].CAN_CLICK)
                {
                    dad.select_out -= 1;
                    Change_select(dad.select_in, dad.select_out);
                }
                else
                {
                    dad.select_out -= 1;
                    count += 1;
                    goto la;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                int count = 0;
            ra:
                if (dad.select_out + 1 > 7)
                {
                    dad.select_out = dad.select_out + count;
                    Change_select(dad.select_in, dad.select_out);
                    return;
                }
                if (dad.grb[dad.select_in, dad.select_out + 1].CAN_CLICK)
                {
                    dad.select_out += 1;
                    Change_select(dad.select_in, dad.select_out);
                }
                else
                {
                    dad.select_out += 1;
                    count -= 1;
                    goto ra;
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (CAN_CLICK)
                {
                    if (IS_SHOW_PANEL == false)
                        CONTROL_BIGGER();
                    else
                        CONTROL_SMALLER();
                }
            }
        }

        private void Change_select(int inport, int outport)
        {
            if((inport<0||inport>7)&&(outport<0||outport>7))
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int o = 0; o < 8; o++)
                    {
                        dad.grb[i, o].UN_SELECT_CONTROL();
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int o = 0; o < 8; o++)
                {
                    if (i == inport && o == outport)
                    {
                        dad.grb[i, o].SELECT_CONTROL();
                        dad.grb[i, o].Focus();
                    }
                    else
                    {
                        dad.grb[i, o].UN_SELECT_CONTROL();
                    }
                }
            }
        }

        private void textBox_edit_value_ValueChanged(object sender, EventArgs e)
        {
        }
        private void att_button_Resize(object sender, EventArgs e)
        {
            if (!bigger)
            {
                IS_SHOW_PANEL = false;
                textBox_edit_value.Visible = false;
                label_ATT.Focus();
            }
            else
            {
                textBox_edit_value.Visible = true;
                IS_SHOW_PANEL = true;
            }
        }

        private void att_button_Paint(object sender, PaintEventArgs e)
        {
            panel1.Width = this.Width - 4;
            panel1.Height = this.Height - 4;
            panel1.Top = 2;
            panel1.Left = 2;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            textBox_edit_value.Height = panel1.Height;
            textBox_edit_value.Width = panel1.Width;
            textBox_edit_value.Top = 0;
            textBox_edit_value.Left = 0;
            label_ATT.Height = panel1.Height;
            label_ATT.Width = panel1.Width;
            label_ATT.Top = 0;
            label_ATT.Left = 0;
        }

        private void textBox_edit_value_TextChanged(object sender, EventArgs e)
        {
            //if (textBox_edit_value.Text.Contains("\r\n"))
            //{
            //    //textBox_edit_value.Text = textBox_edit_value.Text.Replace("\r\n", "");
            //    try
            //    {
            //        double sendvalue = double.Parse(textBox_edit_value.Text);
            //        SEND(true, sendvalue);
            //        CONTROL_SMALLER();
            //    }
            //    catch (Exception)
            //    {
            //        dad.dad.st_l1.Text = "Error:";
            //        dad.dad.st_l2.Text = "Input wrong Attenuation value!";
            //    }

            //}
        }

        private void textBox_edit_value_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double sendvalue = double.Parse(textBox_edit_value.Text);
                    SEND(true, sendvalue);
                }
                catch (Exception)
                {
                    dad.dad.st_l1.Text = "Error:";
                    dad.dad.st_l2.Text = "Input wrong Attenuation value!";
                }
            }
        }

        private void textBox_edit_value_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Focus();
            }
        }
    }
}
