using HomeAccountancy.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows;
using System.Windows.Data;

namespace HomeAccountancy.ViewModels
{
    class ChartViewModel
    {
        private int _SelectedCategoryType;
        private int _SelectedDiagramType; 

        public int SelectedDiagramType
        {
            get { return _SelectedDiagramType; }
            set
            {
                if (value == 0)
                    GeneratePieChart();
                else
                    GenerateColumnChart();

                _SelectedDiagramType = value;
            }
        }
        public int SelectedCategoryType
        {
            get { return _SelectedCategoryType; }
            set
            {
                _SelectedCategoryType = value;

                if (_SelectedDiagramType == 0)
                    GeneratePieChart();
                else
                    GenerateColumnChart();
            }
        }

        public Func<ChartPoint, string> PointLabel { get; set; }
        public SeriesCollection PieSeriesCollection { get; set; }
        public SeriesCollection ColumnSeriesCollection { get; set; }

        public ChartViewModel()
        {
            PieSeriesCollection = new SeriesCollection();
            ColumnSeriesCollection = new SeriesCollection();

            GeneratePieChart();
        }

        private void GeneratePieChart()
        {
            PieSeriesCollection.Clear();
            PointLabel = chartPoint => string.Format("{0:# ###.##} грн. ({1:P})", chartPoint.Y, chartPoint.Participation);

            foreach (Category category in Category.Entities)
            {
                double sum = 0;

                foreach (Transaction transaction in Transaction.Entities)
                {
                    if (transaction.CategoryId == category.Id &&
                        ((transaction is OutgoTransaction && _SelectedCategoryType == 0) || 
                        (transaction is IncomeTransaction && _SelectedCategoryType == 1)))
                        sum += transaction.Sum;
                }

                if (sum != 0)
                {
                    PieSeries series = new PieSeries
                    {
                        Title = category.Name,
                        Values = new ChartValues<double> { sum },
                        LabelPoint = PointLabel,
                        DataLabels = true
                    };

                    Binding binding = new Binding()
                    {
                        Path = new PropertyPath("PointLabel")
                    };

                    series.SetBinding(Series.LabelPointProperty, binding);
                    PieSeriesCollection.Add(series);
                }
            }
        }
        private void GenerateColumnChart()
        {
            ColumnSeriesCollection.Clear();
            PointLabel = chartPoint => string.Format("{0:# ###.##} грн.", chartPoint.Y, chartPoint.Participation);

            foreach (Category category in Category.Entities)
            {
                double sum = 0;

                foreach (Transaction transaction in Transaction.Entities)
                {
                    if (transaction.CategoryId == category.Id &&
                        ((transaction is OutgoTransaction && _SelectedCategoryType == 0) ||
                        (transaction is IncomeTransaction && _SelectedCategoryType == 1)))
                        sum += transaction.Sum;
                }

                if (sum != 0)
                {
                    ColumnSeries series = new ColumnSeries
                    {
                        Title = category.Name,
                        Values = new ChartValues<double> { sum },
                        LabelPoint = PointLabel,
                        DataLabels = true
                    };

                    Binding binding = new Binding()
                    {
                        Path = new PropertyPath("PointLabel")
                    };

                    series.SetBinding(Series.LabelPointProperty, binding);
                    ColumnSeriesCollection.Add(series);
                }
            }
        }
    }
}
