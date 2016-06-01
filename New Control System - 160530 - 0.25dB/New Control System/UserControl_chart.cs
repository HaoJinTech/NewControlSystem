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
    public partial class UserControl_chart : UserControl
    {
        List<int> itemin = new List<int>();
        public float[,] ch_value_ser = new float[64, 120];
        public Series[] ser = new Series[64];
        public float[] now_value = new float[128];

       public UserControl_chart()
        {
            InitializeComponent();
        }


        public int finder(int channel) 
        {
            int result = -1;
            for (int i = 0; i < itemin.Count; i++)
            {
                if (itemin[i] == channel)
                {
                    result = i;
                    return result;
                }
            }
            return result;
        }

        public void SET_SHOW(int Channel_no)
        {
            addNewSeries("ch" + (Channel_no + 1).ToString(),Channel_no);
        }

        public void clear()
        {
            itemin.Clear();
            chart1.Series.Clear();
            ch_value_ser = new float[64, 120];
            
        }

        public void addNewSeries(String series_name,int channel)
        {
            ser[itemin.Count] = new Series();
            ser[itemin.Count].Name = series_name;
            chart1.Series.Add(ser[itemin.Count]);
            ser[itemin.Count].ChartType = SeriesChartType.FastLine;
            itemin.Add(channel);
           
        }



        public void SET_VALUE(int Channel_no,float Value)
        {
            int soul = finder(Channel_no);
            if (soul >= 0)
            {
                now_value[finder(Channel_no)] = Value;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {



            for (int m = 0; m < itemin.Count; m++)
            {
                for (int i = 118; i >= 0; i--)
                {
                    ch_value_ser[m, i + 1] = ch_value_ser[m, i];
                }
                ch_value_ser[m, 0] = now_value[m];
            }


            for (int m = 0; m < itemin.Count; m++)
            {
                ser[m].Points.Clear();
                for (int i = 0; i < 120; i++)
                {
                     ser[m].Points.AddXY(i, ch_value_ser[m, i]); 
                }
            }
        }
        public void set_timer(int inet)
        {
            timer1.Interval = inet;
        }
        private void UserControl_chart_Load(object sender, EventArgs e)
        {
        }
    }
}
