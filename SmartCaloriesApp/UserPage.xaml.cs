using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using SmartCaloriesLibrary;

namespace SmartCaloriesApp;

public partial class UserPage : ContentPage
{
    private User _sharedUser;
	public UserPage(User user)
	{
		InitializeComponent();
        _sharedUser = user;
        List<int> ageList = Enumerable.Range(1, 100).ToList();
        _pkrAge.ItemsSource = ageList;
    }

    private async void OnSubmit(object sender, EventArgs e)
    {
        _sharedUser.Name = _txtName.Text;
        if(_radioMale.IsChecked)
        {
            _sharedUser.Gender = "Male";
        }
        else
        {
            _sharedUser.Gender = "Female";
        }
        _sharedUser.Age = (int)_pkrAge.SelectedItem;
        _sharedUser.CrtWeight = double.Parse(_txtCrtWeight.Text);
        _sharedUser.TrgtWeight = double.Parse(_txtTargetWeight.Text);
        _sharedUser.Height = double.Parse(_txtHeight.Text);
        _sharedUser.Activity = _pkrActivity.SelectedIndex;
        if (_pkrDays.SelectedItem.ToString() == "Slow and Steady(26 weeks)")
        {
            _sharedUser.Days = 182;
        }
        else if (_pkrDays.SelectedItem.ToString() == "Go with the flow(15 weeks)")
        {
            _sharedUser.Days = 105;
        }
        else if (_pkrDays.SelectedItem.ToString() == "Lets go crazy (6 weeks)")
        {
            _sharedUser.Days = 42;
        }
        else
        {
            _sharedUser.Days = 7;
        }
        _sharedUser.CalcDailyCalories();
        string data = $"{_sharedUser.Name} needs to eat around '{(int)_sharedUser.Calories}' calories for '{_sharedUser.Days / 7}' weeks to achieve desireable weight of '{_sharedUser.TrgtWeight}' Kg\n Are you ready to begin your journey ?";
        await DisplayAlertAsync("Target",data,"OK");
        await Shell.Current.GoToAsync("//Planner");

    }
}