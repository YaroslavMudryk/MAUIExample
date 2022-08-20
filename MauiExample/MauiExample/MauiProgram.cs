using MauiExample.Views;
using Microsoft.Maui.Devices;

namespace MauiExample;

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

		builder.Services.AddSingleton<BatteryPage>();
		builder.Services.AddSingleton<IBattery>(Battery.Default);

        builder.Services.AddSingleton<DisplayPage>();
        builder.Services.AddSingleton<IDeviceDisplay>(DeviceDisplay.Current);

		builder.Services.AddSingleton<DevicePage>();
		builder.Services.AddSingleton<IDeviceInfo>(DeviceInfo.Current);

		builder.Services.AddSingleton<FlashlightPage>();
		builder.Services.AddSingleton<IFlashlight>(Flashlight.Default);

		return builder.Build();
	}
}
