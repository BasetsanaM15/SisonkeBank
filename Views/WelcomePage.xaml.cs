using Microsoft.Maui.Controls;
using SisonkeBank.Data;
using SisonkeBank.Views; 

namespace SisonkeBank.Views 
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private async void OnGetStartedClicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new RegistrationPage(App.DatabaseHelper));
        }
    }
}