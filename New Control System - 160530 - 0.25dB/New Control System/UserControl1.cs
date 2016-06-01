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
    public partial class UserControl1 : UserControl
    {

        //====
        public string sending_message = "";
        private int running_times = -1;
        private bool reverse = false;
        public string reserved_id = "";
        private int current_value = 0;
        private int sendout_value = 0;
        private int IN, OUT, interval, times;
        private float start, end, step;
        private int counting_pause = 0;
        private int channel, m_start, m_end, m_step, m_interval, m_pause, m_times;
        public void set_value(int _in, int _out, float _start, float _end, float _step, int _interval, int _pause, int _times)
        {
            IN = _in;
            OUT = _out;
            start = _start;
            end = _end;
            step = _step;
            interval = _interval;
            times = _times;
            channel = (IN - 1) * 8 + OUT;
            m_start = (int)(start * (float)dad.ATTStep);
            m_end = (int)(end * (float)dad.ATTStep);
            m_step = (int)(step * (float)dad.ATTStep);
            m_interval = interval / 10;
            m_pause = _pause;
            m_times = times;
            timer1.Interval = interval;
        }

        private int counting_next()
        {
            int xp = (m_end - m_start) / Math.Abs(m_end - m_start);
            if (xp * current_value >= xp * m_end)
            {
                reverse = true;
            }
            else if (xp * current_value <= xp * m_start)
            {
                running_times += 1;
                reverse = false;
            }
            if (reverse)
            {
                current_value -= m_step * xp;
            }
            else
            {
                current_value += m_step * xp;
            }
            if (xp * current_value >= xp * m_end)
            {
                current_value = m_end;
            }
            else if (xp * current_value <= xp * m_start)
            {
                current_value = m_start;
            }
            return current_value;
        }
        public void run_sweep()
        {
            reverse = false;
            running_times = -1;
            current_value = m_start;
            counting_pause = 0;
            timer1.Enabled = true;

        }

        public void stop_sweep()
        {
            timer1.Enabled = false;
            running_times = -1;
            current_value = m_start;
            reverse = false;
        }




        //==
        BigDad dad;
        public UserControl1(BigDad _dad)
        {
            dad = _dad;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counting_pause <= 0)
            {
                int current = counting_next();
                if (current == m_start)
                {
                    counting_pause = m_pause;
                }
                if (times != 0)
                {
                    if (running_times >= times)
                    {
                        sending_message = "OVER";
                        timer1.Enabled = false;
                    }

                    else
                    {
                        sendout_value = current;
                        sending_message = IN + " " + OUT + " " + sendout_value + " ";
                    }
                }
                else
                {
                    sendout_value = current;
                    sending_message = IN + " " + OUT + " " + sendout_value + " ";
                }
            }
            else
            {
                counting_pause -= timer1.Interval;
            }
        }






    }
}
