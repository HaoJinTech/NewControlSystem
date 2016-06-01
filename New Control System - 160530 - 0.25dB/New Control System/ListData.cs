using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace New_Control_System
{
    public class ListData
    {
        public int channel_value = 0;
        public string channel_reverse = "";
        public ListData[,] list_data;
        public void init_list_data(int io_in, int io_out)
        {
            list_data = new ListData[io_in, io_out];
            for (int i = 0; i < io_in; i++)
            {
                for (int o = 0; o < io_out; o++)
                {
                    list_data[i, o] = new ListData();
                    list_data[i, o].channel_value = 110;
                    list_data[i, o].channel_reverse = "Null";
                }
            }
        }
    }

}
