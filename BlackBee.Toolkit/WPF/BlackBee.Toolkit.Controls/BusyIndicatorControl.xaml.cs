using System.Windows;
using System.Windows.Controls;
using XCS.BV.VM.BlackBee.Helper;

// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace XCS.BV.VM.BlackBee.Controls
{
    public sealed partial class BusyIndicatorControl : UserControl
    {
        public BusyIndicatorControl()
        {
            this.InitializeComponent();

        }
        // Dependency Property
        public static readonly DependencyProperty MessageProperty =
             DependencyProperty.Register("Message", typeof(string),
             typeof(BusyIndicatorControl), new PropertyMetadata(string.Empty, new PropertyChangedCallback(UpdateMessage)));

        private static void UpdateMessage(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!Equals(e.OldValue,e.NewValue))
            {
                d.As<BusyIndicatorControl>().MessageText.Text = (string)e.NewValue;
            }
            //else
            //{
            //    (d as BusyIndicatorControl).Message = Visibility.Collapsed;
            //}
        }

        // .NET Property wrapper
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Dependency Property
        public static readonly DependencyProperty LoadStateProperty =
             DependencyProperty.Register("LoadState", typeof(bool),
             typeof(BusyIndicatorControl), new PropertyMetadata(false, new PropertyChangedCallback(UpdateState)));

        private static void UpdateState(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                
                if (Application.Current.MainWindow != null)
                {
                    //var currentPage =
                    //    (Application.Current.MainWindow.Content as UserControl;
                    //if (currentPage.ApplicationBar != null)
                    //{
                    //    currentPage.ApplicationBar.IsVisible = false;
                    //}
                    //currentPage.Focus();
                    ((BusyIndicatorControl) d).Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (Application.Current.MainWindow != null)
                {
                    //var currentPage =
                    //    ((PhoneApplicationFrame)Application.Current.RootVisual).Content as PhoneApplicationPage;
                    //if (currentPage.ApplicationBar != null)
                    //{
                    //    currentPage.ApplicationBar.IsVisible = true;
                    //}
                    ((BusyIndicatorControl) d).Visibility = Visibility.Collapsed;
                }
            }
        }

        // .NET Property wrapper
        public bool LoadState
        {
            get { return (bool)GetValue(LoadStateProperty); }
            set
            {
                //if(value) this.Focus();
                SetValue(LoadStateProperty, value);
            }

        }

        private void BusyIndicatorControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            //AnimationCircle.Begin();
        }
    }
}