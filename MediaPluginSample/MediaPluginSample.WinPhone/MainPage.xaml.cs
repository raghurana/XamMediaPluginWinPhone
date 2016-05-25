using System;
using System.Threading.Tasks;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace MediaPluginSample.WinPhone
{
    public sealed partial class MainPage : Page
    {
        private bool isMediaActive;

        public MainPage()
        {
            InitializeComponent();
            Button.Click += OnCameraButtonClick;
            HardwareButtons.BackPressed += HardwareButtonsOnBackPressed;
        }

        private async void OnCameraButtonClick(object sender, RoutedEventArgs routedEventArgs)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await ShowMessage(":( No camera available.");
                    return;
                }

                isMediaActive = true;

                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                {
                    await ShowMessage(":( Failed to capture photo.");
                    return;
                }

                var img = new BitmapImage(new Uri(file.Path));
                CaptureImage.Source = img;
            }

            catch (Exception ex)
            {
                await ShowMessage(ex.Message);
            }

            finally
            {
                isMediaActive = false;
            }
        }

        private void HardwareButtonsOnBackPressed(object sender, BackPressedEventArgs backPressedEventArgs)
        {
            backPressedEventArgs.Handled = isMediaActive;
            isMediaActive = false;
        }

        private static async Task ShowMessage(string message)
        {
            var msgbox = new MessageDialog(message);
            await msgbox.ShowAsync();
        }
    }
}
