using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Maui;

namespace MauiTickets;

partial class CameraPage : ContentPage
{
    public CameraPage()
    {
        InitializeComponent();

        barcodeReader.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormat.QrCode,
            Multiple = true,
            TryHarder = true,
            AutoRotate = true,

        };
    }

    private TaskCompletionSource<BarcodeResult> scanTask = new TaskCompletionSource<BarcodeResult>();
    public async Task<BarcodeResult> WaitForResultAsync()
    {
        var value = await scanTask.Task;

        scanTask = new TaskCompletionSource<BarcodeResult>();

        return value;
    }

    protected void barcodeReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        scanTask.TrySetResult(e.Results.FirstOrDefault());
    }
}
