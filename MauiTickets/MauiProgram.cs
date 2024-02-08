using MauiTickets.Services;
using Microsoft.Extensions.Logging;
using TicketLibrary.Services;
using ZXing.Net.Maui.Controls;

namespace MauiTickets
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                })
                .UseBarcodeReader();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<IEventService, MauiEventService>();
            builder.Services.AddScoped<ITicketService, MauiTicketService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
