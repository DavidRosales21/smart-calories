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
        try
        {
            _sharedUser.Name = _txtName.Text;
            if (_radioMale.IsChecked)
            {
                _sharedUser.Gender = "Male";
            }
            else
            {
                _sharedUser.Gender = "Female";
            }
            if(_pkrAge.SelectedIndex == -1 || _pkrActivity.SelectedIndex == -1 || _pkrDays.SelectedIndex == -1)
            {
                await DisplayAlertAsync("Missing Info", "Please pick an option from all dropdowns.", "OK");
                return;
            }
            _sharedUser.Age = (int)_pkrAge.SelectedItem;
            if(string.IsNullOrEmpty(_txtCrtWeight.Text) || string.IsNullOrEmpty(_txtTargetWeight.Text) || string.IsNullOrEmpty(_txtHeight.Text))
            {
                throw new ArgumentException("All of the fields have to be filled");
            }
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
            if(_sharedUser.Calories <700)
            {
                throw new ExtremeWeightLossException("Extreme Weight Loss goals. Choose goals carefully");
            }
            string data = $"{_sharedUser.Name} needs to eat around '{(int)_sharedUser.Calories}' calories daily for '{_sharedUser.Days / 7}' weeks to achieve desireable weight of '{_sharedUser.TrgtWeight}' Kg\n Are you ready to begin your journey ?";
            await DisplayAlertAsync("Target", data, "OK");
            await Shell.Current.GoToAsync("//Planner");
        }
        catch (ExtremeWeightLossException err)
        {
            await DisplayAlertAsync("User", $"Error: {err.Message}", "OK");
        }
        catch (FormatException err)
        {
            await DisplayAlertAsync("User", $"Error: {err.Message}", "OK");
        }
        catch (ArgumentException err)
        {
            await DisplayAlertAsync("User", $"Error: {err.Message}", "OK");
        }
        catch (NullReferenceException err)
        {
            await DisplayAlertAsync("User", $"Error: {err.Message}", "OK");
        }
        catch (Exception err)
        {
            await DisplayAlertAsync("User",$"Error: {err.Message}" , "OK");
        }

    }
}