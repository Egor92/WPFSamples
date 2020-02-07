using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TabControlsApp.ViewModels
{
    public class ThirdViewModel : ReactiveObject
    {
        [Reactive]

        public double DoubleProperty { get; set; } = 40.0;
    }
}
