using System;
using System.Runtime.InteropServices;
using Microsoft.Maui.Controls;
using SmartCaloriesLibrary;

namespace SmartCaloriesApp;

public partial class Planner : ContentPage
{
	public Planner()
	{
		InitializeComponent();
		
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

	private void _btnPlannerSave_OnClicked(object? sender, EventArgs e)
	{
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