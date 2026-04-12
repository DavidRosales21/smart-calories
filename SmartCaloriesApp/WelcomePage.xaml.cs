using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCaloriesLibrary;
namespace SmartCaloriesApp;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
    }

    private async void OnStartClicked(object? sender, EventArgs e)
    {
        
        Application.Current!.Windows[0].Page = new AppShell();
        
    }
}