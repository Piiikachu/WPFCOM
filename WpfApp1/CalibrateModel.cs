using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1
{
    class CalibrateModel : INotifyPropertyChanged
    {

        public static readonly double[] DEFAULT_CALIBRATE = new double[6]
        {
           4, 7.2, 10.4, 13.6, 16.8, 20
        };

        private double _p1;
        private double _p2;
        private double _p3;
        private double _p4;
        private double _p5;
        private double _p6;
        Channel channel;
        int channelIndex;
        public event PropertyChangedEventHandler PropertyChanged;


        public CalibrateModel()
        {
            ChannelIndex = 0;
            //todo: 实现实时读取电流值
            this.InputCurrent = 0.86;
        }

        public void setChannel(int index)
        {
            this.ChannelIndex = index;
            MainWindow main = (MainWindow)App.Current.MainWindow;
            this.channel = main.channels[ChannelIndex];
            channel.PropertyChanged += updateCurrent;
            updatePoint();
        }

        private void updateCurrent(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName=="InputCurrent")
            {
                this.InputCurrent = channel.InputCurrent;
            }
        }

        private void updatePoint()
        {
            P1 = channel.ChannelBDPoints[0];
            P2 = channel.ChannelBDPoints[1];
            P3 = channel.ChannelBDPoints[2];
            P4 = channel.ChannelBDPoints[3];
            P5 = channel.ChannelBDPoints[4];
            P6 = channel.ChannelBDPoints[5];
        }

        public double[] getPoints()
        {
            double[] points = new double[6];
            points[0] = P1;
            points[1] = P2;
            points[2] = P3;
            points[3] = P4;
            points[4] = P5;
            points[5] = P6;
            return points;
        }

        public void setPoints(double[] points)
        {
            P1 = points[0];
            P2 = points[1];
            P3 = points[2];
            P4 = points[3];
            P5 = points[4];
            P6 = points[5];
        }

        public void resetPoints()
        {
            setPoints(DEFAULT_CALIBRATE);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private BDPoint bdPoint;

        public BDPoint BdPoint
        {
            get => bdPoint;
            set
            {
                bdPoint = value;
                OnPropertyChanged("BdPoint");
            }
        }

        public double InputCurrent
        {
            get => inputCurrent;
            set
            {
                inputCurrent = value;
                OnPropertyChanged("InputCurrent");
            }
        }


        public double P1
        {
            get => _p1;
            set
            {
                _p1 = value;
                OnPropertyChanged("P1");
            }
        }

        public double P2
        {
            get => _p2;
            set
            {
                _p2 = value;
                OnPropertyChanged("P2");
            }
        }

        public double P3
        {
            get => _p3;
            set
            {
                _p3 = value;
                OnPropertyChanged("P3");
            }
        }

        public double P4
        {
            get => _p4;
            set
            {
                _p4 = value;
                OnPropertyChanged("P4");
            }
        }

        public double P5
        {
            get => _p5;
            set
            {
                _p5 = value;
                OnPropertyChanged("P5");
            }
        }

        public double P6
        {
            get => _p6;
            set
            {
                _p6 = value;
                OnPropertyChanged("P6");
            }
        }

        public int ChannelIndex { get => channelIndex; set => channelIndex = value; }

        private double inputCurrent;
    }
    public enum BDPoint
    {
        P0Mpa,
        P20Mpa,
        P40Mpa,
        P60Mpa,
        P80Mpa,
        P100Mpa
    }

    public class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? false : value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
    
}
