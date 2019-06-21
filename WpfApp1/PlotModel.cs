using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
namespace WpfApp1
{
    public class PlotModel
    {
        private string title;
        private IList<DataPoint> points;

        public string Title { get => title; set => title = value; }
        public IList<DataPoint> Points { get => points; set => points = value; }

        public PlotModel()
        {
            this.Title = "Test plot";
            this.Points = new List<DataPoint> { new DataPoint(0, 4),
                                  new DataPoint(10, 13),
                                  new DataPoint(20, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(40, 12),
                                  new DataPoint(50, 12)};
        }
    }
}
