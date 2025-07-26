using SisonkeBank.Data;
using SisonkeBank.Models;
using SisonkeBank.Views; 

namespace SisonkeBank.Views
{
    public partial class RegistrationPage : ContentPage
    {
        private readonly DatabaseHelper _database;

        public RegistrationPage(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _database = dbHelper;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            var newUser = new User { Email = email, Password = password };

            try
            {
                bool success = await _database.RegisterUserAsync(newUser);
                if (success)
                {
                    await DisplayAlert("Success", "Registration successful!", "OK");

                    
                    await Navigation.PushAsync(new LoginPage(_database));
                }
                else
                {
                    await DisplayAlert("Error", "Email already exists.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}