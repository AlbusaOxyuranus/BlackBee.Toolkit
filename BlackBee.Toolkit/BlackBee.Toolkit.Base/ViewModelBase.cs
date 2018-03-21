namespace BlackBee.Toolkit.Base
{
    public class ViewModelBase : ObjectBase
    {
        private bool _bussinessProcess;
        private string _bussinessProcessMessage;

        public ViewModelBase()
        {
            BussinessProcessMessage = "Выполнение операции";
        }

        /// <summary>
        /// Поле для шторки которая показывает процесс выполнения
        /// </summary>
        public bool BussinessProcess
        {
            get => _bussinessProcess;
            set
            {
                _bussinessProcess = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Поле для шторки которая показывает процесс выполнения
        /// </summary>
        public string BussinessProcessMessage
        {
            get => _bussinessProcessMessage;
            set
            {
                _bussinessProcessMessage = value;
                OnPropertyChanged();
            }
        }
    }
}