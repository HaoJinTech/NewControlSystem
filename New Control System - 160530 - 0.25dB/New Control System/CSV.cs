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
    public partial class CSV : UserControl
    {
        public CSV()
        {
            InitializeComponent();
        }

        BigDad dad;
        CSVReader cr = new CSVReader();
        DataTable dt = new DataTable();
        Thread run_t;
        int current_row = 1;
        int current_loo = 0;
        bool running = false;
        List<int> List_sending_ch = new List<int>();
        public void set_Dad(BigDad _dad)
        {
            dad = _dad;
        }

        public void canbe(int bo)
        {
            if (bo == 1)
            {
                button1.Enabled = true;
                bt_load.Enabled = true;
                btn_stop.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                bt_load.Enabled = false;
                btn_stop.Enabled = false;
            }
        }
        private void open_new_table(string filename)
        {
            dt = new DataTable();
            dataGridView1.DataSource = dt;
            if (!cr.OpenCSVFile(ref dt, filename))
            {
                dad.st_l1.Text = "Error:";
                dad.st_l2.Text = "Load CSV File failed!";
            }
        }

        private void bt_load_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = ".\\";
            openFileDialog1.Filter = "(*.CSV)|*.CSV";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                open_new_table(openFileDialog1.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start();
        }

        private bool set_ch()
        {
            List_sending_ch.Clear();
            if (dataGridView1.Rows.Count <= 0)
            { return false; }
            for (int i = 1; i < dataGridView1.Rows[0].Cells.Count; i++)
            {
                try
                {
                    int cu_c = int.Parse(dataGridView1.Rows[0].Cells[i].Value.ToString());
                    List_sending_ch.Add(cu_c);
                }
                catch(Exception e)
                {
                    dad.st_l1.Text = "Error:";
                    dad.st_l2.Text = e.ToString();
                    LogContext.theInst.LogPrint(e.ToString(), 2);
                }
            }
            return true;
        }

        public void sending()
        {
            while (running)
            {
                if (current_row >= dataGridView1.Rows.Count)
                {
                    if (current_loo >= numericUpDown1.Value)
                    {
                        end();
                    }
                    else
                    {
                        current_loo++;
                        current_row = 1;
                    }
                }
                else
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[current_row].Selected = true;
                    if (current_row > 0)
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows[current_row - 1].Index;
                    }
                    string str = "SA ";
                    for (int i = 0; i < List_sending_ch.Count; i++)
                    {
                        str += List_sending_ch[i].ToString() + " " + dataGridView1.Rows[current_row].Cells[i + 1].Value.ToString() + " ";
                    }
                    if (str != "SA ")
                    {
                        try
                        {
                            if (dad.cs.sendvalue(str, 2000, "sa", !dad.reserved))
                            {

                                Thread.Sleep(int.Parse(dataGridView1.Rows[current_row].Cells[0].Value.ToString()));
                                current_row++;
                            }
                        }
                        catch(Exception e)
                        {
                            dad.st_l1.Text = "Error:";
                            dad.st_l2.Text = "Failed to send CSV data row[" + current_row.ToString() + "]:" + e.ToString();
                            LogContext.theInst.LogPrint(e.ToString(), 2);
                        }
                    }
                }
            }
        }


        private void start()
        {
            
            current_row = 1;
            if (set_ch())
            {
                running = true;
                run_t = new Thread(sending);
                run_t.IsBackground = true;
                run_t.Start();
            }
        }
        private void end()
        {
            running = false;
            //run_t.Abort();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            end();
        }
    }
}
