using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using Microsoft.Maui.Controls;
using SmartCaloriesLibrary;
using System.Collections.ObjectModel;


namespace SmartCaloriesApp;

public partial class Planner : ContentPage
{

	private ObservableCollection<DaySummary> _dayPlans = new ObservableCollection<DaySummary>();	
    public Planner()
    {
        InitializeComponent();
        _mealPlansList.ItemsSource = _dayPlans;
    }
    public Planner(double calories)
    {
        InitializeComponent();
        _txtCalories.Text = ((int)calories).ToString();

    }

    protected override void OnAppearing()
	{
		base.OnAppearing();
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
		
		DateTime date = _mealDatePicker.Date.Value;
		Day day = new Day(date,2000);

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
			day.AddMeal((Meal)_lunchPicker.SelectedItem);
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
}