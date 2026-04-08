namespace SmartCaloriesLibrary;

/// <summary>
/// author:Hossam Abdelaziz(Sam)
/// represents a single workout activity
///
///  workout objects are loaded from workouts.json by the RecipeBook class
/// and stored inside a Day's workout list to subtract from daily calories.
/// </summary>
public class Workout
{
    #region Feild Variables

    private string _name;
    private int    _duration;
    private double _caloriesBurned;
    private string _description;
    private string _image;
    private string _category;

    #endregion
   
    #region Constructors

    public Workout(string name, int duration, double caloriesBurned,
        string description, string image, string category)  
    {
        _name = name;
        _duration = duration;
        _caloriesBurned = caloriesBurned;
        _description = description;
        _image = image;
        _category = category;
        
    }
    #endregion
    
    #region Properties
    
    public String Name
    {
        get {return _name;}
    }
    
    public double Duration
    {
        get {return _duration;}
    }

    public double CaloriesBurned
    {
        get {return _caloriesBurned;}
    }

    public string Description
    {
        get {return _description;}
    }

    public string Image
    {
        get {return _image;}
    }

    public string Category
    {
        get {return _category;}
    }

    #endregion


    #region Methods
    
    public override string ToString()
    {
        return $"{_name} - {_duration} min - {_caloriesBurned} cal burned";
    }
    #endregion

}