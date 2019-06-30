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
        CalibrateModel model;
        public CalibrateWindow(string channel)
        {
            InitializeComponent();
            this.Title = $"{channel}标定窗口";
            model = new CalibrateModel();
            DataContext = model;
        }

        private string bdPointToString(BDPoint p)
        {
            return p.ToString().Substring(1);
        }

        private void Btn_bd_Click(object sender, RoutedEventArgs e)
        {
            string p = bdPointToString(model.BdPoint);
            string msg = $"确认标定{p}压力时的电流值为mA?";
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
                case MessageBoxResult.Cancel:
                    break;
                case MessageBoxResult.Yes:
                    break;
                case MessageBoxResult.No:
                    break;
                default:
                    break;
            }
        }
    }

}
