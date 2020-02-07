using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TabControlsApp.ViewModels
{
    public class FirstViewModel : ReactiveObject
    {
        [Reactive]

        public string StringProperty { get; set; } = "Привет";
    }
}
