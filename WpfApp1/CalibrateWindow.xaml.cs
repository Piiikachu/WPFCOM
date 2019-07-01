using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// CalibrateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CalibrateWindow : Window
    {
        MainWindow mainWindow;
        CalibrateModel model;
        int channelIndex;
        Channel channel;

        public int ChannelIndex { get => channelIndex; set => channelIndex = value; }

        public CalibrateWindow(int index)
        {
            InitializeComponent();
            this.ChannelIndex = index-1;
            this.Title = $"通道{index}标定窗口";
            model = new CalibrateModel();
            model.setChannel(index - 1);
            DataContext = model;

            mainWindow =(MainWindow) App.Current.MainWindow;
            channel = mainWindow.channels[index - 1];
            mainWindow.channelIndex = index - 1;
        }

        private string bdPointToString(BDPoint p)
        {
            return p.ToString().Substring(1);
        }

        private void Btn_bd_Click(object sender, RoutedEventArgs e)
        {
            string p = bdPointToString(model.BdPoint);
            double current = model.InputCurrent;
            string msg = $"确认标定{p}压力时的电流值为{current}mA?";
            string caption = "确认标定";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show(msg, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Yes:
                    SetValue(model.BdPoint, current);
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    break;

                default:
                    break;
            }
        }

        private void SetValue(BDPoint p,double current)
        {
            switch (p)
            {
                case BDPoint.P0Mpa:
                    model.P1 = current;
                    break;
                case BDPoint.P20Mpa:
                    model.P2 = current;
                    break;
                case BDPoint.P40Mpa:
                    model.P3 = current;
                    break;
                case BDPoint.P60Mpa:
                    model.P4 = current;
                    break;
                case BDPoint.P80Mpa:
                    model.P5 = current;
                    break;
                case BDPoint.P100Mpa:
                    model.P6 = current;
                    break;
                default:
                    break;
            }
           // mainWindow.channels[channel].setChannel(model.CurrentCalibratePoints);
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            model.resetPoints();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            channel.setChannel(model.getPoints());
            this.Close();
        }

        private void WindowBD_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.channelIndex = -1;
        }
    }

}
