using System.Windows;
using System.Windows.Controls;

namespace XCS.BV.VM.BlackBee.Controls
{
    public class BusyIndicatorPage:Page
    {
        public BusyIndicatorPage()
        {
            BusyIndicator = new BusyIndicatorControl();
        }

        public BusyIndicatorControl BusyIndicator { get; set; }

        protected void CreateIndicate(Grid rootGrid)
        {
            //HorizontalAlignment="Stretch" VerticalAlignment="Stretch"
            BusyIndicator.Visibility = Visibility.Collapsed;
            BusyIndicator.HorizontalAlignment = HorizontalAlignment.Stretch; //HorizontalAlignment.Stretch;
            BusyIndicator.VerticalAlignment = VerticalAlignment.Stretch;

            rootGrid.Children.Add(BusyIndicator);
            Grid.SetRowSpan(BusyIndicator, 2);
            //_BusyIndicator.DataContext = _rootGrid.DataContext;
            //_BusyIndicator.Visibility = Visibility.Collapsed;
        }
    }
}