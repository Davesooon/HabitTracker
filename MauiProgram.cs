﻿using HabitTracker.View;
using HabitTracker.ViewModel;
using Microsoft.Extensions.Logging;

namespace HabitTracker
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            //builder.Services.AddViewModel<MainViewModel, MainPage>();
            //builder.Services.AddViewModel<HabitViewModel, HabitPage>();
            //builder.Services.AddViewModel<HabitInfoViewModel, HabitInfo>();

            return builder.Build();
        }

        //private static void AddViewModel<TViewModel, TView>(this IServiceCollection services)
        //    where TView : ContentPage, new()
        //    where TViewModel : class
        //{
        //    services.AddTransient<TViewModel>();
        //    services.AddTransient<TView>(s => new TView() { BindingContext = s.GetRequiredService<TViewModel>() });
        //}
    }
}
