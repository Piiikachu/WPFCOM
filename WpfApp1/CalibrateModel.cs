﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1
{
    class CalibrateModel:INotifyPropertyChanged
    {

        private static readonly double[] DEFAULT_CALIBRATE = new double[6]
        {
           4, 7.2, 10.4, 13.6, 16.8, 20
        };

        private double[] currentCalibratePoints = new double[6]
        {
            4, 7.2, 10.4, 13.6, 16.8, 20
        };

        public event PropertyChangedEventHandler PropertyChanged;

        public void ResetCalibrate()
        {
            Array.Copy(DEFAULT_CALIBRATE, CurrentCalibratePoints, 6);
        }

        public CalibrateModel()
        {
            //todo: 实现实时读取电流值
            this.InputCurrent = 0.86;
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

        public double[] CurrentCalibratePoints { get => currentCalibratePoints; set => currentCalibratePoints = value; }

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