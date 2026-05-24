using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using YuNo;


namespace YuNo
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddScoped<DiaryRepository>();
            builder.Services.AddScoped<StatisticsService>();
            builder.Services.AddMudServices();
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass =
                    Defaults.Classes.Position.BottomCenter;
            });
            builder.Services.AddSingleton<ThemeService>();


            var app = builder.Build();

            // ← ИНИЦИАЛИЗАЦИЯ SQLITE
            InitializeDatabase(app.Services)
                .GetAwaiter()
                .GetResult();

            return app;
        }

        private static async Task InitializeDatabase(
        IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var database = scope.ServiceProvider
                .GetRequiredService<DatabaseService>();

            await database.InitializeAsync();
        }
    }
}
