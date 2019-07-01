using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
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
            this.channel1.SelectedIndex = 0;
            this.channel2.SelectedIndex = 1;
            this.channel3.SelectedIndex = 2;
            this.unit1.SelectedIndex = 0;
            this.unit2.SelectedIndex = 0;
            this.unit3.SelectedIndex = 0;

            listview.ItemsSource = channelInfoList;

            for (int i = 0; i < 8; i++)
            {
                channels.Add(new Channel());
            }
            transform = new Transform(channels.ToArray());
        }

        static int BUFFER_SIZE = 25;
        byte[] buffer = new Byte[BUFFER_SIZE];

        public static SerialPort myPort = new SerialPort();
        double result;
        bool portClosing;
        string pressure;
        string[] inputChannels;
        public int channelIndex = -1;
        public ObservableCollection<Channel> channels = new ObservableCollection<Channel>();
        public Transform transform;
        ObservableCollection<ChannelInfo> channelInfoList = new ObservableCollection<ChannelInfo>();

        private void MyPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            if (portClosing)
            {
                return;
            }

            try
            {
                myPort.Read(buffer, 0, BUFFER_SIZE);
                string msg;
                msg = byteToHexStr(buffer);
                inputChannels = Transform.toChannels(msg);

                result = Transform.toDec(inputChannels[0]);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            if (channelIndex != -1)
            {
                channels[channelIndex].setCurrent(result);
                return;
            }


            listview.Dispatcher.BeginInvoke(new Action(() =>
            {
                channelInfoList.Add(new ChannelInfo(inputChannels));
            }));

            textOut.Dispatcher.BeginInvoke(new Action(() =>
            {
                textOut.Text = result.ToString();
            }));
        }

        public static string byteToHexStr(byte[] bytes)
        {
            string str = "";
            if (bytes != null)
            {
                foreach (byte b in bytes)
                {
                    str += b.ToString("X2");
                }
            }
            return str;
        }

        private void Btn_open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myPort.BaudRate = 9600;
                myPort.DataBits = 8;
                myPort.PortName = "COM2";
                myPort.Parity = Parity.None;
                myPort.StopBits = StopBits.One;
                myPort.Open();
                portClosing = false;
                MessageBox.Show("串口打开成功");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            myPort.DataReceived += MyPort_DataReceived;
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ChannelInfo> channelInfoList = new ObservableCollection<ChannelInfo>();
        }



        private void MenuClb_Click(object sender, RoutedEventArgs e)
        {
            //todo: 连接串口后取消该注释
            if (!myPort.IsOpen)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage image = MessageBoxImage.Error;
                MessageBox.Show("串口未打开!", "错误！", button, image);
                return;
            }
        }
        private void MenuClb1_Click(object sender, RoutedEventArgs e)
        {
            int channel = 1;
            CalibrateWindow c = new CalibrateWindow(channel);
            c.ShowDialog();
        }

        private void MenuClb2_Click(object sender, RoutedEventArgs e)
        {
            int channel = 2;
            CalibrateWindow c = new CalibrateWindow(channel);
            c.ShowDialog();
        }

        private void MenuClb3_Click(object sender, RoutedEventArgs e)
        {
            int channel = 3;
            CalibrateWindow c = new CalibrateWindow(channel);
            c.ShowDialog();
        }

        private void MenuClb4_Click(object sender, RoutedEventArgs e)
        {
            int channel = 4;
            CalibrateWindow c = new CalibrateWindow(channel);
            c.ShowDialog();
        }
        private void MenuClb5_Click(object sender, RoutedEventArgs e)
        {
            int channel = 5;
            CalibrateWindow c = new CalibrateWindow(channel);
            c.ShowDialog();
        }
        private void MenuClb6_Click(object sender, RoutedEventArgs e)
        {
            int channel = 6;
            CalibrateWindow c = new CalibrateWindow(channel);
            c.ShowDialog();
        }
        private void MenuClb7_Click(object sender, RoutedEventArgs e)
        {
            int channel = 7;
            CalibrateWindow c = new CalibrateWindow(channel);
            c.ShowDialog();
        }
        private void MenuClb8_Click(object sender, RoutedEventArgs e)
        {
            int channel = 8;
            CalibrateWindow c = new CalibrateWindow(channel);
            c.ShowDialog();
        }
    }
}
