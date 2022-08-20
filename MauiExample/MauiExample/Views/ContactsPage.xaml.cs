namespace MauiExample.Views;

public partial class ContactsPage : ContentPage
{
	private readonly IContacts _contacts;
	private readonly IMap _map;
    private readonly IGeolocation _geolocation;
    private readonly IShare _share;

    public ContactsPage(IContacts contacts, IMap map, IGeolocation geolocation, IShare share)
	{
		InitializeComponent();
		_contacts = contacts;
		_map = map;
        _geolocation = geolocation;
        _share = share;
    }

	private async void btnLoadContacts_Clicked(object sender, EventArgs e)
	{
        //var location = await _geolocation.GetLocationAsync(new GeolocationRequest { DesiredAccuracy = GeolocationAccuracy.Best});

        await _share.RequestAsync(new ShareTextRequest
        { 
            Uri = "https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/data/share?tabs=android",
            Subject = "Test subject",
            Title = "Test title"
        });

        //var home = new Location(50.4993913, 30.4997799);


        //var km = Location.CalculateDistance(location, home, DistanceUnits.Kilometers);
        
        //var options = new MapLaunchOptions { Name = "Test region", NavigationMode = NavigationMode.Default };

        //try
        //{
        //    await _map.OpenAsync(home, options);
        //}
        //catch (Exception ex)
        //{
        //    // No map application available to open
        //}
    }
}