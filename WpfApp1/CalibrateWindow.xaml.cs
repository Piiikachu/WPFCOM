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
        int channel;
        public CalibrateWindow(int channel)
        {
            InitializeComponent();
            this.channel = channel-1;
            this.Title = $"通道{channel}标定窗口";
            model = new CalibrateModel();
            DataContext = model;

            mainWindow =(MainWindow) App.Current.MainWindow;
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
                    //this.bdText0.Text = $"{current}mA";
                    model.CurrentCalibratePoints[0] = current;
                    break;
                case BDPoint.P20Mpa:
                    //this.bdText2.Text = $"{current}mA";
                    model.CurrentCalibratePoints[1] = current;
                    break;
                case BDPoint.P40Mpa:
                    //this.bdText4.Text = $"{current}mA";
                    model.CurrentCalibratePoints[2] = current;
                    break;
                case BDPoint.P60Mpa:
                    //this.bdText6.Text = $"{current}mA";
                    model.CurrentCalibratePoints[3] = current;
                    break;
                case BDPoint.P80Mpa:
                    //this.bdText8.Text = $"{current}mA";
                    model.CurrentCalibratePoints[4] = current;
                    break;
                case BDPoint.P100Mpa:
                    //this.bdText10.Text = $"{current}mA";
                    model.CurrentCalibratePoints[5] = current;
                    break;
                default:
                    break;
            }
            mainWindow.channels[channel].setChannel(model.CurrentCalibratePoints);
        }
    }

}
