using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApp1
{
    public class Channel:INotifyPropertyChanged
    {
        private double[] channelBDPoints;

        public double[] ChannelBDPoints
        {
            get => channelBDPoints;
            set
            {
                this.channelBDPoints = value;
                NotifyPropertyChanged("ChannelBDPoints");
            }
        }

        public double InputCurrent
        {
            get => inputCurrent;
            set
            {
                this.inputCurrent = value;
                NotifyPropertyChanged("InputCurrent");
            }
        }

        private double inputCurrent;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public Channel()
        {
            ChannelBDPoints = new double[6];
            Array.Copy(CalibrateModel.DEFAULT_CALIBRATE, ChannelBDPoints, 6);
        }

        public double toPressure(double current)
        {
            return Transform.toPressure(ChannelBDPoints, current);
        }

        public void setChannel(double[] Points)
        {
            Array.Copy(Points, ChannelBDPoints, 6);
        }

        public void setCurrent(double result)
        {
            this.InputCurrent = result/100;
        }
    }
}
