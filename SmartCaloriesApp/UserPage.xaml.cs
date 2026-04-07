using SmartCaloriesLibrary;

namespace SmartCaloriesApp;

public partial class UserInfo_1 : ContentPage
{
	public UserInfo_1()
	{

		InitializeComponent();
        List<int> ageList = Enumerable.Range(1, 100).ToList();
        _pkrAge.ItemsSource = ageList;
    }

    private void OnSubmit(object sender, EventArgs e)
    {
        string name = _txtName.Text;
        string gender = "";
        if(_radioMale.IsChecked)
        {
            gender = "Male";
        }
        else
        {
            gender = "Female";
        }
        int age = (int)_pkrAge.SelectedItem;
        double crtWeight = double.Parse(_txtCrtWeight.Text);
        double trgtWeight = double.Parse(_txtTargetWeight.Text);
        double height = double.Parse(_txtHeight.Text);
        string progress = _pkrProgress.SelectedItem.ToString();
        bool willWorkout = false;
        if (_radioYes.IsChecked)
        {
            willWorkout = true;
        }
        else
        {
            willWorkout = false;
        }

        User user = new User(name,crtWeight,trgtWeight,height,age,gender,progress,willWorkout);

    }
}