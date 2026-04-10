using SmartCaloriesLibrary;

namespace SmartCaloriesApp;

public partial class ShoppingList : ContentPage
{
    private List<Day> _days;
    public ShoppingList(Planner planner)
	{
		InitializeComponent();
		_days = planner.Days;
		_days[1].


    }
}