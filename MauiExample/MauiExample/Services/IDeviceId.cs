using DeviceId;
namespace MauiExample.Services
{
    public interface IDeviceId
    {
        string GetDeviceId();
    }

    public class AndroidDeviceId : IDeviceId
    {
        public string GetDeviceId()
        {
            return Android.Provider.Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
        }
    }

    public class WindowsDeviceId : IDeviceId
    {
        public string GetDeviceId()
        {
            return new DeviceIdBuilder()
                .AddMachineName()
                .AddOsVersion()
                .OnWindows(winda =>
                    winda.AddProcessorId()
                    .AddMotherboardSerialNumber()
                    .AddSystemDriveSerialNumber())
                .ToString();
        }
    }
}
