namespace SmartCaloriesLibrary;
using System.Text.Json;


/// <summary>
/// author : Hossam Abdelaziz(Sam)
///
/// data tier class will be responable for loading data from the recipes.json workout.json
/// stores all loaded meals and workouts in lists so they can be filtered by category or type
/// </summary>
///


// helper class to read the json file 
internal class MealsWrapper
{
    public List<Meal> meals { get; set; }
}

internal class WorkoutsWrapper
{
    public List<Workout> workouts { get; set; }
}

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
    #region Methods

    public async Task LoadMeals(Stream stream)
    {
        MealsWrapper mealsWrapper = await JsonSerializer.DeserializeAsync<MealsWrapper>(stream);
        
        _meals = mealsWrapper.meals;
    }

    public async Task LoadWorkouts(Stream stream)
    {
        
        
        WorkoutsWrapper workoutsWrapper = await JsonSerializer.DeserializeAsync<WorkoutsWrapper>(stream);
        
        _workouts = workoutsWrapper.workouts;
    }


    public List<Meal> GetMealsByType(string mealType)
    {
        List<Meal> result = new List<Meal>();

        foreach (Meal meal in _meals)
        {
            if (meal.MealType == mealType)
            {
                result.Add(meal);   
            }
        }
        return result;
    }

    public List<Workout> GetWorkoutsByCategory(string category)
    {

        List<Workout> result = new List<Workout>();

        foreach (Workout workout in _workouts)
        {
            if (workout.Category == category)
            {
                result.Add(workout);
            }
        }
        return result;
    }

    public List<Meal> SearchMeals(string query)
    {
        List<Meal> results = new List<Meal>();
        foreach (Meal meal in _meals)
        {
            if (meal.Name.Contains(query))
            {
                results.Add(meal);
            }
        }
        return results;
    }

    public List<Workout> SearchWorkouts(string query)
    {
        List<Workout> results = new List<Workout>();
        
        foreach (Workout workout in _workouts){
            if (workout.Name.Contains(query))
            {
                results.Add(workout);
            }
        }
        return results;
    }
    #endregion
    

}