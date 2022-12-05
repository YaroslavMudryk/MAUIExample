using MauiExample.Services;
using System.Text;

namespace MauiExample.Views;

public partial class DevicePage : ContentPage
{
	private readonly IDeviceInfo _deviceInfo;
    private readonly IDeviceId _deviceId;

    public DevicePage(IDeviceInfo deviceInfo, IDeviceId deviceId)
	{
		InitializeComponent();
		_deviceInfo = deviceInfo;
        _deviceId = deviceId;
        Init();
    }

	private void Init()
	{
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Model: {_deviceInfo.Model}");
        sb.AppendLine($"Manufacturer: {_deviceInfo.Manufacturer}");
        sb.AppendLine($"Name: {_deviceInfo.Name}");
        sb.AppendLine($"OS Version: {_deviceInfo.VersionString}");
        sb.AppendLine($"Idiom: {_deviceInfo.Idiom}");
        sb.AppendLine($"Platform: {_deviceInfo.Platform}");

        bool isVirtual = _deviceInfo.DeviceType switch
        {
            DeviceType.Physical => false,
            DeviceType.Virtual => true,
            _ => false
        };

        sb.AppendLine($"Virtual device: {isVirtual}");
        sb.AppendLine($"Device ID: {_deviceId.GetDeviceId()}");

        deviceDetailsLabel.Text = sb.ToString();
    }
}