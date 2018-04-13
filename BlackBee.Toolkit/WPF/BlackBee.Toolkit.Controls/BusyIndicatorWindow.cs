using System.Windows;
using System.Windows.Controls;

namespace XCS.BV.VM.BlackBee.Controls
{
    public class BusyIndicatorWindow : Window
    {
        private BusyIndicatorControl _busyIndicator;

        public BusyIndicatorWindow()
        {
            _busyIndicator = new BusyIndicatorControl();

        }

        public BusyIndicatorControl BusyIndicator
        {
            get { return _busyIndicator; }
            set
            {
                _busyIndicator = value;
            }
        }

        protected void CreateIndicate(Grid rootGrid)
        {
            //HorizontalAlignment="Stretch" VerticalAlignment="Stretch"
            _busyIndicator.Visibility = Visibility.Collapsed;
            _busyIndicator.HorizontalAlignment = HorizontalAlignment.Stretch; //HorizontalAlignment.Stretch;
            _busyIndicator.VerticalAlignment = VerticalAlignment.Stretch;

            rootGrid.Children.Add(_busyIndicator);
            Grid.SetRowSpan(_busyIndicator, 2);
            //_BusyIndicator.DataContext = _rootGrid.DataContext;
            //_BusyIndicator.Visibility = Visibility.Collapsed;
        }
    }
}