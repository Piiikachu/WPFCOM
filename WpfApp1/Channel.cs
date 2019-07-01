using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Channel
    {
        public double[] bdpoints;

        public Channel()
        {
            bdpoints = new double[6];
            Array.Copy(CalibrateModel.DEFAULT_CALIBRATE, bdpoints, 6);
        }

        public double toPressure(double current)
        {
            return Transform.toPressure(bdpoints, current);
        }

        public void setChannel(double[] Points)
        {
            Array.Copy(Points, bdpoints, 6);
        }
    }
}
