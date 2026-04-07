namespace SmartCaloriesLibrary;


/// <summary>
/// author : Hossam Abdelaziz(Sam)
///
/// data tier class will be responable for loading data from the recipes.json workout.json
/// stores all loaded meals and workouts in dictionaries so it can be searched easy by the name 
/// </summary>
public class RecipeBook
{
    #region Feild Variables

    private Dictionary<string, Meal> _meals;
    private Dictionary<string, Workout> _workouts;
    
    #endregion

    #region Constructors

    public RecipeBook(Dictionary<string, Meal> meals, Dictionary<string, Workout> workouts)
    {
        _meals = new Dictionary<string, Meal>();
        _workouts = new Dictionary<string, Workout>();
    }
    
    #endregion
}