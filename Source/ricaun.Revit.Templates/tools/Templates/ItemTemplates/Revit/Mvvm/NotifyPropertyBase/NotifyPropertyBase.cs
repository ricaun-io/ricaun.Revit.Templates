using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace $rootnamespace$
{
    public class $safeitemname$ : INotifyPropertyChanged
    {
        /// <summary>
        /// Event that gets fired when any property changes on child classes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Refresh a single property to UI
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}