﻿using Maui.FixesAndWorkarounds;
using Microsoft.Extensions.Logging;

namespace FiMa;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.ConfigureMauiWorkarounds();
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}

