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
    public partial class Sweep : UserControl
    {
        private bool ok = false;
        BigDad dad;
        public Sweep(BigDad _dad)
        {
            dad = _dad;
            InitializeComponent();
        }
        public void set_Dad(BigDad _dad)
        {
            dad = _dad;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int index = e.RowIndex;
                int channel = (int.Parse(dataGridView1.Rows[index].Cells[1].Value.ToString()) - 1) * 8 + int.Parse(dataGridView1.Rows[index].Cells[2].Value.ToString());
                string str = "SWP " + channel + " " + dataGridView1.Rows[index].Cells[3].Value + " " + dataGridView1.Rows[index].Cells[4].Value + " " +
                    dataGridView1.Rows[index].Cells[5].Value + " " + dataGridView1.Rows[index].Cells[6].Value + " " + dataGridView1.Rows[index].Cells[7].Value;
            }
        }
        public void reserve_state(bool i)
        {
            if (i == true)
            {
                bt_add.Enabled = true;
                bt_del.Enabled = true;
                bt_run.Enabled = true;
                bt_stop.Enabled = true;
                comboBox_in.Enabled = true;
                comboBox_out.Enabled = true;
                res_changed();
            }
            else
            {
                bt_add.Enabled = false;
                bt_del.Enabled = false;
                bt_run.Enabled = false;
                bt_stop.Enabled = false;
                comboBox_in.Enabled = false;
                comboBox_out.Enabled = false;
                for (int a = 0; a < list_sweep.Count; a++)
                {
                    if (list_sweep[a].timer1.Enabled)
                    {
                        stop(a);
                    }
                }
            }
        }
        private void Sweep_Load(object sender, EventArgs e)
        {


        }

        private void add_sweep(int pi, int po, float start, float end, float step, int interval, int pause, int loops)
        {
            dataGridView1.Rows.Add(false, pi, po, start, end, step, interval, pause, loops);
            
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            try
            {
                add_sweep_item(int.Parse(comboBox_in.SelectedItem.ToString()), int.Parse(comboBox_out.SelectedItem.ToString()), (float)n_start.Value,
                    (float)n_end.Value, (float)n_step.Value, (int)n_interval.Value,(int)n_pause.Value, (int)n_times.Value);
                ok = true;
            }
            catch(Exception err)
            {
                LogContext.theInst.LogPrint(err.ToString(), 2);
                return;
            }
        }

        private void cb_sall_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_sall.Checked)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = 1;
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = 0;
                }
            }
        }

        private void bt_run_Click(object sender, EventArgs e)
        {
            bool nonselected = true;
            for (int p = 0; p < list_sweep.Count; p++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[p].Cells[0].Value))
                {
                    nonselected = false;
                    break;
                }
            }
            if (nonselected)
            { return; }
            if (!dad.reserved)
            {
                dad.ct.reserved_Set();
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value))
                {
                    run(i);
                }
            }
            //timer_run.Enabled=true;
            //dad.uc.timer1.Enabled = true;
        }

        public void run(int i)
        {
            timer_run.Enabled = true;
            list_sweep[i].run_sweep();
            pictureBox1.Visible = true;
            dataGridView1.Rows[i].Cells[9].Value= Properties.Resources.greenlight;
        }
        public void stop(int i)
        {
            list_sweep[i].stop_sweep();
            dataGridView1.Rows[i].Cells[9].Value = Properties.Resources.redlight;
            for (int a = 0; a < list_sweep.Count; a++)
            {
                if (list_sweep[a].Enabled)
                { return; }
            }
            timer_run.Enabled = false;
            pictureBox1.Visible = false;
            if (dad.reserved)
            {
                dad.ct.reserved_Set();
                reserve_state(false);
            }
        }

        public void res_changed()//in out 设置有哪些可用
        {
            int c_i = -1;
            comboBox_in.Items.Clear();
            comboBox_out.Items.Clear();
            for (int i = 0; i < dad.ct.port_out.Length; i++)
            {
                if (dad.login_id != "0" && dad.ld.list_data[0, i].channel_reverse == dad.login_id)
                {
                    comboBox_out.Items.Add((i + 1).ToString());
                    c_i = i;
                }
            }
            if (c_i != -1)
            {
                for (int o = 0; o < dad.ct.port_in.Length; o++)
                {
                    if (dad.login_id != "0" && dad.ld.list_data[o, c_i].channel_reverse == dad.login_id)
                    {
                        comboBox_in.Items.Add((o + 1).ToString());
                    }
                }
            }
            user_changed(dad.login_id);
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (list_sweep[i].timer1.Enabled)
                {
                    stop(i);
                }
            }
        }

        private void cb_q_CheckedChanged(object sender, EventArgs e)
        {
            //t_query.Enabled = cb_q.Checked;
        }

        private void timer_run_Tick(object sender, EventArgs e)
        {
            int li = timer_run.Interval;
            string str = "ATT ";
            bool all_stop = true;
            for (int i = 0; i < list_sweep.Count; i++)
            {
                if (list_sweep[i].timer1.Enabled)
                { all_stop = false; }
            }
            if(all_stop)
            {
                timer_run.Enabled = false;
                dad.ct.reserved_Set();
                pictureBox1.Visible = false;
            }
            for (int i = 0; i < list_sweep.Count; i++)
            {
                if (list_sweep[i].sending_message != "" && list_sweep[i].sending_message != "OVER")
                {
                    str += list_sweep[i].sending_message;
                    list_sweep[i].sending_message = "";
                }
                else if (list_sweep[i].sending_message == "OVER")
                {
                    dataGridView1.Rows[i].Cells[9].Value = Properties.Resources.redlight;
                    list_sweep[i].sending_message = "";
                }
            }
            if (str != "ATT ")
            {
                if (dad.cs.sendvalue(str, 2000, "ATT", false))
                {
                    dad.st_l1.Text = "Sweep:";
                    dad.st_l2.Text = str;
                }
                else
                {
                    dad.st_l1.Text = "Error:";
                    dad.st_l2.Text = "Sweep is stopped for some error!";
                    for (int a = 0; a < dataGridView1.Rows.Count; a++)
                    {
                        dataGridView1.Rows[a].Cells[9].Value = Properties.Resources.redlight;
                    }
                    timer_run.Enabled = false;
                    pictureBox1.Visible = false;
                }
            }
        }
        //===========================================
        //===========================================
        //===========================================
        //===========================================
        //==========================================================
        //==========================================================
        //==========================================================
        public List<UserControl1> list_sweep = new List<UserControl1>();
        public void add_sweep_item(int _in, int _out, float _start, float _end, float _step, int _interval, int _pause, int _times)
        {
            for (int i = 0; i <dataGridView1.Rows.Count ; i++)
            {
                if ((int)dataGridView1.Rows[i].Cells[1].Value == _in && (int)dataGridView1.Rows[i].Cells[2].Value == _out)
                {
                    dad.st_l1.Text = "Error:";
                    dad.st_l2.Text = "The channel has been used!";
                    return;
                }
            }
            UserControl1 si = new UserControl1(dad);
            si.set_value(_in, _out, _start, _end, _step, _interval, _pause, _times);
            list_sweep.Add(si);
            si.reserved_id = dad.login_id;
            add_sweep(_in, _out, _start, _end, _step, _interval, _pause, _times);
        }
        public void delete_sweep_item(int i)
        {
            list_sweep[i].stop_sweep();
            list_sweep.RemoveAt(i);
            dataGridView1.Rows.RemoveAt(i);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (ok == true)
            {
                int row = e.RowIndex;
                list_sweep[row].set_value(Convert.ToInt32(dataGridView1.Rows[row].Cells[1].Value),
                    Convert.ToInt32(dataGridView1.Rows[row].Cells[2].Value), (float)Convert.ToDouble(dataGridView1.Rows[row].Cells[3].Value),
                    (float)Convert.ToDouble(dataGridView1.Rows[row].Cells[4].Value), (float)Convert.ToDouble(dataGridView1.Rows[row].Cells[5].Value),
                    Convert.ToInt32(dataGridView1.Rows[row].Cells[6].Value), Convert.ToInt32(dataGridView1.Rows[row].Cells[7].Value),
                    Convert.ToInt32(dataGridView1.Rows[row].Cells[8].Value));
            }
        }

        private void bt_del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            { return; }
            int id = dataGridView1.SelectedRows[0].Index;
            delete_sweep_item(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dad.ct.reserved_Set();
        }

        public void user_changed(string id)
        {
            for (int n = 0; n < list_sweep.Count; n++)
            {
                if (id != list_sweep[n].reserved_id)
                {
                    if (list_sweep[n].timer1.Enabled == true)
                    {
                        stop(n);
                    }
                    dataGridView1.Rows[n].Cells[0].Value = false;
                    dataGridView1.Rows[n].ReadOnly = true;
                    dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightPink;
                    dataGridView1.Rows[n].Selected = false;
                }
                else
                {
                    dataGridView1.Rows[n].ReadOnly = false;
                    dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.White;
                }
            }
            if (id == "")
            {
                lbl_swp.Text = "Guest";
            }
            else
            {
                lbl_swp.Text = "USER:" + id;
            }

        }

    }
}
