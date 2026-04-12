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
    private List<Day> _days;
    private int _crtMealIndex;
    private DateTime _crtDate;
    private int _crtDay;
    #endregion

    #region constructor
    
    public DayPage()
    {
        InitializeComponent();
        _days = App.Days;
        _crtMealIndex = 0;
        _crtDate = DateTime.Today;
        _crtDay = 0;
    }
    #endregion 

    /// <summary>
    ///  OnNextReciepe and OnPrevReciepe allos the user to navigate between the diferent meals on the selected day
    /// </summary>
    ///
    ///
    
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _days = App.Days;
    } 
    
    
    private async void OnNextReciepe(object sender, EventArgs e)
    {
        try
        {
            _crtMealIndex = (_crtMealIndex + 1) % _days[_crtDay].MealList.Count;
            _txtMeal.Text = _days[_crtDay].MealList[_crtMealIndex].Name;
            _mealImage.Source = ImageSource.FromFile(_days[_crtDay].MealList[_crtMealIndex].MealImage);
            _txtReciepe.Text = _days[_crtDay].MealList[_crtMealIndex].Recipe;
            _lstIngredients.ItemsSource = _days[_crtDay].MealList[_crtMealIndex].Ingredients;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Smart Calories", "Unexpected error in the recipe book.", "OK");
        }
    }
    
    
    
    private async void OnPrevReciepe(object sender, EventArgs e)
    {
        try
        {
            _crtMealIndex = (_crtMealIndex - 1 + _days[_crtDay].MealList.Count) % _days[_crtDay].MealList.Count;
            _txtMeal.Text = _days[_crtDay].MealList[_crtMealIndex].Name;
            _mealImage.Source = ImageSource.FromFile(_days[_crtDay].MealList[_crtMealIndex].MealImage);
            _txtReciepe.Text = _days[_crtDay].MealList[_crtMealIndex].Recipe;
            _lstIngredients.ItemsSource = _days[_crtDay].MealList[_crtMealIndex].Ingredients;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Smart Calories", "Unexpected error in the recipe book.", "OK");
        }
    }
    
    
    

    private async void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine($"Total days in App.Days: {App.Days.Count}");

        try
        {
            _crtDate = _pckDay.Date.Value;
            searchPlan(_crtDate);
        
            _crtMealIndex = 0;
            _txtMeal.Text = _days[_crtDay].MealList[_crtMealIndex].Name;
            _mealImage.Source = ImageSource.FromFile(_days[_crtDay].MealList[_crtMealIndex].MealImage);
            _txtReciepe.Text = _days[_crtDay].MealList[_crtMealIndex].Recipe;
            _lstIngredients.ItemsSource = _days[_crtDay].MealList[_crtMealIndex].Ingredients;
        
            if (_days[_crtDay].WorkoutList.Count > 0)
            {
                _lstWorkOut.Text = _days[_crtDay].WorkoutList[0].ToString();
                _workOutImage.Source = ImageSource.FromFile(_days[_crtDay].WorkoutList[0].Image);
            }
            else
            {
                _lstWorkOut.Text = "No workout planned for this day.";
                _workOutImage.Source = null;
            }
        }
        catch(Exception ex)
        {
            await DisplayAlert("Smart Calories", "Please select a date with a plan", "OK");
        }
    }

    private void searchPlan(DateTime date)
    {
        for (int dayIndex = 0; dayIndex < _days.Count; dayIndex++)
        {
            if (_days[dayIndex].Date.Date == date.Date)
            {
                _crtDay = dayIndex;
                break;
            }
        }
    }

    private  async void OnLoadPlan(object? sender, EventArgs e)
    {
        
            _crtDate = _pckDay.Date.Value;
            System.Diagnostics.Debug.WriteLine($"Total days: {App.Days.Count}");
            searchPlan(_crtDate);
    
            if (_days.Count == 0)
            {
                await DisplayAlert("No Plan", "No plan found for this date.", "OK");
                return;
            }
    
            _crtMealIndex = 0;
            _mealImage.Source = ImageSource.FromFile(_days[_crtDay].MealList[_crtMealIndex].MealImage);


            _txtMeal.Text = _days[_crtDay].MealList[_crtMealIndex].Name;
            _txtReciepe.Text = _days[_crtDay].MealList[_crtMealIndex].Recipe;
            _lstIngredients.ItemsSource = _days[_crtDay].MealList[_crtMealIndex].Ingredients;
    
            if (_days[_crtDay].WorkoutList.Count > 0)
            {
                _lstWorkOut.Text = _days[_crtDay].WorkoutList[0].ToString();
                _workOutImage.Source = ImageSource.FromFile(_days[_crtDay].WorkoutList[0].Image);
            }
            else
            {
                _lstWorkOut.Text = "No workout planned.";
                _workOutImage.Source = null;
            }
        }    
}