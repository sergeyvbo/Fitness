using CommunityToolkit.Maui;
using Fitness.DB;
using Fitness.Models;
using Fitness.Services;
using Fitness.ViewModels;
using Fitness.Views;
using Syncfusion.Maui.Core.Hosting;

namespace Fitness;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.RegisterAppServices()
            .RegisterModels()
            .RegisterViewModels()
            .RegisterViews()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionCore()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<FitnessDatabase>();
        mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();
        return mauiAppBuilder;
    }
    public static MauiAppBuilder RegisterModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<LoginFormModel>();
        
        return mauiAppBuilder;
    }
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
	{
        mauiAppBuilder.Services.AddSingleton<MainViewModel>();
        mauiAppBuilder.Services.AddSingleton<LoginFormViewModel>();
        mauiAppBuilder.Services.AddTransient<ExerciseViewModel>();
        mauiAppBuilder.Services.AddTransient<WorkoutListViewModel>();
        mauiAppBuilder.Services.AddTransient<WorkoutViewModel>();
        return mauiAppBuilder;
    }
    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<AppShell>();
        mauiAppBuilder.Services.AddSingleton<LoginPage>();
        mauiAppBuilder.Services.AddSingleton<WorkoutList>();
        mauiAppBuilder.Services.AddSingleton<MainPage>();
        mauiAppBuilder.Services.AddSingleton<SettingsPage>();
        mauiAppBuilder.Services.AddSingleton<ReportsPage>();
        mauiAppBuilder.Services.AddTransient<ExerciseView>();
        return mauiAppBuilder;
    }
}
