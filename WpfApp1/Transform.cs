using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Transform
    {


        public static double toPressure(double current)
        {
            if (current > 20)
            {
                throw new Exception("Input current out of range");
            }
            if (current < 4)
            {
                return 0;
            }
            else
            {
                return 100 * (current - 4) / 16;
            }
        }
        public static double[] toPressures(string[] hexnums)
        {
            if (hexnums.Length != 8)
            {
                throw new Exception("number of channels is not 8");
            }
            double[] ps = new double[8];
            for (int i = 0; i < 8; i++)
            {
                ps[i] = toPressure(Convert.ToDouble(toDec(hexnums[i])) / 100);
            }
            return ps;
        }

        public static int toDec(string hexNumber)
        {
            return Convert.ToInt32(hexNumber, 16);
        }

        public static string[] toChannels(string s)
        {
            string[] channels = new string[8];
            if (s.Length != 50)
            {
                throw new Exception("COM message lenth error");
            }
            for (int i = 0; i < 8; i++)
            {
                channels[i] = s.Substring(4 * i + 6, 4);
            }
            return channels;
        }
    }
}
