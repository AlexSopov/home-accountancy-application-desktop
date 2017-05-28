using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace HomeAccountancy
{
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            PointLabel = chartPoint =>
                  string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            PointLabel = chartPoint =>
                  string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = Parent;
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
