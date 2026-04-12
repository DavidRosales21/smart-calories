using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using Microsoft.Maui.Controls;
using SmartCaloriesLibrary;
using System.Collections.ObjectModel;


namespace SmartCaloriesApp;


public partial class Planner : ContentPage
{

	private ObservableCollection<DaySummary> _dayPlans;
	private User _user;
	private List<Day> _days;
    public Planner(User user)
    {
		_user = user;
        InitializeComponent();
        _dayPlans = new ObservableCollection<DaySummary>();
        _mealPlansList.ItemsSource = _dayPlans;
		_days = new List<Day>();
    }

    protected override void OnAppearing()
	{
		base.OnAppearing();
        _txtCalories.Text = ((int)_user.Calories).ToString();
        LoadPickers();
	}

	private void LoadPickers()
	{
		
		System.Diagnostics.Debug.WriteLine($"Total meals: {App.Library.Meals.Count}");

		_breakfastPicker.ItemsSource = App.Library.GetMealsByType("Breakfast");
		_lunchPicker.ItemsSource = App.Library.GetMealsByType("Lunch");
		_dinnerPicker.ItemsSource = App.Library.GetMealsByType("Dinner");
		_snackPicker.ItemsSource = App.Library.GetMealsByType("Snack");
	}

	private async void _btnPlannerSave_OnClicked(object? sender, EventArgs e)
	{
		string selectedDay = _mealDatePicker.Date.Value.ToString("MMM dd");
		// date validation that is not selected before 
		if (_dayPlans.Any(d => d.Date == selectedDay))
		{
			await	DisplayAlert("Date Taken"," You already have a plan for this day. Please select a different date.", "OK");
			return;
		}
		
		// meals validation to make sure the user have selected it before saving 
		
		if (_breakfastPicker.SelectedItem == null)
		{
			await DisplayAlert("Missing Meal", "Please select a Breakfast.", "OK");
			return;
		}

		if (_snackPicker.SelectedItem == null)
		{
			await DisplayAlert("Missing Meal", "Please select a Snack.", "OK");
		}
		
		if (_lunchPicker.SelectedItem == null)
		{
			await DisplayAlert("Missing Meal", "Please select a Lunch.", "OK");
			return;
		}

		
		if (_dinnerPicker.SelectedItem == null)
		{
			await DisplayAlert("Missing Meal", "Please select a Dinner.", "OK");
			return;
		}
		// validation for the work out options 
		if (!_radioNo.IsChecked && !_radioYes.IsChecked)
		{
			await DisplayAlert("Missing Selection", "Please select Yes or No for  workOut ", "OK");
			return;
		}

		if (_radioYes.IsChecked && _workoutPicker == null)
		{
			await DisplayAlert("Missing WorkOut ", "Please select a Workout ", "OK");
			return;
		}
		
		DateTime date = _mealDatePicker.Date.Value;
		Day day = new Day(date,_user.Calories);

		if (_breakfastPicker.ItemsSource != null)
		{
			day.AddMeal((Meal)_breakfastPicker.SelectedItem);
		}

		if (_lunchPicker.ItemsSource != null)
		{
			day.AddMeal((Meal)_lunchPicker.SelectedItem);
		}

		if (_dinnerPicker.ItemsSource != null)
		{
			day.AddMeal((Meal)_dinnerPicker.SelectedItem);
		}

		if (_snackPicker.ItemsSource != null)
		{
			day.AddMeal((Meal)_snackPicker.SelectedItem);
		}

		if (_radioYes.IsChecked && _workoutPicker.ItemsSource != null)
		{
			day.AddWorkout((Workout)_workoutPicker.SelectedItem);
		}

		_nutritionalValueLabel.Text = $"{day.GetNetCalories()} cals";

		
		DaySummary summary = new DaySummary
		{
			Date = day.Date.ToString("MMM dd"),
			Meals = string.Join(", ", day.MealList.Select(m => m.Name)),
			Workout = day.WorkoutList.Count > 0 ? day.WorkoutList[0].Name : "None",
			CaloriesEaten = day.GetCaloriesEaten(),
			CaloriesBurned = day.GetCaloriesBurned(),
			NetCalories = day.GetNetCalories(),
			Status = day.GetCalorieStatus()
		};

		// adding a day object to the daylist 
		_days.Add(day);	
		App.Days.Add(day);

		_dayPlans.Add(summary);
		
		_breakfastPicker.SelectedItem = null;
		_lunchPicker.SelectedItem = null;
		_dinnerPicker.SelectedItem = null;
		_snackPicker.SelectedItem = null;
		_workoutPicker.SelectedItem = null;
		_radioYes.IsChecked = false;
		_radioNo.IsChecked = false;
		_workoutPicker.IsVisible = false;
		_workoutLabel.IsVisible = false;

		_navigationBtn.IsVisible = true;


    }

	private void _radioYes_CheckedChanged(object? sender, CheckedChangedEventArgs e)
	{

		if (e.Value)
		{
			_workoutLabel.IsVisible = true; 
			_workoutPicker.IsVisible = true;
			_workoutPicker.ItemsSource = App.Library.Workouts;
			
			
		}
	}

	private void _radioNo_CheckedChanged(object? sender, CheckedChangedEventArgs e)
	{
		if (e.Value)
		{
			_workoutPicker.IsVisible = false;
			_workoutLabel.IsVisible = false;
		}
	}

	private async void _btnGoToRecipes_OnClicked(object? sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//Day");
	}

	private void _btnGoToWorkOut_OnClicked(object? sender, EventArgs e)
	{
		throw new NotImplementedException();
	}

	public List<Day> Days
	{
		get{return _days;}
	}
}