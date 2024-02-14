using MauiTickets.Databases;
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
                .UseBarcodeReader()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<IEventService, MauiEventService>();
            builder.Services.AddScoped<ITicketService, MauiTicketService>();
            builder.Services.AddScoped<MailMailMail>();
            builder.Services.AddDbContext<ticketAppDb>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
