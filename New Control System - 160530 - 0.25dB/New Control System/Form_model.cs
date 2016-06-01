using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace New_Control_System
{
    public partial class Form_model : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        Control dad;
        public int[] fre = new int[4];
        public int[] init_db = new int[4];
        public int[] fre2 = new int[4];
        public int[] init_db2 = new int[4];
        Point mouse_offset;
        private int move_flag = 0;
        int pan_x = 0, pan_y = 0, set_pan = -1;
        Free_Field ff = new Free_Field();
        bool start = false;
        bool initial = false;
        public Graphics g;
        public Graphics g2;
        public Graphics[] g_l = new Graphics[1000];
        public Graphics[] g_l2 = new Graphics[1000];

        public int timer_step = 0;
        public int step_count = 0;

        public int timer_step2 = 0;
        public int step_count2 = 0;

        public Boolean CAR1_ISRUN = false;
        public Boolean CAR2_ISRUN = false;

        public Boolean CAR1_PAUSE = false;
        public Boolean CAR2_PAUSE = false;

        List<double> x = new List<double>();
        List<double> y = new List<double>();


        List<double> x2 = new List<double>();
        List<double> y2 = new List<double>();

        public int point_no = 0;
        public int point_no2 = 0;

        public int list_x = 0;
        public int list_y = 0;
        public int list_count = -1;

        public int list2_x = 0;
        public int list2_y = 0;
        public int list2_count = -1;

        int m = 0;
        int m2 = 0;

        public Form_model()
        {
            InitializeComponent();
        }

        public void set_dad(Control _dad)
        {
            dad = _dad;
        }
        private void Form_model_Load(object sender, EventArgs e)
        {
            textBox_d1_x.Text = bts11.Left.ToString();
            textBox_d2_x.Text = bts21.Left.ToString();
            textBox_d3_x.Text = bts31.Left.ToString();
            textBox_d4_x.Text = bts41.Left.ToString();

            textBox_d1_y.Text = bts11.Top.ToString();
            textBox_d2_y.Text = bts21.Top.ToString();
            textBox_d3_y.Text = bts31.Top.ToString();
            textBox_d4_y.Text = bts41.Top.ToString();

            for (int i = 0; i < 4; i++)
            {
                Global.old_value_car1[i] = 0;
                Global.old_value_car2[i] = 0;
            }
            bts11.Visible = true;
            init(8, 8);
            initial = true;
        }

        private void init(int pi,int po)
        {
            
             for (int a = 0; a < pi; a++)
            {
                for (int b = 0; b < po; b++)
                {
                    if (dad.dad.ld.list_data[a, b].channel_reverse == dad.dad.login_id)
                    {
                        comboBox1.Items.Add("IN " + (a + 1).ToString() + " OUT " + (b + 1).ToString());
                        comboBox2.Items.Add("IN " + (a + 1).ToString() + " OUT " + (b + 1).ToString());
                        comboBox3.Items.Add("IN " + (a + 1).ToString() + " OUT " + (b + 1).ToString());
                        comboBox4.Items.Add("IN " + (a + 1).ToString() + " OUT " + (b + 1).ToString());
                        comboBox5.Items.Add("IN " + (a + 1).ToString() + " OUT " + (b + 1).ToString());
                        comboBox6.Items.Add("IN " + (a + 1).ToString() + " OUT " + (b + 1).ToString());
                        comboBox7.Items.Add("IN " + (a + 1).ToString() + " OUT " + (b + 1).ToString());
                        comboBox8.Items.Add("IN " + (a + 1).ToString() + " OUT " + (b + 1).ToString());
                    }
                }
             }
             if (comboBox1.Items.Count >= 8)
             {
                 comboBox1.SelectedIndex = 0;
                 comboBox2.SelectedIndex = 1;
                 comboBox3.SelectedIndex = 2;
                 comboBox4.SelectedIndex = 3;
                 comboBox5.SelectedIndex = 4;
                 comboBox6.SelectedIndex = 5;
                 comboBox7.SelectedIndex = 6;
                 comboBox8.SelectedIndex = 7;
             }
        }

        private void bts11_Move(object sender, EventArgs e)
        {
            textBox_d1_x.Text = bts11.Left.ToString();
            textBox_d1_y.Text = bts11.Top.ToString();
        }

        private void bts21_Move(object sender, EventArgs e)
        {
            textBox_d2_x.Text = bts21.Left.ToString();
            textBox_d2_y.Text = bts21.Top.ToString();
        }

        private void bts31_Move(object sender, EventArgs e)
        {
            textBox_d3_x.Text = bts31.Left.ToString();
            textBox_d3_y.Text = bts31.Top.ToString();
        }

        private void bts41_Move(object sender, EventArgs e)
        {
            textBox_d4_x.Text = bts41.Left.ToString();
            textBox_d4_y.Text = bts41.Top.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bts11.Left = int.Parse(textBox_d1_x.Text);
            bts11.Top = int.Parse(textBox_d1_y.Text);
            init_db[0] = int.Parse(textBox_b1_init.Text);
            init_db2[0] = int.Parse(textBox_b1_init.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bts21.Left = int.Parse(textBox_d2_x.Text);
            bts21.Top = int.Parse(textBox_d2_y.Text);
            init_db[1] = int.Parse(textBox_b2_init.Text);
            init_db2[1] = int.Parse(textBox_b2_init.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bts31.Left = int.Parse(textBox_d3_x.Text);
            bts31.Top = int.Parse(textBox_d3_y.Text);
            init_db[2] = int.Parse(textBox_b3_init.Text);
            init_db2[2] = int.Parse(textBox_b3_init.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bts41.Left = int.Parse(textBox_d4_x.Text);
            bts41.Top = int.Parse(textBox_d4_y.Text);
            init_db[3] = int.Parse(textBox_b4_init.Text);
            init_db2[3] = int.Parse(textBox_b4_init.Text);
        }

        private void timer_drag_Tick(object sender, EventArgs e)
        {
            
            if (move_flag == 1)
            {
                Point mousePos = Control.MousePosition; mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                bts11.Location = bts11.Parent.PointToClient(mousePos);
            }
            else if (move_flag == 2)
            {
                Point mousePos = Control.MousePosition; mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                bts21.Location = bts21.Parent.PointToClient(mousePos);
            }
            else if (move_flag == 3)
            {
                Point mousePos = Control.MousePosition; mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                bts31.Location = bts31.Parent.PointToClient(mousePos);
            }
            else if (move_flag == 4)
            {
                Point mousePos = Control.MousePosition; mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                bts41.Location = bts41.Parent.PointToClient(mousePos);
            }
        }

        private void bts1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
            move_flag = 1;
            timer_drag.Enabled = true;
        }

        private void bts11_MouseUp(object sender, MouseEventArgs e)
        {
            timer_drag.Enabled = false;
            move_flag = 0;
        }

        private void bts21_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
            move_flag = 2;
            timer_drag.Enabled = true;
        }

        private void bts21_MouseUp(object sender, MouseEventArgs e)
        {
            timer_drag.Enabled = false;
            move_flag = 0;
        }

        private void bts31_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
            move_flag = 3;
            timer_drag.Enabled = true;
        }

        private void bts31_MouseUp(object sender, MouseEventArgs e)
        {
            timer_drag.Enabled = false;
            move_flag = 0;
        }

        private void bts41_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
            move_flag = 4;
            timer_drag.Enabled = true;
        }

        private void bts41_MouseUp(object sender, MouseEventArgs e)
        {
            timer_drag.Enabled = false;
            move_flag = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (true)
            {
                pan_x = e.Location.X;
                pan_y = e.Location.Y;


                int distance = (int)getpoint(e.Location.X, e.Location.Y, bts11.Left, bts11.Top);
                int db = init_db[0] - ff.Field_attenuation(distance, fre[0], init_db[0]);
                lbl_11.Text = "BTS1:" + db.ToString() + "dBm; " + distance.ToString() + "m";



                distance = (int)getpoint(e.Location.X, e.Location.Y, bts21.Left, bts21.Top);
                db = init_db[1] - ff.Field_attenuation(distance, fre[0], init_db[1]);
                lbl_12.Text = "BTS2:" + db.ToString() + "dBm; " + distance.ToString() + "m";



                distance = (int)getpoint(e.Location.X, e.Location.Y, bts31.Left, bts31.Top);
                db = init_db[2] - ff.Field_attenuation(distance, fre[0], init_db[2]);
                lbl_13.Text = "BTS3:" + db.ToString() + "dBm; " + distance.ToString() + "m";



                distance = (int)getpoint(e.Location.X, e.Location.Y, bts41.Left, bts41.Top);
                db = init_db[3] - ff.Field_attenuation(distance, fre[0], init_db[3]);
                lbl_14.Text = "BTS4:" + db.ToString() + "dBm; " + distance.ToString() + "m";

                // drow_line();
                if (listBox_no.Items.Count > 1)
                {
                    // g.Clear(Color.White);
                    for (int i = 0; i < listBox_no.Items.Count - 1; i++)
                    {
                        g.DrawLine(new Pen(Color.Red), new Point(int.Parse(listBox_x.Items[i].ToString()), int.Parse(listBox_y.Items[i].ToString())), new Point(int.Parse(listBox_x.Items[i + 1].ToString()), int.Parse(listBox_y.Items[i + 1].ToString())));
                    }
                }
            }
        }
        public double getpoint(int x1, int y1, int x2, int y2)
        {
            double res = 0;

            res = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));


            return res;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            fre[0] = int.Parse(textBox_b1_fre.Text);
            fre[1] = int.Parse(textBox_b2_fre.Text);
            fre[2] = int.Parse(textBox_b3_fre.Text);
            fre[3] = int.Parse(textBox_b4_fre.Text);

            init_db[0] = int.Parse(textBox_b1_init.Text);
            init_db[1] = int.Parse(textBox_b2_init.Text);
            init_db[2] = int.Parse(textBox_b3_init.Text);
            init_db[3] = int.Parse(textBox_b4_init.Text);
            // button12.BackColor = Color.Red;
            start = !start;
            set_pan = 1;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fre2[0] = int.Parse(textBox_b1_fre.Text);
            fre2[1] = int.Parse(textBox_b2_fre.Text);
            fre2[2] = int.Parse(textBox_b3_fre.Text);
            fre2[3] = int.Parse(textBox_b4_fre.Text);

            init_db2[0] = int.Parse(textBox_b1_init.Text);
            init_db2[1] = int.Parse(textBox_b2_init.Text);
            init_db2[2] = int.Parse(textBox_b3_init.Text);
            init_db2[3] = int.Parse(textBox_b4_init.Text);
            //  button5.BackColor = Color.Red;
            //timer2.Enabled = true;
            start = !start;
            set_pan = 2;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
        }


        public void add_point(int a, int b)
        {
            g = panel1.CreateGraphics();
            point_no += 1;
            listBox_no.Items.Add(point_no);

            listBox_x.Items.Add(a.ToString());
            listBox_y.Items.Add(b.ToString());

            if (listBox_no.Items.Count > 1)
            {
                g.Clear(System.Drawing.Color.FromArgb(35, 39, 42));
                for (int i = 0; i < listBox_no.Items.Count - 1; i++)
                {
                    g.DrawLine(new Pen(Color.Red), new Point(int.Parse(listBox_x.Items[i].ToString()), int.Parse(listBox_y.Items[i].ToString())), new Point(int.Parse(listBox_x.Items[i + 1].ToString()), int.Parse(listBox_y.Items[i + 1].ToString())));
                }
            }
            else
            {
                g = panel1.CreateGraphics();
            }
        }
        public void add_point2(int a, int b)
        {
            g2 = panel1.CreateGraphics();
            point_no2 += 1;
            listBox_no2.Items.Add(point_no2);

            listBox_x2.Items.Add(a.ToString());
            listBox_y2.Items.Add(b.ToString());

            if (listBox_no2.Items.Count > 1)
            {
                g2.Clear(System.Drawing.Color.FromArgb(35, 39, 42));
                for (int i = 0; i < listBox_no2.Items.Count - 1; i++)
                {
                    g2.DrawLine(new Pen(Color.Blue), new Point(int.Parse(listBox_x2.Items[i].ToString()), int.Parse(listBox_y2.Items[i].ToString())), new Point(int.Parse(listBox_x2.Items[i + 1].ToString()), int.Parse(listBox_y2.Items[i + 1].ToString())));
                }
            }
            else
            {
                g2 = panel1.CreateGraphics();
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (set_pan == 1)
            {
                if (CAR1_PAUSE == true)
                {
                    return;
                }
                list_x = pan_x;
                list_y = pan_y;

                add_point(list_x, list_y);

                list_count++;
                g_l[list_count] = panel1.CreateGraphics();

            }
            else if (set_pan == 2)
            {
                if (CAR2_PAUSE == true)
                {
                    return;
                }
                list2_x = pan_x;
                list2_y = pan_y;

                add_point2(list2_x, list2_y);

                list2_count++;
                g_l2[list2_count] = panel1.CreateGraphics();

            }
        }

        public void re_del_drow()
        {
            g = panel1.CreateGraphics();
            if (listBox_no.Items.Count >= 1)
            {
                g.Clear(System.Drawing.Color.FromArgb(35, 39, 42));
                for (int i = 0; i < listBox_no.Items.Count - 1; i++)
                {
                    g.DrawLine(new Pen(Color.Red), new Point(int.Parse(listBox_x.Items[i].ToString()), int.Parse(listBox_y.Items[i].ToString())), new Point(int.Parse(listBox_x.Items[i + 1].ToString()), int.Parse(listBox_y.Items[i + 1].ToString())));
                }
            }
            else
            {
                g = panel1.CreateGraphics();
                g.Clear(System.Drawing.Color.FromArgb(35, 39, 42));
            }

        }

        public void re_del_drow2()
        {
            g2 = panel1.CreateGraphics();
            if (listBox_no2.Items.Count >= 1)
            {
                g2.Clear(System.Drawing.Color.FromArgb(35, 39, 42));
                for (int i = 0; i < listBox_no2.Items.Count - 1; i++)
                {
                    g2.DrawLine(new Pen(Color.Blue), new Point(int.Parse(listBox_x2.Items[i].ToString()), int.Parse(listBox_y2.Items[i].ToString())), new Point(int.Parse(listBox_x2.Items[i + 1].ToString()), int.Parse(listBox_y2.Items[i + 1].ToString())));
                }
            }
            else
            {
                g2 = panel1.CreateGraphics();
                g2.Clear(System.Drawing.Color.FromArgb(35, 39, 42));
            }

        }

        public void re_drow2()
        {
            try
            {
                if (listBox_x2.Items.Count > 0 && listBox_y2.Items.Count > 0)
                {
                    if (textBox_point_x2.Text == listBox_x2.Items[listBox_x2.Items.Count - 1].ToString() && textBox_point_y2.Text == listBox_y2.Items[listBox_y2.Items.Count - 1].ToString())
                    {
                        return;
                    }
                }
                g2 = panel1.CreateGraphics();
                point_no2 += 1;
                listBox_no2.Items.Add(point_no2);

                listBox_x2.Items.Add(textBox_point_x2.Text);
                listBox_y2.Items.Add(textBox_point_y2.Text);

                if (listBox_no2.Items.Count > 1)
                {
                    g2.Clear(System.Drawing.Color.FromArgb(35, 39, 42));
                    for (int i = 0; i < listBox_no2.Items.Count - 1; i++)
                    {
                        g2.DrawLine(new Pen(Color.Blue), new Point(int.Parse(listBox_x2.Items[i].ToString()), int.Parse(listBox_y2.Items[i].ToString())), new Point(int.Parse(listBox_x2.Items[i + 1].ToString()), int.Parse(listBox_y2.Items[i + 1].ToString())));
                    }
                }
                else
                {
                    g2 = panel1.CreateGraphics();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        public void re_drow()
        {
            try
            {
                if (listBox_x.Items.Count > 0 && listBox_y.Items.Count > 0)
                {
                    if (textBox_point_x.Text == listBox_x.Items[listBox_x.Items.Count - 1].ToString() && textBox_point_y.Text == listBox_y.Items[listBox_y.Items.Count - 1].ToString())
                    {
                        return;
                    }
                }
                g = panel1.CreateGraphics();
                point_no += 1;
                listBox_no.Items.Add(point_no);

                listBox_x.Items.Add(textBox_point_x.Text);
                listBox_y.Items.Add(textBox_point_y.Text);

                if (listBox_no.Items.Count > 1)
                {
                    g.Clear(System.Drawing.Color.FromArgb(35, 39, 42));
                    for (int i = 0; i < listBox_no.Items.Count - 1; i++)
                    {
                        g.DrawLine(new Pen(Color.Red), new Point(int.Parse(listBox_x.Items[i].ToString()), int.Parse(listBox_y.Items[i].ToString())), new Point(int.Parse(listBox_x.Items[i + 1].ToString()), int.Parse(listBox_y.Items[i + 1].ToString())));
                    }
                }
                else
                {
                    g = panel1.CreateGraphics();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox_point_x.Text == "" || textBox_point_y.Text == "")
            {
                return;
            }
            re_drow();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox_point_x2.Text == "" || textBox_point_y2.Text == "")
            {
                return;
            }
            re_drow2();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox_no.SelectedIndex == -1)
            {
                return;
            }
            int should_move = listBox_no.SelectedIndex;
            listBox_x.Items.RemoveAt(should_move);
            listBox_y.Items.RemoveAt(should_move);
            listBox_no.Items.RemoveAt(listBox_no.Items.Count - 1);
            re_del_drow();
            re_del_drow2();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (listBox_no2.SelectedIndex == -1)
            {
                return;
            }
            int should_move = listBox_no2.SelectedIndex;
            listBox_x2.Items.RemoveAt(should_move);
            listBox_y2.Items.RemoveAt(should_move);
            listBox_no2.Items.RemoveAt(listBox_no2.Items.Count - 1);
            re_del_drow();
            re_del_drow2();
        }

        private void listBox_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox curr = (ListBox)sender;
            int id = curr.SelectedIndex;
            listBox_no.SelectedIndex = id;
            listBox_x.SelectedIndex = id;
            listBox_y.SelectedIndex = id;
        }

        private void listBox_no2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox cur = (ListBox)sender;
            int id = cur.SelectedIndex;
            listBox_no2.SelectedIndex = id;
            listBox_x2.SelectedIndex = id;
            listBox_y2.SelectedIndex = id;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            listBox_no.Items.Clear();
            listBox_x.Items.Clear();
            listBox_y.Items.Clear();

            re_del_drow();
            re_del_drow2();
            point_no = 0;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            listBox_no2.Items.Clear();
            listBox_x2.Items.Clear();
            listBox_y2.Items.Clear();

            re_del_drow();
            re_del_drow2();
            point_no2 = 0;
        }

        private void timer_ref_Tick(object sender, EventArgs e)
        {
            if (listBox_no.Items.Count > 1)
            {
                // g.Clear(Color.White);
                for (int i = 0; i < listBox_no.Items.Count - 1; i++)
                {
                    g.DrawLine(new Pen(Color.Red), new Point(int.Parse(listBox_x.Items[i].ToString()), int.Parse(listBox_y.Items[i].ToString())), new Point(int.Parse(listBox_x.Items[i + 1].ToString()), int.Parse(listBox_y.Items[i + 1].ToString())));

                }
            }

            if (listBox_no2.Items.Count > 1)
            {
                // g.Clear(Color.White);
                for (int i = 0; i < listBox_no2.Items.Count - 1; i++)
                {
                    g2.DrawLine(new Pen(Color.Blue), new Point(int.Parse(listBox_x2.Items[i].ToString()), int.Parse(listBox_y2.Items[i].ToString())), new Point(int.Parse(listBox_x2.Items[i + 1].ToString()), int.Parse(listBox_y2.Items[i + 1].ToString())));

                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (listBox_x.Items.Count <= 0)
            {
                return;
            }
            timer_car1.Enabled = false;
            CAR1_ISRUN = false;
            CAR1_PAUSE = false;
            m = 0;
            button10.Text = "CAR 1 RUN";
            pic_car1.Left = int.Parse(listBox_x.Items[0].ToString());
            pic_car1.Top = int.Parse(listBox_y.Items[0].ToString());
            button9.Enabled = true;
            button20.Enabled = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (listBox_x2.Items.Count <= 0)
            {
                return;
            }
            timer_car2.Enabled = false;
            CAR2_ISRUN = false;
            CAR2_PAUSE = false;
            m2 = 0;
            button17.Text = "CAR 2 RUN";
            pic_car2.Left = int.Parse(listBox_x2.Items[0].ToString());
            pic_car2.Top = int.Parse(listBox_y2.Items[0].ToString());
            button13.Enabled = true;
            button21.Enabled = true;
        }


        public int timer_count = 4;
        public int car_flag = -1;

        public int timer_count2 = 4;
        public int car_flag2 = -1;
        private void timer_car1_Tick(object sender, EventArgs e)
        {
            if (radioButton12.Checked)
            {
                if (m < 0)
                {
                    timer_count -= 1;
                    car_flag *= -1;
                    m = 0;
                    if (timer_count <= 0)
                    {
                        timer_car1.Enabled = false;
                        CAR1_ISRUN = false;
                        CAR1_PAUSE = false;
                        button10.Text = "CAR 1 RUN";
                        button9.Enabled = true;
                        m = 0;
                    }
                }
            }
            if (radioButton11.Checked)
            {
                car_flag = 1;
            }
            if (m < x.Count)
            {
                pic_car1.Left = (int)x[m];
                pic_car1.Top = (int)y[m];

                // pic_car1.set_xy(pic_car1.Left.ToString(), pic_car1.Top.ToString());

                label_db_11.Text = (init_db[0] - ff.Field_attenuation((int)getpoint(pic_car1.Left, pic_car1.Top, bts11.Left, bts11.Top), fre[0], init_db[0])).ToString();
                label_db_12.Text = (init_db[1] - ff.Field_attenuation((int)getpoint(pic_car1.Left, pic_car1.Top, bts21.Left, bts21.Top), fre[1], init_db[1])).ToString();
                label_db_13.Text = (init_db[2] - ff.Field_attenuation((int)getpoint(pic_car1.Left, pic_car1.Top, bts31.Left, bts31.Top), fre[2], init_db[2])).ToString();
                label_db_14.Text = (init_db[3] - ff.Field_attenuation((int)getpoint(pic_car1.Left, pic_car1.Top, bts41.Left, bts41.Top), fre[3], init_db[3])).ToString();
                step_count++;

            }
            else
            {
                if (radioButton12.Checked)
                {
                    car_flag *= -1;
                }
                if (radioButton11.Checked && (step_count >= timer_step))
                {
                    step_count = 0;
                    timer_car1.Enabled = false;
                    m = 0;
                    CAR1_ISRUN = false;
                    CAR1_PAUSE = false;
                    button10.Text = "CAR 1 RUN";
                    button9.Enabled = true;

                }
                if (radioButton11.Checked)
                {
                    m = 0;
                }

            }

            m += car_flag;






            if (listBox_no.Items.Count > 1)
            {
                // g.Clear(Color.White);
                for (int i = 0; i < listBox_no.Items.Count - 1; i++)
                {
                    g.DrawLine(new Pen(Color.Red), new Point(int.Parse(listBox_x.Items[i].ToString()), int.Parse(listBox_y.Items[i].ToString())), new Point(int.Parse(listBox_x.Items[i + 1].ToString()), int.Parse(listBox_y.Items[i + 1].ToString())));

                }
            }

            if (listBox_no2.Items.Count > 1)
            {
                // g.Clear(Color.White);
                for (int i = 0; i < listBox_no2.Items.Count - 1; i++)
                {
                    g2.DrawLine(new Pen(Color.Blue), new Point(int.Parse(listBox_x2.Items[i].ToString()), int.Parse(listBox_y2.Items[i].ToString())), new Point(int.Parse(listBox_x2.Items[i + 1].ToString()), int.Parse(listBox_y2.Items[i + 1].ToString())));

                }
            }
        }

        private void timer_car2_Tick(object sender, EventArgs e)
        {
            if (radioButton13.Checked)
            {
                if (m2 < 0)
                {
                    timer_count2 -= 1;
                    car_flag2 *= -1;
                    m2 = 0;
                    if (timer_count2 <= 0)
                    {
                        timer_car2.Enabled = false;
                        CAR2_ISRUN = false;
                        CAR2_PAUSE = false;
                        button13.Enabled = true;
                        m2 = 0;
                        button17.Text = "CAR 2 RUN";
                    }
                }
            }
            if (radioButton14.Checked)
            {
                car_flag2 = 1;
            }
            if (m2 < x2.Count)
            {
                pic_car2.Left = (int)x2[m2];
                pic_car2.Top = (int)y2[m2];

                // pic_car2.set_xy(pic_car2.Left.ToString(), pic_car2.Top.ToString());

                label_db2_11.Text = (init_db[0] - ff.Field_attenuation((int)getpoint(pic_car2.Left, pic_car2.Top, bts11.Left, bts11.Top), fre2[0], init_db2[0])).ToString();
                label_db2_12.Text = (init_db[1] - ff.Field_attenuation((int)getpoint(pic_car2.Left, pic_car2.Top, bts21.Left, bts21.Top), fre2[1], init_db2[1])).ToString();
                label_db2_13.Text = (init_db[2] - ff.Field_attenuation((int)getpoint(pic_car2.Left, pic_car2.Top, bts31.Left, bts31.Top), fre2[2], init_db2[2])).ToString();
                label_db2_14.Text = (init_db[3] - ff.Field_attenuation((int)getpoint(pic_car2.Left, pic_car2.Top, bts41.Left, bts41.Top), fre2[3], init_db2[3])).ToString();
                step_count2++;

            }
            else
            {
                if (radioButton13.Checked)
                {
                    car_flag2 *= -1;
                }
                if (radioButton14.Checked && (step_count2 >= timer_step2))
                {
                    step_count2 = 0;
                    timer_car2.Enabled = false;
                    m2 = 0;
                    CAR2_ISRUN = false;
                    CAR2_PAUSE = false;
                    button17.Text = "CAR 2 RUN";
                    button13.Enabled = true;
                }
                if (radioButton14.Checked)
                {
                    m2 = 0;
                }

            }

            m2 += car_flag2;






            if (listBox_no2.Items.Count > 1)
            {
                // g.Clear(Color.White);
                for (int i = 0; i < listBox_no2.Items.Count - 1; i++)
                {
                    g2.DrawLine(new Pen(Color.Blue), new Point(int.Parse(listBox_x2.Items[i].ToString()), int.Parse(listBox_y2.Items[i].ToString())), new Point(int.Parse(listBox_x2.Items[i + 1].ToString()), int.Parse(listBox_y2.Items[i + 1].ToString())));

                }
            }
            if (listBox_no.Items.Count > 1)
            {
                // g.Clear(Color.White);
                for (int i = 0; i < listBox_no.Items.Count - 1; i++)
                {
                    g.DrawLine(new Pen(Color.Red), new Point(int.Parse(listBox_x.Items[i].ToString()), int.Parse(listBox_y.Items[i].ToString())), new Point(int.Parse(listBox_x.Items[i + 1].ToString()), int.Parse(listBox_y.Items[i + 1].ToString())));

                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(!timer_send.Enabled)
                timer_send.Enabled = true;
            button9.Enabled = false;
            button20.Enabled = false;
            if (listBox_no.Items.Count <= 1)
            {
                MessageBox.Show("Please Drow the way point first\r\nERROR CODE:2100");
                return;
            }
            if (CAR1_ISRUN == false && CAR1_PAUSE == true)
            {
                timer_car1.Enabled = true;
                CAR1_ISRUN = true;
                button10.Text = "PAUSE";

                return;
            }
            if (CAR1_ISRUN == false)
            {

                try
                {
                    timer_count = int.Parse(textBox2.Text);

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    return;
                }
                if (radioButton11.Checked)
                {
                    //lbl_11.Hide();
                    //lbl_12.Hide();
                    //lbl_13.Hide();
                    //lbl_14.Hide();
                    start = false;
                    textBox_point_x.Text = listBox_x.Items[0].ToString();
                    textBox_point_y.Text = listBox_y.Items[0].ToString();
                    re_drow();
                }
                try
                {
                    fre[0] = int.Parse(textBox_b1_fre.Text);
                    fre[1] = int.Parse(textBox_b2_fre.Text);
                    fre[2] = int.Parse(textBox_b3_fre.Text);
                    fre[3] = int.Parse(textBox_b4_fre.Text);

                    init_db[0] = int.Parse(textBox_b1_init.Text);
                    init_db[1] = int.Parse(textBox_b2_init.Text);
                    init_db[2] = int.Parse(textBox_b3_init.Text);
                    init_db[3] = int.Parse(textBox_b4_init.Text);




                    pic_car1.Left = int.Parse(listBox_x.Items[0].ToString());
                    pic_car1.Top = int.Parse(listBox_y.Items[0].ToString());

                    drow_line();

                    if (int.Parse(textBox1.Text) > 300)
                    {
                        textBox1.Text = "300";
                    }
                    timer_car1.Interval = 1000 / ((int)(int.Parse(textBox1.Text) * 0.277777));
                    timer_car1.Enabled = true;

                    timer_step = x.Count * (timer_count - 1);
                    button10.Text = "PAUSE";
                    CAR1_ISRUN = true;
                    CAR1_PAUSE = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                CAR1_ISRUN = false;
                timer_car1.Enabled = false;
                button10.Text = "CAR 1 RUN";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (!timer_send.Enabled)
                timer_send.Enabled = true;
            button13.Enabled = false;
            button21.Enabled = false;
            if (listBox_no2.Items.Count <= 1)
            {
                MessageBox.Show("Please Drow the way point first\r\nERROR CODE:2100");
                return;
            }
            if (CAR2_ISRUN == false && CAR2_PAUSE == true)
            {
                timer_car2.Enabled = true;
                CAR2_ISRUN = true;
                button17.Text = "PAUSE";
                return;
            }

            if (CAR2_ISRUN == false)
            {

                try
                {
                    timer_count2 = int.Parse(textBox6.Text);

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    return;
                }
                if (radioButton14.Checked)
                {
                    //lbl_1.Hide();
                    //lbl_2.Hide();
                    //lbl_3.Hide();
                    //lbl_4.Hide();
                    start = false;
                    textBox_point_x2.Text = listBox_x2.Items[0].ToString();
                    textBox_point_y2.Text = listBox_y2.Items[0].ToString();
                    re_drow2();
                }
                try
                {
                    fre2[0] = int.Parse(textBox_b1_fre.Text);
                    fre2[1] = int.Parse(textBox_b2_fre.Text);
                    fre2[2] = int.Parse(textBox_b3_fre.Text);
                    fre2[3] = int.Parse(textBox_b4_fre.Text);

                    init_db2[0] = int.Parse(textBox_b1_init.Text);
                    init_db2[1] = int.Parse(textBox_b2_init.Text);
                    init_db2[2] = int.Parse(textBox_b3_init.Text);
                    init_db2[3] = int.Parse(textBox_b4_init.Text);




                    pic_car2.Left = int.Parse(listBox_x2.Items[0].ToString());
                    pic_car2.Top = int.Parse(listBox_y2.Items[0].ToString());

                    drow_line2();
                    if (int.Parse(textBox9.Text) > 300)
                    {
                        textBox9.Text = "300";
                    }
                    timer_car2.Interval = 1000 / ((int)(int.Parse(textBox9.Text) * 0.277777));
                    timer_car2.Enabled = true;

                    timer_step2 = x2.Count * (timer_count2 - 1);
                    button17.Text = "PAUSE";
                    CAR2_ISRUN = true;
                    CAR2_PAUSE = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                CAR2_ISRUN = false;
                timer_car2.Enabled = false;
                button17.Text = "CAR 2 RUN";
            }
        }


        public void drow_line()
        {
            int current_x = 0;
            int current_y = 0;
            int current_list_count = 0;
            double current_hold = 0;

            int P1_x = 0;
            int P1_y = 0;
            int P2_x = 0;
            int P2_y = 0;
            int x_FLD = 1;
            int y_FLD = 1;

            int ONE_TIME_count = 0;

            double LP = 0.0;

            x.Clear();
            y.Clear();

            while (current_list_count < listBox_no.Items.Count - 1)
            {
                current_x = Math.Abs(int.Parse(listBox_x.Items[current_list_count].ToString()) - int.Parse(listBox_x.Items[current_list_count + 1].ToString()));
                current_y = Math.Abs(int.Parse(listBox_y.Items[current_list_count].ToString()) - int.Parse(listBox_y.Items[current_list_count + 1].ToString()));


                P1_x = int.Parse(listBox_x.Items[current_list_count].ToString());
                P1_y = int.Parse(listBox_y.Items[current_list_count].ToString());
                P2_x = int.Parse(listBox_x.Items[current_list_count + 1].ToString());
                P2_y = int.Parse(listBox_y.Items[current_list_count + 1].ToString());

                current_hold = Math.Sqrt((P1_x - P2_x) * (P1_x - P2_x) + (P1_y - P2_y) * (P1_y - P2_y));

                LP = 1.0 / current_hold;
                if (P1_x > P2_x)
                {
                    x_FLD = -1;
                }
                else
                {
                    x_FLD = 1;
                }

                if (P1_y > P2_y)
                {
                    y_FLD = -1;
                }
                else
                {
                    y_FLD = 1;
                }

                for (ONE_TIME_count = 0; ONE_TIME_count < current_hold; ONE_TIME_count++)
                {
                    x.Add(P1_x + LP * current_x * ONE_TIME_count * x_FLD);
                    y.Add(P1_y + LP * current_y * ONE_TIME_count * y_FLD);
                }
                current_list_count++;
            }
        }
        public void drow_line2()
        {
            int current_x = 0;
            int current_y = 0;
            int current_list_count = 0;
            double current_hold = 0;

            int P1_x = 0;
            int P1_y = 0;
            int P2_x = 0;
            int P2_y = 0;
            int x_FLD = 1;
            int y_FLD = 1;

            int ONE_TIME_count = 0;

            double LP = 0.0;

            x2.Clear();
            y2.Clear();

            while (current_list_count < listBox_no2.Items.Count - 1)
            {
                current_x = Math.Abs(int.Parse(listBox_x2.Items[current_list_count].ToString()) - int.Parse(listBox_x2.Items[current_list_count + 1].ToString()));
                current_y = Math.Abs(int.Parse(listBox_y2.Items[current_list_count].ToString()) - int.Parse(listBox_y2.Items[current_list_count + 1].ToString()));


                P1_x = int.Parse(listBox_x2.Items[current_list_count].ToString());
                P1_y = int.Parse(listBox_y2.Items[current_list_count].ToString());
                P2_x = int.Parse(listBox_x2.Items[current_list_count + 1].ToString());
                P2_y = int.Parse(listBox_y2.Items[current_list_count + 1].ToString());

                current_hold = Math.Sqrt((P1_x - P2_x) * (P1_x - P2_x) + (P1_y - P2_y) * (P1_y - P2_y));

                LP = 1.0 / current_hold;
                if (P1_x > P2_x)
                {
                    x_FLD = -1;
                }
                else
                {
                    x_FLD = 1;
                }

                if (P1_y > P2_y)
                {
                    y_FLD = -1;
                }
                else
                {
                    y_FLD = 1;
                }
                for (ONE_TIME_count = 0; ONE_TIME_count < current_hold; ONE_TIME_count++)
                {
                    x2.Add(P1_x + LP * current_x * ONE_TIME_count * x_FLD);
                    y2.Add(P1_y + LP * current_y * ONE_TIME_count * y_FLD);
                }
                current_list_count++;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (CAR1_ISRUN == false && CAR2_ISRUN == false && CAR1_PAUSE == false && CAR2_PAUSE == false)
            {
                button10_Click(null, null);
                button17_Click(null, null);
            }
            else
            {
                MessageBox.Show("Please reset all the cars first!\r\nClick 'RESET' button for each car\r\n");
                return;
            }
        }

        private int count_number(string value)
        {
            string[] data = value.Split(' ');
            if (data.Length == 4)
            {
                int i = int.Parse(data[1]) - 1;
                int o = int.Parse(data[3]) - 1;
                return (i * 8 + o + 1);
            }
            else
            {
                return 0;
            }
        }

        private void timer_send_Tick(object sender, EventArgs e)
        {
            if (initial)
            {
                if (label_db2_11.Text == Global.old_value_car2[0].ToString() && label_db2_12.Text == Global.old_value_car2[1].ToString() && label_db2_13.Text == Global.old_value_car2[2].ToString() && label_db2_14.Text == Global.old_value_car2[3].ToString())
                {
                    // return;
                }
                else
                {
                    if (!dad.dad.cs.sendvalue(String.Format("SA {0} {1};{2} {3};{4} {5};{6} {7}", count_number(comboBox1.Text), ((init_db[0] - int.Parse(label_db2_11.Text)) * dad.dad.ATTStep).ToString(), count_number(comboBox3.Text), ((init_db[1] - int.Parse(label_db2_12.Text)) * dad.dad.ATTStep).ToString(), count_number(comboBox5.Text), ((init_db[2] - int.Parse(label_db2_13.Text)) * dad.dad.ATTStep).ToString(), count_number(comboBox7.Text), ((init_db[3] - int.Parse(label_db2_14.Text)) * dad.dad.ATTStep).ToString()), 2000, "sa", !dad.dad.reserved))
                    {
                        timer_send.Enabled = false;
                        CAR1_ISRUN = false;
                        timer_car1.Enabled = false;
                        button10.Text = "CAR 1 RUN";
                        CAR2_ISRUN = false;
                        timer_car2.Enabled = false;
                        button17.Text = "CAR 2 RUN";
                        MessageBox.Show("Connection error!");
                        return;
                    }
                    Global.old_value_car2[0] = int.Parse(label_db2_11.Text);
                    Global.old_value_car2[1] = int.Parse(label_db2_12.Text);
                    Global.old_value_car2[2] = int.Parse(label_db2_13.Text);
                    Global.old_value_car2[3] = int.Parse(label_db2_14.Text);
                }


                if (label_db_11.Text == Global.old_value_car1[0].ToString() && label_db_12.Text == Global.old_value_car1[1].ToString() && label_db_13.Text == Global.old_value_car1[2].ToString() && label_db_14.Text == Global.old_value_car1[3].ToString())
                {
                    //  return;
                }
                else
                {
                    if (!dad.dad.cs.sendvalue(String.Format("SA {0} {1};{2} {3};{4} {5};{6} {7}", count_number(comboBox2.Text), (init_db[0] - int.Parse(label_db_11.Text)).ToString(), count_number(comboBox4.Text), ((init_db[1] - int.Parse(label_db_12.Text)) * dad.dad.ATTStep).ToString(), count_number(comboBox6.Text), ((init_db[2] - int.Parse(label_db_13.Text)) * dad.dad.ATTStep).ToString(), count_number(comboBox8.Text), ((init_db[3] - int.Parse(label_db_14.Text)) * dad.dad.ATTStep).ToString()), 2000, "sa", !dad.dad.reserved))
                    { timer_send.Enabled = false; }
                    //cm.sendvalue(String.Format("ATT {0} {1};{2} {3};{4} {5};{6} {7}", (comboBox1.SelectedIndex + 1).ToString(), label_db2_11.Text, (comboBox3.SelectedIndex + 1).ToString(), label_db2_12.Text, (comboBox5.SelectedIndex + 1).ToString(), label_db2_13.Text, (comboBox7.SelectedIndex + 1).ToString(), label_db2_14.Text));
                    Global.old_value_car1[0] = int.Parse(label_db_11.Text);
                    Global.old_value_car1[1] = int.Parse(label_db_12.Text);
                    Global.old_value_car1[2] = int.Parse(label_db_13.Text);
                    Global.old_value_car1[3] = int.Parse(label_db_14.Text);
                }
            }
        }

        private void bts11_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
            move_flag = 1;
            timer_drag.Enabled = true;
        }

        private void bts11_MouseUp_1(object sender, MouseEventArgs e)
        {
            timer_drag.Enabled = false;
        }

        private void bts21_MouseDown_1(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
            move_flag = 2;
            timer_drag.Enabled = true;
        }

        private void bts21_MouseUp_1(object sender, MouseEventArgs e)
        {
            timer_drag.Enabled = false;
        }

        private void bts31_MouseDown_1(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
            move_flag = 3;
            timer_drag.Enabled = true;
        }

        private void bts31_MouseUp_1(object sender, MouseEventArgs e)
        {
            timer_drag.Enabled = false;
        }

        private void bts41_MouseDown_1(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
            move_flag = 4;
            timer_drag.Enabled = true;
        }

        private void bts41_MouseUp_1(object sender, MouseEventArgs e)
        {
            timer_drag.Enabled = false;
        }

    }
}
