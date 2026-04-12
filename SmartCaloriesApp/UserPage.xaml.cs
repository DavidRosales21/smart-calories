using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using SmartCaloriesLibrary;

namespace SmartCaloriesApp;

/// <summary>
/// Author : Antesh Kumar Sharma
/// Represents the cs file for the User page which does all the backend data processing for calculating the daily calories and saving user.
/// </summary>
public partial class UserPage : ContentPage
{
    private User _sharedUser;
	public UserPage(User user)
	{
		InitializeComponent();
        _sharedUser = user;
        
    }

    private async void OnSubmit(object sender, EventArgs e)
    {
        try
        {

            if (string.IsNullOrEmpty(_txtName.Text))
            {
                await DisplayAlert("Missing Info", "Please enter your full name", "OK");
                return;
            }
            _sharedUser.Name = _txtName.Text;
            if (_radioMale.IsChecked)
            {
                _sharedUser.Gender = "Male";
            }
            else
            {
                _sharedUser.Gender = "Female";
            }
            if(string.IsNullOrEmpty(_txtAge.Text)   || _pkrActivity.SelectedIndex == -1 || _pkrDays.SelectedIndex == -1)
            {
                await DisplayAlert("Missing Info", "Please pick an option from all dropdowns.", "OK");
                return;
            }
            
            _sharedUser.Age = int.Parse(_txtAge.Text);

            if (_sharedUser.Age < 18 )
            {
                await DisplayAlert("Missing Info", "You have to be  18 or older  to use our app otherwise we need your parent approval please contact us  ", "OK");
                return;
            }

            if (_sharedUser.Age > 100)
            {
                await DisplayAlert("Error",
                    "Please in your age we can't help you with a meal plan you can refer to your physician ", "OK");
                return; 
            }
            
            if(string.IsNullOrEmpty(_txtCrtWeight.Text) || string.IsNullOrEmpty(_txtTargetWeight.Text) || string.IsNullOrEmpty(_txtHeight.Text))
            {
                throw new ArgumentException("All of the fields have to be filled");
            }
            
            _sharedUser.CrtWeight = double.Parse(_txtCrtWeight.Text);
            _sharedUser.TrgtWeight = double.Parse(_txtTargetWeight.Text);
            _sharedUser.Height = double.Parse(_txtHeight.Text);

            if (_sharedUser.CrtWeight < 30 || _sharedUser.CrtWeight > 300)
            {
                await DisplayAlert("Invalid Weight", "Please enter a realistic current weight (30-300 kg).", "OK");
                return;
            }
            if (_sharedUser.TrgtWeight < 30 || _sharedUser.TrgtWeight > 300)
            {
                await DisplayAlert("Invalid Weight", "Please enter a realistic target weight (30-300 kg).", "OK");
                return;
            }
            if (_sharedUser.Height < 100 || _sharedUser.Height > 250)
            {
                await DisplayAlert("Invalid Height", "Please enter a realistic height (100-250 cm).", "OK");
                return;
            }
            
            
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

            string data = $"Hi {_sharedUser.Name}!\n\n" +
                          $"Daily Calorie Target: {(int)_sharedUser.Calories} calories\n" +
                          $"Goal Duration: {_sharedUser.Days / 7} weeks\n" +
                          $"Target Weight: {_sharedUser.TrgtWeight} kg\n\n" +
                          $"Are you ready to begin your journey?";
            
            await DisplayAlert("Target", data, "OK");
            await Shell.Current.GoToAsync("//Planner");
        }
        catch (ExtremeWeightLossException err)
        {
            await DisplayAlert("User", $"Error: {err.Message}", "OK");
        }
        catch (FormatException err)
        {
            await DisplayAlert("User", $"Error: {err.Message}", "OK");
        }
        catch (ArgumentException err)
        {
            await DisplayAlert("User", $"Error: {err.Message}", "OK");
        }
        catch (NullReferenceException err)
        {
            await DisplayAlert("User", $"Error: {err.Message}", "OK");
        }
        catch (Exception err)
        {
            await DisplayAlert("User",$"Error: {err.Message}" , "OK");
        }

    }
}