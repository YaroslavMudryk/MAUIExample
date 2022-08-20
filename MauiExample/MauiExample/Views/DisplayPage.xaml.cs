namespace MauiExample.Views;

public partial class DisplayPage : ContentPage
{
	private readonly IDeviceDisplay _deviceDisplay;

	public DisplayPage(IDeviceDisplay deviceDisplay)
    {
        InitializeComponent();
        _deviceDisplay = deviceDisplay;

        InitInfo(_deviceDisplay.MainDisplayInfo);

        _deviceDisplay.MainDisplayInfoChanged += (sender, e) =>
        {
            InitInfo(e.DisplayInfo);
        };
    }

    public void InitInfo(DisplayInfo displayInfo)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.AppendLine($"Resolution: {_deviceDisplay.MainDisplayInfo.Height} / {_deviceDisplay.MainDisplayInfo.Width}");
        sb.AppendLine($"Density: {_deviceDisplay.MainDisplayInfo.Density}");
        sb.AppendLine($"Orientation: {_deviceDisplay.MainDisplayInfo.Orientation}");
        sb.AppendLine($"Rotation: {_deviceDisplay.MainDisplayInfo.Rotation}%");
        sb.AppendLine($"Refresh Rate: {_deviceDisplay.MainDisplayInfo.RefreshRate}");

        displayDetailsLabel.Text = sb.ToString();
    }
}