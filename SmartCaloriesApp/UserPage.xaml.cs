using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using SmartCaloriesLibrary;

namespace SmartCaloriesApp;

public partial class UserPage : ContentPage
{
	public UserPage()
	{

		InitializeComponent();
        List<int> ageList = Enumerable.Range(1, 100).ToList();
        _pkrAge.ItemsSource = ageList;
    }

    private async void OnSubmit(object sender, EventArgs e)
    {
        string name = _txtName.Text;
        string gender = "";
        if(_radioMale.IsChecked)
        {
            gender = "Male";
        }
        else
        {
            gender = "Female";
        }
        int age = (int)_pkrAge.SelectedItem;
        double crtWeight = double.Parse(_txtCrtWeight.Text);
        double trgtWeight = double.Parse(_txtTargetWeight.Text);
        double height = double.Parse(_txtHeight.Text);
        int activity = _pkrActivity.SelectedIndex;
        int days = 0;
        if (_pkrDays.SelectedItem.ToString() == "Slow and Steady(26 weeks)")
        {
            days = 182;
        }
        else if (_pkrDays.SelectedItem.ToString() == "Go with the flow(15 weeks)")
        {
            days = 105;
        }
        else if (_pkrDays.SelectedItem.ToString() == "Lets go crazy (6 weeks)")
        {
            days = 42;
        }
        else
        {
            days = 7;
        }
        User user = new User(name,crtWeight,trgtWeight,height,age,gender,activity,days);
        double dailyCalories = user.CalcDailyCalories();
        string data = $"{user.Name} needs to eat around '{(int)dailyCalories}' calories for '{user.Days / 7}' weeks to achieve desireable weight of '{user.TrgtWeight}' Kg\n Are you ready to begin your journey ?";
        bool nextPage = await DisplayAlertAsync("Target",data,"Yes", "No, Make Changes!!");
        if(nextPage)
        {
            await Navigation.PushAsync(new Planner(user));
        }

    }
}