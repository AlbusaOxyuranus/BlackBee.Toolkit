using System.ComponentModel;
using System.Runtime.CompilerServices;
using BlackBee.Toolkit.Base.Annotations;

namespace BlackBee.Toolkit.Base
{
    public class ObjectBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}