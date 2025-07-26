using Microsoft.Maui.Controls;
using SisonkeBank.Data;
using SisonkeBank.Models;

namespace SisonkeBank.Views;

public partial class LoginPage : ContentPage
{
    private readonly DatabaseHelper _database;

    public LoginPage(DatabaseHelper dbHelper)
    {
        InitializeComponent();
        _database = dbHelper;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = emailEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            messageLabel.Text = "Please enter both email and password.";
            messageLabel.IsVisible = true;
            return;
        }

        var user = await _database.GetUserByEmailAsync(email);

        if (user == null || user.Password != password)
        {
            messageLabel.Text = "Invalid credentials.";
            messageLabel.IsVisible = true;
            return;
        }

        
        App.LoggedInUser = user;

        
        if (user.Balance == 0)
        {
            user.Balance = 2000; 
            await _database.UpdateUserAsync(user);
        }

        await DisplayAlert("Login Success", $"Welcome back, {user.Email}!", "OK");

        
        await Navigation.PushAsync(new MainPage(_database));
    }
}
