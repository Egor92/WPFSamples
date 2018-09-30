using System.Linq;
using System.Windows.Input;
using Charts.Infrastructure;

namespace Charts.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Ctor

        public MainViewModel()
        {
            GenerateData(null);
            SelectedChartItemVM = ChartItemVMs.FirstOrDefault();
        }

        #endregion

        #region ChartItemVMs

        private ChartItemViewModel[] _chartItemVMs;

        public ChartItemViewModel[] ChartItemVMs
        {
            get { return _chartItemVMs ?? (_chartItemVMs = CreateChartItemVMs()); }
        }

        private ChartItemViewModel[] CreateChartItemVMs()
        {
            return new ChartItemViewModel[]
            {
                new OxyPlotViewModel(),
            };
        }

        #endregion

        #region SelectedChartItemVM

        private ChartItemViewModel _selectedChartItemVM;

        public ChartItemViewModel SelectedChartItemVM
        {
            get { return _selectedChartItemVM; }
            set { SetProperty(ref _selectedChartItemVM, value); }
        }

        #endregion

        #region GenerateDataCommand

        private ICommand _generateDataCommand;

        public ICommand GenerateDataCommand
        {
            get { return _generateDataCommand ?? (_generateDataCommand = new DelegateCommand(GenerateData)); }
        }

        private void GenerateData(object _)
        {
            foreach (var chartItemVM in ChartItemVMs)
            {
                chartItemVM.GenerateData();
            }
        }

        #endregion
    }
}
