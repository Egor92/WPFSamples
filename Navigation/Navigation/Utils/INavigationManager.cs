namespace Navigation.Utils
{
    public interface INavigationManager
    {
        void Navigate(string navigationKey, object arg = null);
    }
}