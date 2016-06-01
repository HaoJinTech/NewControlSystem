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
    public partial class sweep_task : UserControl
    {
        public int running = 0;
        int task_count = -1;
        public List<list_pad> pannel_list=new List<list_pad>();

        int should_remove = -1;
        public Form1 dad;
        public sweep_task()
        {
            InitializeComponent();
        }

        public void set_dad(Form1 _dad)
        {
            dad=_dad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            create_new_pannel();
        }
        public void create_new_pannel()
        {
            try
            {
                task_count += 1;
                pannel_list.Add(new list_pad(this));
                pannel_list[task_count].task_no = task_count;
                pannel_list[task_count].SET_ALL(textBox_task_name.Text, int.Parse(comboBox_in.Text), int.Parse(comboBox_out.Text), (int)n_interval.Value, (int)n_times.Value, (double)n_start.Value, (double)n_end.Value, (double)n_step.Value);
                pannel_list[task_count].Create_Task_Panel();
                show_pannel_list();
            }
            catch
            {
                task_count -= 1;
                MessageBox.Show("Invalid parameters!","Adding task failed");
            }
            
        }

        public void show_pannel_list()
        {
            panel_task_list.Controls.Add(pannel_list[task_count]);
            pannel_list[task_count].Width = panel_task_list.Width - 40;
            pannel_list[task_count].Left = 10;
            pannel_list[task_count].Top = lb_pot.Top + pannel_list[task_count].Height*task_count;
            pannel_list[task_count].Show();
        }

        public void remove_task(int task_no)
        {
            should_remove = task_no;
            //timer_remove.Enabled = true;
            remove_func();
        }

        private void remove_func()
        {
            pannel_list[should_remove].Visible = false;
            pannel_list.RemoveAt(should_remove);
            task_count -= 1;
            re_code_task_no();
        }

        private void timer_remove_Tick(object sender, EventArgs e)
        {
            if (pannel_list[should_remove].Left <= panel_task_list.Width)
            {
                pannel_list[should_remove].Left += 100;
            }
            else
            {
                pannel_list[should_remove].Visible = false;
                pannel_list.RemoveAt(should_remove);
                timer_remove.Enabled = false;
                task_count -= 1;
                re_code_task_no();
            }
        }

        public double check_value(double inner)
        {
            int getin = (int)(inner * 2);
            double getout = (double)getin / 2.0;
            return getout;
        }

        public void re_code_task_no()
        {
            for (int i = 0; i < task_count + 1; i++)
            {
                pannel_list[i].task_no = i;
            }
            for (int i = 0; i < task_count + 1; i++)
            {
                pannel_list[i].Top = lb_pot.Top + pannel_list[i].Height * i;

            }
        }
        public void run_login()
        {
            dad.cs.sendvalue("USER " + dad.login_id);
        }
        public void check_availabe()
        {
            comboBox_out.Items.Clear();
            for (int i = 0; i < dad.ct.port_out.Length; i++)
            {
                if (dad.login_id != "0" && dad.ld.list_data[0, i].channel_reverse == dad.login_id)
                {
                    comboBox_out.Items.Add((i + 1).ToString());
                }
            }
        }

        private void timer_run_Tick(object sender, EventArgs e)
        {
            string str = "ATT ";
            if (running <= 0)
            {
                timer_run.Enabled = false;
                dad.cs.sendvalue("LOGOUT");
            }
            for (int i = 0; i < pannel_list.Count; i++)
            {
                if (pannel_list[i].run_type == 1 && pannel_list[i].sendout_value >= 0)
                {
                    str += pannel_list[i].send_message();
                    pannel_list[i].sendout_value = -1;
                }
            }
            
            if (str != "ATT ")
            {
                dad.cs.sendvalue(str);
            }
        }

        private void n_step_ValueChanged(object sender, EventArgs e)
        {
            n_step.Value = (decimal)check_value((double)n_step.Value);
        }

        private void n_end_ValueChanged(object sender, EventArgs e)
        {
            n_end.Value = (decimal)check_value((double)n_end.Value);
        }

        private void n_start_ValueChanged(object sender, EventArgs e)
        {
            n_start.Value = (decimal)check_value((double)n_start.Value);
        }

        private void n_interval_ValueChanged(object sender, EventArgs e)
        {
            n_interval.Value = ((int)n_interval.Value / 100) * 100;
        }

        private void panel_task_list_SizeChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < pannel_list.Count; i++)
            {
                pannel_list[i].Width = panel_task_list.Width - 40;
            }
        }
    }
}
