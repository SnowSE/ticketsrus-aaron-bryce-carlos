using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace MauiTickets.Components.Pages
{
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();

            cameraBarcodeReaderView.Options = new BarcodeReaderOptions
            {
                Formats = BarcodeFormats.OneDimensional,
                AutoRotate = true,
                Multiple = true
            };
        }

        private TaskCompletionSource<BarcodeResult[]> scanTask = new TaskCompletionSource<BarcodeResult[]>();
        public Task<BarcodeResult[]> WaitForResultAsync()
        {
            return scanTask.Task;
        }

        protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
        {
            Application.Current.MainPage.Navigation.PopModalAsync();

            scanTask.TrySetResult(e.Results);
        }
    }

}
