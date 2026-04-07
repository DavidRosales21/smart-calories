namespace SmartCaloriesApp;

public partial class UserInfo_1 : ContentPage
{
	public UserInfo_1()
	{

		InitializeComponent();
        List<int> ageList = Enumerable.Range(1, 100).ToList();
        _pkrAge.ItemsSource = ageList;
    }
}