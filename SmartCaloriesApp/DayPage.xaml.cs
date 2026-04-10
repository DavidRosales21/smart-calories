using System.Collections.ObjectModel;

namespace SmartCaloriesApp;

public partial class DayPage : ContentPage
{
    private Planner _planner;
    private ObservableCollection<DaySummary> _dayPlans;
    private int _crtMeal;

    public DayPage(Planner planner)
	{
        _planner = planner;
		InitializeComponent();
        _dayPlans = _planner.DayPlans;
        _crtMeal = 0;
        
	}

    private void OnNextReciepe(object sender, EventArgs e)
    {
        _crtMeal += 1;
        _lstIngredients.ItemsSource = _dayPlans[0].Meals;
    }
    private void OnPrevReciepe(object sender, EventArgs e)
    {

    }

}