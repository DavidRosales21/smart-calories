namespace SmartCaloriesApp;

public partial class UserInfo_1 : ContentPage
{
	public UserInfo_1()
	{

		InitializeComponent();
        // 1. Generate a list of ages from 1 to 100
        List<int> ageList = Enumerable.Range(1, 100).ToList();
        List<double> weights = new List<double>();
        // Start at 0, end at 500, move by 0.1 each time
        for (double i = 0; i <= 500; i += 0.1)
        {
            // Math.Round prevents floating-point precision errors (like 70.000000001)
            weights.Add(Math.Round(i, 1));
        }

        _pkrCrtWeight.ItemsSource = weights;

        // 2. Assign the list to the Picker
        _pkrAge.ItemsSource = ageList;
    }
}