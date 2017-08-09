namespace WpfApplication2.ViewModels
{
    public class MainViewModel : NotificationObject
    {
        #region Bool

        private bool _Bool;

        public bool Bool
        {
            get { return _Bool; }
            set { SetProperty(ref _Bool, value, () => Bool); }
        }

        #endregion

        #region A

        private int _a;

        public int A
        {
            get { return _a; }
            set { SetProperty(ref _a, value, () => A); }
        }

        #endregion

        #region R

        private int _r;

        public int R
        {
            get { return _r; }
            set { SetProperty(ref _r, value, () => R); }
        }

        #endregion

        #region G

        private int _g;

        public int G
        {
            get { return _g; }
            set { SetProperty(ref _g, value, () => G); }
        }

        #endregion

        #region B

        private int _b;

        public int B
        {
            get { return _b; }
            set { SetProperty(ref _b, value, () => B); }
        }

        #endregion

        #region String

        private string _String;

        public string String
        {
            get { return _String; }
            set { SetProperty(ref _String, value, () => String); }
        }

        #endregion

        #region Hex

        private string _Hex;

        public string Hex
        {
            get { return _Hex; }
            set { SetProperty(ref _Hex, value, () => Hex); }
        }

        #endregion
    }
}
