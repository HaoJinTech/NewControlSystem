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
    public partial class list_pad : UserControl
    {
        private String task_name;
        private int Channel_in;
        private int Channel_out;
        private int interval_all;
        private int times;
        private double start_db;
        private double end_db;
        private double step;
        public int run_type = 0;
        private int running_times = -1;
        private int current_value = 0;
        public int sendout_value = -1;
        private bool reverse = false;
        public Boolean SWEEP_NOW = false;

        public int task_no;
        sweep_task dad;

        public list_pad(sweep_task _dad)
        {

            InitializeComponent();
            dad = _dad;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void SET_ALL(String TaskName,int Channel_IN_NO,int Channel_OUT_NO,int Interval_set,int Times_set,double start_db_set,double end_db_set,double step_set)
        {
            task_name = TaskName;
            Channel_in = Channel_IN_NO;
            Channel_out = Channel_OUT_NO;
            interval_all = Interval_set;
            times = Times_set;
            start_db = start_db_set;
            end_db = end_db_set;
            step = step_set;
        }

        public void Create_Task_Panel()
        {
            label_TaskName.Text = task_name;
            label_in_ch.Text = Channel_in.ToString();
            label_out_ch.Text = Channel_out.ToString();
            label_interval.Text = interval_all.ToString();
            label_times.Text = times.ToString();
            //MessageBox.Show(label_db_end.ForeColor.ToString());
            label_db_start.Text = start_db.ToString("0.0");
            label_db_end.Text = end_db.ToString("0.0");
            label_step.Text = step.ToString("0.0");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            button_STOP.Visible = true;
            button_PAUSE.Visible = true;
            button_RUN.Enabled = false;
            button_DELETE.Enabled = false;
            pictureBox_RUN.Enabled = true;
            pictureBox_RUN.Visible = true;
            SWEEP_NOW = true;
            start_sweep();
        }
        public void start_sweep()
        {
            if (dad.running == 0)
            {
                dad.run_login();
            }
            dad.running += 1;
            Thread.Sleep(100);
            dad.dad.cs.sendvalue("ATT " + Channel_in + " " + Channel_out + " " + ((int)(2 * start_db)).ToString());
            current_value = (int)(2 * start_db);
            run_type = 1;
            running_times = -1;
            timer1.Interval = interval_all;
            timer1.Enabled = true;
            dad.timer_run.Enabled = true;
            //发送开始sweep命令

        }
        public void pause_sweep()
        {
            //发送暂停sweep命令
            timer1.Enabled = false;
            run_type = 2;
        }
        public void continue_task()
        {
            //发送继续sweep命令
            timer1.Enabled = true;
            run_type = 1;
        }
        public void stop_sweep()
        {
            //发送停止sweep命令
            
            reverse = false;
            run_type = 0;
            dad.running -= 1;
            timer1.Enabled = false;
            current_value = (int)(2 * start_db);
        }

        private void button_PAUSE_Click(object sender, EventArgs e)
        {
            if (SWEEP_NOW)
            {
                button_PAUSE.Text = "CONTINUE";
                SWEEP_NOW = false;
                pause_sweep();
                pictureBox_RUN.Enabled = false;
            }
            else
            {
                button_PAUSE.Text = "PAUSE TASK";
                SWEEP_NOW = true;
                continue_task();
                pictureBox_RUN.Enabled = true;
            }
        }

        private void button_STOP_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button_RUN.Enabled = true;
            button_STOP.Visible = false;
            button_PAUSE.Visible = false;
            button_DELETE.Enabled = true;
            SWEEP_NOW = false;
            pictureBox_RUN.Visible = false;
            pictureBox_RUN.Enabled = false;
            stop_sweep();
        }

        private void button_DELETE_Click(object sender, EventArgs e)
        {
            dad.remove_task(task_no);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int current = counting_next();
            if (running_times >= times)
            {
                button_STOP.PerformClick();
            }
            else
            {
                sendout_value = current;
            }
        }

        private int counting_next()
        {
            int xp = ((int)(end_db * 2) - (int)(start_db * 2)) / Math.Abs((int)(end_db * 2) - (int)(start_db * 2));
            if (xp * current_value >= xp * (int)(2 * end_db))
            {
                reverse = true;
            }
            else if (xp * current_value <= xp * (int)(2 * start_db))
            {
                running_times += 1;
                reverse = false;
            }
            if (reverse)
            {
                current_value -= (int)(step * 2) * xp;
            }
            else
            {
                current_value += (int)(step * 2) * xp;
            }
            if (xp * current_value >= xp * (int)(2 * end_db))
            {
                current_value = (int)(2 * end_db);
            }
            else if (xp * current_value <= xp * (int)(2 * start_db))
            {
                current_value = (int)(2 * start_db);
            }
            return current_value;
        }

        public string send_message()
        {
            string str = Channel_in.ToString() + " " + Channel_out.ToString() + " " + sendout_value + ";";
            return str;
        }
    }
}
