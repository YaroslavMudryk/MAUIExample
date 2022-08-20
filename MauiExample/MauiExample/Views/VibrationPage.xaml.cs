namespace MauiExample.Views;

public partial class VibrationPage : ContentPage
{
	private readonly IVibration _vibration;
	public VibrationPage(IVibration vibration)
	{
		InitializeComponent();
		_vibration = vibration;

        if (!_vibration.IsSupported)
        {
            buttonStart.IsEnabled = false;
            DisplayAlert("Помилка", "Вібрація не підртимується даним пристроєм", "OK");
        }
	}

	private async void buttonStart_Clicked(object sender, EventArgs e)
	{
        try
        {
            var countOfAttempt = Convert.ToInt32(countOfAttempts.Text);
            var durationOfAttempt = Convert.ToInt32(durationOfAttempts.Text);

            _vibration.Cancel();

            for (int i = 0; i < countOfAttempt; i++)
            {
                _vibration.Vibrate(TimeSpan.FromMilliseconds(durationOfAttempt));
                await Task.Delay(durationOfAttempt);
                _vibration.Cancel();
                await Task.Delay(durationOfAttempt);
            }
        }
        catch (Exception ex)
        {

        }
    }
}