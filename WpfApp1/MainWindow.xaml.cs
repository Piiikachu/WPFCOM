using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.chanel1.SelectedIndex = 0;
            this.chanel2.SelectedIndex = 1;
            this.chanel3.SelectedIndex = 2;
            this.unit1.SelectedIndex = 0;
            this.unit2.SelectedIndex = 0;
            this.unit3.SelectedIndex = 0;
        }
        
    }
}
