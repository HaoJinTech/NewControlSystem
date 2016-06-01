using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace New_Control_System
{
    class Free_Field
    {
        //=============距离单位KM,频率单位MHz，初始信号强度dBm======
        public int Field_attenuation(int distance, int freq, int init)
        {
            double result = 0;
            //result = 22.4 + 30 * Math.Log10((double)distance / 1000.0) + 10 * Math.Log10((double)freq) - init;
            //result = 0 - ((double)distance * (double)distance) / 2500 + 0.42 * (double)distance - init;
            result = (-11.0 / 25000.0) * ((double)distance - 500.0) * ((double)distance - 500.0) + 110 - init;

            int count = (int)result;
            if (count >= 110)
            {
                return 110;
            }
            else if (count <= 0)
            {
                return 0;
            }
            else
            {
                return count;
            }
        }
    }
}
