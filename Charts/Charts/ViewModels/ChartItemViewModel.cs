using Charts.Infrastructure;

namespace Charts.ViewModels
{
    public abstract class ChartItemViewModel : ViewModelBase
    {
        #region Name

        public abstract string Name { get; }

        #endregion

        public abstract void GenerateData();
    }
}
