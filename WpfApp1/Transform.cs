using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Transform
    {
        private Channel[] channels;

        public Transform(Channel[] channels)
        {
            this.channels = channels;
        }

        public static double toPressure(double[] bdpoints, double current)
        {
            if (bdpoints.Length != 6)
            {
                throw new Exception("caliberate points array lenth error");
            }
            if (current > bdpoints[5])
            {
                throw new Exception("Input current out of range");
            }
            if (current <= bdpoints[0])
            {
                return 0;
            }
            for (int i = 0; i < 5; i++)
            {
                if (current > bdpoints[i] && current <= bdpoints[i + 1])
                {
                    return 20 / (bdpoints[i + 1] - bdpoints[i]) * (current - bdpoints[i]) + 20 * i;
                }
            }

            throw new Exception("Input current not in range");

        }
        public double[] toPressures(string[] hexnums)
        {
            if (hexnums.Length != 8)
            {
                throw new Exception("number of channels is not 8");
            }
            double[] ps = new double[8];
            for (int i = 0; i < 8; i++)
            {
                ps[i] = toPressure(channels[i].ChannelBDPoints, Convert.ToDouble(toDec(hexnums[i])) / 100);
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
