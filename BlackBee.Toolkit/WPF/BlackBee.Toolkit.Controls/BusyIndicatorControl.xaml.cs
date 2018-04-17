
// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

using System;
using System.Diagnostics;
using BlackBee.Toolkit.Base.Helper;

namespace BlackBee.Toolkit.Controls
{
#if !NETFX_CORE
    using System.Windows;
    using System.Windows.Controls;
#else
       using Windows.UI.Xaml;
       using Windows.UI.Xaml.Controls; 
#endif


    public sealed partial class BusyIndicatorControl : UserControl
    {
        public BusyIndicatorControl()
        {
            this.InitializeComponent();
        }
        // .NET Property wrapper
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        //// .NET Property wrapper
        //public bool IsNotPercentOperation
        //{
        //    get { return (bool)GetValue(IsNotPercentOperationProperty); }
        //    set { SetValue(IsNotPercentOperationProperty, value); }
        //}

        // .NET Property wrapper
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
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

#if !NETFX_CORE


        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(double),
            typeof(BusyIndicatorControl),
            new PropertyMetadata(
                ValuePropertyCallback));

        private static void ValuePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //BusyIndicatorControl myUserControlInstance = (BusyIndicatorControl)controlInstance;
            (d as BusyIndicatorControl).Value = (double)e.NewValue;
        }

       

        //// Dependency Property
        //public static readonly DependencyProperty PercentOperationProperty =
        //    DependencyProperty.Register("PercentOperation", typeof(int),
        //        typeof(BusyIndicatorControl),
        //        new PropertyMetadata(0,UpdatePercentOperation));

        //private static void UpdatePercentOperation(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    //if (!Equals(e.OldValue, e.NewValue))
        //    //{
        //    //    (d as BusyIndicatorControl).PercentOperation = (int)e.NewValue;
        //    //    Debug.WriteLine((int)e.NewValue);
        //    //}
        //    //if (int.Parse(e.OldValue.ToString()) != int.Parse(e.NewValue.ToString()))
        //    //{
        //        (d as BusyIndicatorControl).PercentOperation = (int)e.NewValue;
        //    //}
        //}

        //// Dependency Property
        //public static readonly DependencyProperty IsNotPercentOperationProperty =
        //    DependencyProperty.Register("IsNotPercentOperation", typeof(bool),
        //        typeof(BusyIndicatorControl),
        //        new PropertyMetadata(true, new PropertyChangedCallback(UpdateIsNotPercentOperationProperty)));

        //private static void UpdateIsNotPercentOperationProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if ((bool)e.NewValue)
        //    {
        //        (d as BusyIndicatorControl).IsNotPercentOperation = (bool)e.NewValue;
        //    }
        //}

        // Dependency Property
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string),
                typeof(BusyIndicatorControl),
                new PropertyMetadata(string.Empty, new PropertyChangedCallback(UpdateMessage)));

        private static void UpdateMessage(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!Equals(e.OldValue, e.NewValue))
            {
                (d as BusyIndicatorControl).MessageText.Text = (string) e.NewValue;
            }

            //else
            //{
            //    (d as BusyIndicatorControl).Message = Visibility.Collapsed;
            //}
        }

       

        // Dependency Property
        public static readonly DependencyProperty LoadStateProperty =
            DependencyProperty.Register("LoadState", typeof(bool),
                typeof(BusyIndicatorControl), new PropertyMetadata(false, new PropertyChangedCallback(UpdateState)));

        private static void UpdateState(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool) e.NewValue)
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



        private void BusyIndicatorControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            //AnimationCircle.Begin();
        }

#else

        // Dependency Property
            public static readonly DependencyProperty MessageProperty =
                 DependencyProperty.Register("Message", typeof(string),
                 typeof(BusyIndicatorControl), new PropertyMetadata(string.Empty, new PropertyChangedCallback(UpdateMessage)));

            private static void UpdateMessage(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                //if ((string)e.NewValue)
                //{
                var busyIndicatorControl = d as BusyIndicatorControl;
                if (busyIndicatorControl != null) busyIndicatorControl.MessageText.Text = (string)e.NewValue;
                //}
                //else
                //{
                //    (d as BusyIndicatorControl).Message = Visibility.Collapsed;
                //}
            }

            // Dependency Property
            public static readonly DependencyProperty LoadStateProperty =
                 DependencyProperty.Register("LoadState", typeof(bool),
                 typeof(BusyIndicatorControl), new PropertyMetadata(false, new PropertyChangedCallback(UpdateState)));

            private static void UpdateState(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if ((bool)e.NewValue)
                {

                    //var currentPage = ((PhoneApplicationFrame)Application.Current.RootVisual).Content as PhoneApplicationPage;
                    //if (currentPage.ApplicationBar != null)
                    //{
                    //    currentPage.ApplicationBar.IsVisible = false;
                    //}
                    var currentPage = Windows.UI.Xaml.Window.Current.Content as Page;
                    if (currentPage?.BottomAppBar != null)
                    {
                        currentPage.BottomAppBar.Visibility = Visibility.Collapsed;
                        currentPage.Focus(FocusState.Programmatic);
                    }

                    var busyIndicatorControl = d as BusyIndicatorControl;
                    if (busyIndicatorControl != null) busyIndicatorControl.Visibility = Visibility.Visible;
                }
                else
                {

                    //var currentPage = ((PhoneApplicationFrame)Application.Current.RootVisual).Content as PhoneApplicationPage;
                    //if (currentPage.ApplicationBar != null)
                    //{
                    //    currentPage.ApplicationBar.IsVisible = true;
                    //}
                    var currentPage = Windows.UI.Xaml.Window.Current.Content as Page;
                    if (currentPage?.BottomAppBar != null)
                    {
                        currentPage.BottomAppBar.Visibility = Visibility.Visible;
                    }
                    var busyIndicatorControl = d as BusyIndicatorControl;
                    if (busyIndicatorControl != null) busyIndicatorControl.Visibility = Visibility.Collapsed;
                }
            }


            private void BusyIndicatorControl_OnLoaded(object sender, RoutedEventArgs e)
            {
                //AnimationCircle.Begin();
            }
        

#endif
    }
}