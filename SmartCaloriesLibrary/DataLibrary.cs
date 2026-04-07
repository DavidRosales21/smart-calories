namespace SmartCaloriesLibrary;


/// <summary>
/// author : Hossam Abdelaziz(Sam)
///
/// data tier class will be responable for loading data from the recipes.json workout.json
/// stores all loaded meals and workouts in lists so they can be filtered by category or type
/// </summary>
public class DataLibrary
{
    #region Feild Variables

    private List<Meal> _meals;
    private List<Workout> _workouts;
    
    #endregion

    #region Constructors

    public DataLibrary()
    {
        _meals = new List<Meal>();
        _workouts = new List<Workout>();
    }
    
    #endregion

    #region properties

    public List<Meal> Meals
    {
        get { return _meals; }
    }

    public List<Workout> Workouts
    {
        get { return _workouts; }
    }

    #endregion

}