using System;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;

namespace Charts.ViewModels
{
    //http://docs.oxyplot.org/en/latest/getting-started/hello-wpf.html#create-project
    public class OxyPlotViewModel : ChartItemViewModel
    {
        #region Fields

        private Random _random = new Random();

        #endregion

        #region Properties

        #region SinModel

        private PlotModel _sinModel;

        public PlotModel SinModel
        {
            get { return _sinModel; }
            set { SetProperty(ref _sinModel, value); }
        }

        #endregion

        #region LineModel

        private PlotModel _lineModel;

        public PlotModel LineModel
        {
            get { return _lineModel; }
            set { SetProperty(ref _lineModel, value); }
        }

        #endregion

        #region BarModel

        private PlotModel _barModel;

        public PlotModel BarModel
        {
            get { return _barModel; }
            set { SetProperty(ref _barModel, value); }
        }

        #endregion

        #endregion

        #region Overrides of ChartItemViewModel

        public override string Name
        {
            get { return "OxyPlot"; }
        }

        public override void GenerateData()
        {
            var sinModel = new PlotModel();
            sinModel.Series.Add(new FunctionSeries(Math.Sin, 0, 10, 10000, "sin(x)"));
            SinModel = sinModel;

            var lineModel = new PlotModel();
            var functionSeries = new FunctionSeries(F, 0, 10, 40, "F(x)")
            {
                Color = OxyColor.FromRgb(0, 0, 255)
            };
            lineModel.Series.Add(functionSeries);
            LineModel = lineModel;

            var barModel = new PlotModel();
            var barSeries = new BarSeries
            {
                ItemsSource = Enumerable.Range(0, 8)
                                        .Select(CreateBarItem)
            };
            barModel.Series.Add(barSeries);
            BarModel = barModel;
        }

        private double F(double d)
        {
            return _random.NextDouble();
        }

        private BarItem CreateBarItem(int i)
        {
            var value = _random.NextDouble();
            var r = (byte) _random.Next(0, 255);
            var g = (byte) _random.Next(0, 255);
            var b = (byte) _random.Next(0, 255);
            return new BarItem(value, i)
            {
                Color = OxyColor.FromRgb(r, g, b)
            };
        }

        #endregion
    }
}
