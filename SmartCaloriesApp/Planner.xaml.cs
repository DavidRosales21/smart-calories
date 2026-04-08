using System.Runtime.InteropServices;

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
}