using ReactiveUI;

namespace TabControlsApp.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        public FirstViewModel FirstVM { get; set; } = new FirstViewModel();

        public SecondViewModel SecondVM { get; set; } = new SecondViewModel();

        public ThirdViewModel ThirdVM { get; set; } = new ThirdViewModel();
    }
}
