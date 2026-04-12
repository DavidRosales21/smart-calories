using SmartCaloriesLibrary;
using System.Collections.ObjectModel;
/// David
namespace SmartCaloriesApp;

public partial class ShoppingList : ContentPage
{
    #region fields
    private Planner _planner;
    private List<Day> _days;
    private ObservableCollection<String> _shoppingList;
    #endregion
    #region constructor
    public ShoppingList(Planner planner)
	{
		InitializeComponent();
        _planner = planner;
		_days = _planner.Days;
        _shoppingList = new ObservableCollection<String>();
        _lstShoppingList.ItemsSource = _shoppingList;

    }
    #endregion
    #region methods

    public void updateList(DateTime startDate, DateTime endDate)
    {
        //clear previous shopping list
        _shoppingList.Clear();
        //for each day between the selected dates 
        for(DateTime date = startDate; date <=endDate ;date=date.AddDays(1))
        {
            foreach(Day day in _days)
            {
                //check is the day has a meal plan 
                if (day.Date == date)
                {
                    //for each meal read the meal's ingredients
                    foreach(Meal meal in day.MealList)
                    {
                        foreach(Ingredient ingredient in meal.Ingredients)
                        {
                            Boolean isInList = _shoppingList.Contains(ingredient.Name);
                            if (isInList)
                            {
                                continue;
                            }
                            else
                            {
                                _shoppingList.Add(ingredient.Name);
                            }
                        }
                    }
                }
            }
        }
    }

    private void OnSearch(object sender, EventArgs e)
    {
        updateList((DateTime)_pckStartDate.Date,(DateTime)_pckEndDate.Date);
    }
    #endregion

}