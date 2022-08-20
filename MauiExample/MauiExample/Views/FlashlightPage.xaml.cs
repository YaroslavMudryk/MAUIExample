namespace MauiExample.Views;

public partial class FlashlightPage : ContentPage
{
    private readonly IFlashlight _flashlight;
    public FlashlightPage(IFlashlight flashlight)
    {
        InitializeComponent();
        _flashlight = flashlight;
    }

    private async void flashlightCheck_Toggled(object sender, ToggledEventArgs e)
    {
        try
        {
            if (flashlightCheck.IsToggled)
                await _flashlight.TurnOnAsync();
            else
                await _flashlight.TurnOffAsync();
        }
        catch (FeatureNotSupportedException ex)
        {
            // Handle not supported on device exception
        }
        catch (PermissionException ex)
        {
            // Handle permission exception
        }
        catch (Exception ex)
        {
            // Unable to turn on/off flashlight
        }
    }

    private async void buttonStart_Clicked(object sender, EventArgs e)
    {
        try
        {
            var countOfAttempt = Convert.ToInt32(countOfAttempts.Text);
            var durationOfAttempt = Convert.ToInt32(durationOfAttempts.Text);

            await _flashlight.TurnOffAsync();

            for (int i = 0; i < countOfAttempt; i++)
            {
                await _flashlight.TurnOnAsync();
                await Task.Delay(durationOfAttempt);
                await _flashlight.TurnOffAsync();
                await Task.Delay(durationOfAttempt);
            }
        }
        catch (Exception ex)
        {

        }
    }
}