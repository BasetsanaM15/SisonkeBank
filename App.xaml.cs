using Microsoft.Maui.Controls;
using Microsoft.Maui.LifecycleEvents;
using SisonkeBank.Data;

namespace SisonkeBank;

public partial class App : Application
{
    public static DatabaseHelper? DatabaseHelper { get; private set; }
    public static Models.User? LoggedInUser { get; set; }

    public App(DatabaseHelper dbHelper)
    {
        InitializeComponent();
        DatabaseHelper = dbHelper;
    }

    
    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(new Views.WelcomePage()));
    }
}
