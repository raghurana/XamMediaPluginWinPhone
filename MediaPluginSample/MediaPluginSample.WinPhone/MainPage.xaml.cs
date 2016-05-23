using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MediaPluginSample.WinPhone
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Button.Click += OnCameraButtonClick;
        }

        private void OnCameraButtonClick(object sender, RoutedEventArgs routedEventArgs)
        {
            
        }
    }
}
