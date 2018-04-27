
namespace BlackBee.Toolkit.Controls
{
   
#if !NETFX_CORE
    using System.Windows;
    using System.Windows.Controls;

    public class BusyIndicatorView : Window
    {
        private BusyIndicatorControl _busyIndicator;

        public BusyIndicatorView()
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
#else

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class BusyIndicatorView : Page
    {
        private BusyIndicatorControl _busyIndicator;

        protected BusyIndicatorView()
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
#endif
}
