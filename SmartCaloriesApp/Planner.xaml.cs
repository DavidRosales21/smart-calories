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

		_nutritionalValueLabel.Text = $"{day.GetCaloriesEaten()} cals";


	}
}