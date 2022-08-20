using MauiExample.Views;
using Microsoft.Extensions.DependencyInjection;

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

		builder.Services.AddSingleton<VibrationPage>();
		builder.Services.AddSingleton<IVibration>(Vibration.Default);

        builder.Services.AddSingleton<ContactsPage>();
        builder.Services.AddSingleton<IContacts>(Contacts.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
		builder.Services.AddSingleton<IShare>(Share.Default);

        return builder.Build();
	}
}
