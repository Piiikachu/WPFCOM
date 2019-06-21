using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Transform
    {
        public static double toPressure(double current)
        {
            if ( current > 20)
            {
                throw new Exception("Input current out of range");
            }
            if (current<4)
            {
                return 0;
            }
            else
            {
                return 10 + 10 / 1.6 * (current - 5.6);
            }
        }

        public static double toDec(string hexNumber)
        {
            return Convert.ToInt32(hexNumber, 16) / 100;
        }
    }
}
