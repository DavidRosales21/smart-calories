using Microsoft.Extensions.DependencyInjection;
using SmartCaloriesLibrary;
namespace SmartCaloriesApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        
        LoadDataAsync();

    }
    
    public static DataLibrary Library { get; private set; } = new DataLibrary();
    
    private static List<Day> _days = new List<Day>();

    
    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(new WelcomePage()));    }

    private async void LoadDataAsync()
    {
        using Stream mealsStream = await FileSystem.OpenAppPackageFileAsync("recipes.json");
        await Library.LoadMeals(mealsStream);

        using Stream workoutsStream = await FileSystem.OpenAppPackageFileAsync("workouts.json");
        await Library.LoadWorkouts(workoutsStream);
    }
    
    public static List<Day> Days
    {
        get { return _days; }
    }
    
}