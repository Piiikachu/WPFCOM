using InteractiveDataDisplay.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    class PlotModel
    {
        ObservableCollection<ChannelInfo> infos;
        Grid lines;
        public PlotModel()
        {
            //double[] x = new double[200];
            //for (int i = 0; i < x.Length; i++)
            //    x[i] = 3.1415 * i / (x.Length - 1);

            //for (int i = 0; i < 25; i++)
            //{
            //    var lg = new LineGraph();
            //    Lines.Children.Add(lg);
            //    lg.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, (byte)(i * 10), 0));
            //    lg.Description = String.Format("Data series {0}", i + 1);
            //    lg.StrokeThickness = 2;
            //    lg.Plot(x, x.Select(v => Math.Sin(v + i / 10.0)).ToArray());
            //}
        }

        public ObservableCollection<ChannelInfo> Infos { get => infos; set => infos = value; }
        public Grid Lines { get => lines; set => lines = value; }

        public void init(ObservableCollection<ChannelInfo> infos, Grid lines)
        {
            this.infos = infos;
            this.lines = lines;

            //int xCount = infos.Count;
            int i = 0;
            List<int> x = new List<int>();
            List<double> p1List = new List<double>();
            List<double> p2List = new List<double>();
            List<double> p3List = new List<double>();
            List<double> p4List = new List<double>();
            List<double> p5List = new List<double>();
            List<double> p6List = new List<double>();
            List<double> p7List = new List<double>();
            List<double> p8List = new List<double>();
            foreach (ChannelInfo info in infos)
            {
                x.Add(i);
                p1List.Add(info.P1);
                p2List.Add(info.P2);
                p3List.Add(info.P3);
                p4List.Add(info.P4);
                p5List.Add(info.P5);
                p6List.Add(info.P6);
                p7List.Add(info.P7);
                p8List.Add(info.P8);
                i++;
            }
            List<double>[] list = new List<double>[8] 
            {
                p1List, p2List, p3List, p4List, p5List, p6List, p7List, p8List
            };

            for (int j = 0; j < 8; j++)
            {
                LineGraph lg = new LineGraph();
                Lines.Children.Add(lg);
                lg.Stroke = new SolidColorBrush(myColors[j]);
                lg.Description = String.Format("通道 {0}", j + 1);
                lg.StrokeThickness = 2;
                lg.Plot(x, list[j]);
            }

        }

        Color[] myColors = new Color[] 
        {
            Colors.Red,Colors.Orange,
            Colors.Yellow, Colors.Green,
            Colors.Blue, Colors.Purple,
            Colors.Brown,Colors.Black
        };

    }
}
