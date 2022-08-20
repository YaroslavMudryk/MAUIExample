namespace MauiExample.Views;

public partial class BatteryPage : ContentPage
{
	private readonly IBattery _battery;
    public BatteryPage(IBattery battery)
	{
		InitializeComponent();
		_battery = battery;
        _battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
        _battery.EnergySaverStatusChanged += Battery_EnergySaverStatusChanged;

        Init();
    }

    public void Init()
    {
        batteryPowerSourceLabel.Text = _battery.PowerSource switch
        {
            BatteryPowerSource.Wireless => "Wireless charging",
            BatteryPowerSource.Usb => "USB cable charging",
            BatteryPowerSource.AC => "Device is plugged in to a power source",
            BatteryPowerSource.Battery => "Device isn't charging",
            _ => "Unknown"
        };

        powerEnergyButton.Text = _battery.EnergySaverStatus switch
        {
            EnergySaverStatus.On => "Енергозберіжаючий режим увімкнений",
            EnergySaverStatus.Off => "Енергозберіжаючий режим вимкнений",
            EnergySaverStatus.Unknown => "Невідомий режим",
            _ => "Невідомий режим"
        };

        batteryStateLabel.Text = _battery.State switch
        {
            BatteryState.Charging => "Battery is currently charging",
            BatteryState.Discharging => "Charger is not connected and the battery is discharging",
            BatteryState.Full => "Battery is full",
            BatteryState.NotCharging => "The battery isn't charging.",
            BatteryState.NotPresent => "Battery is not available.",
            BatteryState.Unknown => "Battery is unknown",
            _ => "Battery is unknown"
        };

        batteryLevelLabel.Text = $"Battery is {_battery.ChargeLevel * 100}% charged.";
    }

    private void Battery_EnergySaverStatusChanged(object sender, EnergySaverStatusChangedEventArgs e)
    {
        powerEnergyButton.Text = e.EnergySaverStatus switch
        {
            EnergySaverStatus.On => "Енергозберіжаючий режим увімкнений",
            EnergySaverStatus.Off => "Енергозберіжаючий режим вимкнений",
            EnergySaverStatus.Unknown => "Невідомий режим",
            _ => "Невідомий режим"
        };
    }

    private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
    {
        batteryStateLabel.Text = e.State switch
        {
            BatteryState.Charging => "Battery is currently charging",
            BatteryState.Discharging => "Charger is not connected and the battery is discharging",
            BatteryState.Full => "Battery is full",
            BatteryState.NotCharging => "The battery isn't charging.",
            BatteryState.NotPresent => "Battery is not available.",
            BatteryState.Unknown => "Battery is unknown",
            _ => "Battery is unknown"
        };

        batteryLevelLabel.Text = $"Battery is {e.ChargeLevel * 100}% charged.";
    }
}