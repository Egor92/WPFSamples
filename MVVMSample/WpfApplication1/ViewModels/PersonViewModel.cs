using WpfApplication1.Enums;

namespace WpfApplication1.ViewModels
{
    public class PersonViewModel : NotificationObject
    {
        public string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value, () => Name); }
        }

        public string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value, () => LastName); }
        }

        public Gender _gender;
        public Gender Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value, () => Gender); }
        }
    }
}
