using SisonkeBank.Models;
using SisonkeBank.Data;
using SisonkeBank.Pages;

namespace SisonkeBank.Pages;

public partial class MainPage : ContentPage
{
    private readonly DatabaseHelper _database;

    public MainPage(DatabaseHelper dbHelper)
    {
        InitializeComponent();
        _database = dbHelper;

        NavigationPage.SetHasBackButton(this, false);
    }

    private async void OnTransferFundsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TransferFundsPage(_database));
    }

    private async void OnViewBalanceClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewBalancePage(_database));
    }
}
