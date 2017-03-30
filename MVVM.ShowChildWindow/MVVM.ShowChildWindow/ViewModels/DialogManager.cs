namespace MVVM.ShowChildWindow.ViewModels
{
    public interface IDialogManager
    {
        void Show(string key, object viewModel);
    }
    public static class DialogManagerExtensions
    {
        public static void Show<TViewModel>(this IDialogManager dialogManager, TViewModel viewModel)
        {
            var key = typeof(TViewModel).FullName;
            dialogManager.Show(key, viewModel);
        }
    }
}
