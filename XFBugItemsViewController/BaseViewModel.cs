using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XFBugItemsViewController
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaiseAndSetIfChanged<T>(ref T backingField, T value, [CallerMemberName]string propertyName=null)
        {
            if (!backingField.Equals(value))
            {
                backingField = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
}
