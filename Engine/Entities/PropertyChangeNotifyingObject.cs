using System.ComponentModel;

namespace Engine.Entities
{
    public abstract class PropertyChangeNotifyingObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.SafeInvoke(this, propertyName);
        }
    }
}
