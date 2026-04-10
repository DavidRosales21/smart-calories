using System.Collections.ObjectModel;

namespace SmartCaloriesApp;
using SmartCaloriesLibrary;

public partial class DayPage : ContentPage
{
    private Planner _planner;
    private List<Day> _days;
    private int _crtMealIndex;
    private DateTime _crtDate;

    public DayPage(Planner planner)
	{
        _planner = planner;
		InitializeComponent();
        _days = _planner.Days;
        _crtMealIndex = 0;
        _crtDate = (DateTime) _pckDay.Date;

	}

    private void OnNextReciepe(object sender, EventArgs e)
    {
    
    }
    private void OnPrevReciepe(object sender, EventArgs e)
    {

    }

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        _crtDate = (DateTime)_pckDay.Date;
        searchPlan(_crtDate);
    }

    private void searchPlan(DateTime date)
    {
        for (int dayIndex = 0; dayIndex<_days.Count; dayIndex++)
        foreach (Day day in _days)
        {
            if (day.Date == date)
            {
                 
            }
        }
    }
}