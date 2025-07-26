using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SisonkeBank.Data;
using System.IO;
using CommunityToolkit.Maui;

namespace SisonkeBank;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // ✅ Register DatabaseHelper
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "sisonkebank.db");
        builder.Services.AddSingleton(new DatabaseHelper(dbPath));

        return builder.Build();
    }
}
