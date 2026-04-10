using System.Collections.ObjectModel;

namespace SmartCaloriesApp;
using SmartCaloriesLibrary;

public partial class DayPage : ContentPage
{
    private Planner _planner;
    private List<Day> _days;
    private int _crtMealIndex;
    private DateTime _crtDate;
    private int _crtDay;

    public DayPage(Planner planner)
	{
        _planner = planner;
		InitializeComponent();
        _days = _planner.Days;
        _crtMealIndex = 0;
        _crtDate = DateTime.Today;
        _crtDay = 0;
	}

    private void OnNextReciepe(object sender, EventArgs e)
    {
        _txtMeal.Text = _days[_crtDay].MealList[_crtMealIndex].Name;
        _crtMealIndex += 1;
        _txtReciepe.Text = _days[_crtDay].MealList[_crtMealIndex].Recipe;
        _lstIngredients.ItemsSource = _days[_crtDay].MealList[_crtMealIndex].Ingredients;
    }
    private void OnPrevReciepe(object sender, EventArgs e)
    {
        _crtMealIndex -= 1;
        _txtReciepe.Text = _days[_crtDay].MealList[_crtMealIndex].Recipe;
        _lstIngredients.ItemsSource = _days[_crtDay].MealList[_crtMealIndex].Ingredients;
    }

    private async void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        try
        {
        _crtDate = (DateTime)_pckDay.Date;
        searchPlan(_crtDate);
        _lstWorkOut.Text = _days[_crtDay].WorkoutList[0].ToString();
        }
        catch(Exception ex)
        {

        }
       
    }

    private void searchPlan(DateTime date)
    {
        for (int dayIndex = 0; dayIndex<_days.Count; dayIndex++)
        foreach (Day day in _days)
        {
            if (day.Date == date)
            {
                    break;     
            }
            _crtDay = dayIndex;
        }
    }
}