using System.Text;

namespace MauiExample.Views;

public partial class DevicePage : ContentPage
{
	private readonly IDeviceInfo _deviceInfo;

	public DevicePage(IDeviceInfo deviceInfo)
	{
		InitializeComponent();
		_deviceInfo = deviceInfo;
        Init();

    }

	private void Init()
	{
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Model: {_deviceInfo.Model}");
        sb.AppendLine($"Manufacturer: {_deviceInfo.Manufacturer}");
        sb.AppendLine($"Name: {_deviceInfo.Name}");
        sb.AppendLine($"OS Version: {_deviceInfo.VersionString}");
        sb.AppendLine($"Refresh Rate: {DeviceInfo.Current}");
        sb.AppendLine($"Idiom: {_deviceInfo.Idiom}");
        sb.AppendLine($"Platform: {_deviceInfo.Platform}");

        bool isVirtual = _deviceInfo.DeviceType switch
        {
            DeviceType.Physical => false,
            DeviceType.Virtual => true,
            _ => false
        };

        sb.AppendLine($"Virtual device? {isVirtual}");

        deviceDetailsLabel.Text = sb.ToString();
    }
}