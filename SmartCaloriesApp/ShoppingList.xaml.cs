using SmartCaloriesLibrary;
using System.Collections.ObjectModel;
/// David
namespace SmartCaloriesApp;

public partial class ShoppingList : ContentPage
{
    private Planner _planner;
    private List<Day> _days;
    private ObservableCollection<Ingredient> _shoppingList;
    public ShoppingList(Planner planner)
	{
		InitializeComponent();
        _planner = planner;
		_days = _planner.Days;
        _shoppingList = new ObservableCollection<Ingredient>();
        _lstShoppingList.ItemsSource = _shoppingList;

    }

    public void updateList(DateTime startDate, DateTime endDate)
    {
        for(DateTime date = startDate; date <=endDate ;date=date.AddDays(1))
        {
            foreach(Day day in _days)
            {
                if (day.Date == date)
                {
                    foreach(Meal meal in day.MealList)
                    {
                        foreach(Ingredient ingredient in meal.Ingredients)
                        {
                            Boolean isInList = _shoppingList.Contains(ingredient);
                            if (isInList)
                            {
                                continue;
                            }
                            else
                            {
                                _shoppingList.Add(ingredient);
                            }
                        }
                    }
                }
            }
        }
    }

    private void OnDateChanged (object sender, DateChangedEventArgs e)
    {
        updateList((DateTime)_pckStartDate.Date,(DateTime)_pckEndDate.Date);
    }
}