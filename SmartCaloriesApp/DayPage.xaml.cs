using System.Collections.ObjectModel;
/// David
namespace SmartCaloriesApp;
using SmartCaloriesLibrary;
using System.Linq.Expressions;

/// <summary>
/// the Day Page allows the user to visualize the meals ( reciepes + ingredients) and the workout planned for the day
/// </summary>
public partial class DayPage : ContentPage
{
    #region fields
    private Planner _planner;
    private List<Day> _days;
    private int _crtMealIndex;
    private DateTime _crtDate;
    private int _crtDay;
    #endregion

    #region constructor

    public DayPage(Planner planner)
	{
        _planner = planner;
		InitializeComponent();
        _days = _planner.Days;
        _crtMealIndex = 0;
        _crtDate = DateTime.Today;
        _crtDay = 0;
	}
    #endregion 

    /// <summary>
    ///  OnNextReciepe and OnPrevReciepe allos the user to navigate between the diferent meals on the selected day
    /// </summary>
    private async void OnNextReciepe(object sender, EventArgs e)
    {
        try
        {
            if (_crtMealIndex <= 3)
            {
                _crtMealIndex += 1;
                _txtMeal.Text = _days[_crtDay].MealList[_crtMealIndex].Name;
                _txtReciepe.Text = _days[_crtDay].MealList[_crtMealIndex].Recipe;
                _lstIngredients.ItemsSource = _days[_crtDay].MealList[_crtMealIndex].Ingredients;
            }
            else
            {
                
            }
        }
        catch(Exception ex)
        {
            await DisplayAlertAsync("Smart Calories", $"Unexpected error in the reciepe book.", "ok");
        }
          
    }
    private async void OnPrevReciepe(object sender, EventArgs e)
    {
        try
        {
        if (_crtMealIndex >= 0)
        {
            _crtMealIndex -= 1;
            _txtReciepe.Text = _days[_crtDay].MealList[_crtMealIndex].Recipe;
            _lstIngredients.ItemsSource = _days[_crtDay].MealList[_crtMealIndex].Ingredients;
            _txtMeal.Text= _days[_crtDay].MealList[_crtMealIndex].Name;
        }
        }
        catch(Exception ex)
        {
            await DisplayAlertAsync("Smart Calories", $"Unexpected error in the reciepe book.", "ok");
        }
    }

    private async void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        try
        {
        _crtDate = (DateTime)_pckDay.Date;
        searchPlan(_crtDate);
        _txtReciepe.Text = _days[_crtDay].MealList[_crtMealIndex].Recipe;
        _lstIngredients.ItemsSource = _days[_crtDay].MealList[_crtMealIndex].Ingredients;
        _lstWorkOut.Text = _days[_crtDay].WorkoutList[0].ToString();
        }
        catch(Exception ex)
        {
            await DisplayAlertAsync("Smart Calories", $"Please select a date with a plan", "ok");
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