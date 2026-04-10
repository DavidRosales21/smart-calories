using SmartCaloriesLibrary;
using System.Collections.ObjectModel;

namespace SmartCaloriesApp;

public partial class ShoppingList : ContentPage
{
    private List<Day> _days;
    private ObservableCollection<Ingredient> _shoppingList;
    public ShoppingList(Planner planner)
	{
		InitializeComponent();
		_days = planner.Days;

    }

    public void updateList(DateTime startDate, DateTime endDate)
    {
        for(DateTime date = startDate; date <=endDate ;date=date.AddDays(1))
        {
            _shoppingList = [];
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
        _lstShoppingList.ItemsSource = _shoppingList;
    }

    private void OnDateChanged (object sender, DateChangedEventArgs e)
    {
        updateList((DateTime)_pckStartDate.Date,(DateTime)_pckEndDate.Date);
    }
}