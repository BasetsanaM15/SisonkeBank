using SisonkeBank.Data;
using SisonkeBank.Models;
using Microsoft.Maui.Controls;

namespace SisonkeBank.Pages;

public partial class ViewBalancePage : ContentPage
{
    private readonly DatabaseHelper _databaseHelper;

    public ViewBalancePage(DatabaseHelper dbHelper)
    {
        InitializeComponent();
        _databaseHelper = dbHelper;

        
        var user = App.LoggedInUser;
        if (user != null)
        {
            balanceLabel.Text = $"R {user.Balance:F2}";
        }
        else
        {
            balanceLabel.Text = "User not logged in.";
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
