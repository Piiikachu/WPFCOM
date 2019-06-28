using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfApp1
{
    class StatusModel:INotifyPropertyChanged
    {
        public string CurrentTime => 
            string.Format("时间：   {0}  {1}", DateTime.Now.ToLongDateString(),DateTime.Now.ToLongTimeString());

        public event PropertyChangedEventHandler PropertyChanged;

        private DispatcherTimer _timer;

        public StatusModel()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += (sender, o) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTime)));
            _timer.Start();
        }
    }
}
