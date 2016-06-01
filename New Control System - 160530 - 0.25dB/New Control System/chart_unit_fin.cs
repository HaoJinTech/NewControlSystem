using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace New_Control_System
{
    public partial class chart_unit_fin : UserControl
    {

        public int[,] ch_value_ser = new int[32, 120];
        public Series[] ser = new Series[32];

        public int se_count = -1;
        Form1 dad;
        public chart_unit_fin()
        {
            //dad = _dad;
            //for (int i = 0; i < dad.ld.list_data.Length; i++)
            //{
            //    ser[i] = new Series();
            //    ser[i].Points.AddXY(1, 4);
            //    ser[i].ChartType = SeriesChartType.FastLine;
            //    ser[i].BorderWidth = 3;
            //    ser[i].Name = "ser" + i.ToString();
            //}

            InitializeComponent();
        }

        private void chart_unit_fin_Load(object sender, EventArgs e)
        {
            for (int i=0; i < 16; i++)
            {
                addNewSeries("k" + (i+1).ToString());
            }
                timer1.Enabled = true;
        }

        public void addNewSeries(String series_name)
        {
            
            se_count++;
            ser[se_count].Name = series_name;
            chart_main.Series.Add(ser[se_count]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int m = 0; m < se_count+1; m++)
            {
                for (int i = 118; i >=0; i--)
                {
                    ch_value_ser[m, i + 1] = ch_value_ser[m, i];
                }
                ch_value_ser[m, 0] = dad.ld.list_data[m % 8, m / 8].channel_value;
            }


            for (int m = 0; m < se_count+1; m++)
            {
                ser[m].Points.Clear();
                for (int i = 0; i < 120; i++)
                {
                    ser[m].Points.AddXY(i, ch_value_ser[m, i]);
                }
            }
        }


    }
}
