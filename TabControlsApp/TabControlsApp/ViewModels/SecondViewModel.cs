using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TabControlsApp.ViewModels
{
    public class SecondViewModel : ReactiveObject
    {
        [Reactive]
        public bool BoolProperty { get; set; } = true;
    }
}
