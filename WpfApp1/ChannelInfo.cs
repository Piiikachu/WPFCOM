using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    
    public class ChannelInfo : INotifyPropertyChanged
    {
        private string[] _channels;
        private double[] _pressures;
        private double _p1;
        private double _p2;
        private double _p3;
        private double _p4;
        private double _p5;
        private double _p6;
        private double _p7;
        private double _p8;
        public ChannelInfo(string[] channels)
        {
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            
            this.Pressures = main.transform.toPressures(channels);
            this.P1 = Pressures[0];
            this.P2 = Pressures[1];
            this.P3 = Pressures[2];
            this.P4 = Pressures[3];
            this.P5 = Pressures[4];
            this.P6 = Pressures[5];
            this.P7 = Pressures[6];
            this.P8 = Pressures[7];
            
        }

        public string[] Channels { get => _channels; set => _channels = value; }
        public double[] Pressures { get => _pressures; set => _pressures = value; }
        public double P1 { get => _p1; set => _p1 = value; }
        public double P2 { get => _p2; set => _p2 = value; }
        public double P3 { get => _p3; set => _p3 = value; }
        public double P4 { get => _p4; set => _p4 = value; }
        public double P5 { get => _p5; set => _p5 = value; }
        public double P6 { get => _p6; set => _p6 = value; }
        public double P7 { get => _p7; set => _p7 = value; }
        public double P8 { get => _p8; set => _p8 = value; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
