using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCaloriesLibrary;

public class User
{
    #region Field Variables
    private string _name;
    private double _crtWeight;
    private double _trgtWeight;
    private double _height;
    private int _age;
    private string _gender;
    private int _activity;
    private int _days;
    #endregion
    #region Constructor
    public User(string name, double crtWeight, double trgtWeight, double height, int age, string gender, int activity, int days)
    {
        _name = name;
        _crtWeight = crtWeight;
        _trgtWeight = trgtWeight;
        _height = height;
        _age = age;
        _gender = gender;
        _activity = activity;
        _days = days;
    }
    #endregion
    #region Methods
    public double CalcDailyCalories()
    {
        double dailyCalories = 0;
        double totalDailyEnergy = 0;
        double basalMetabolicRate = (10 * _crtWeight) + (6.25 * _height) - (5 * _age);
        if(_gender == "Male")
        {
            basalMetabolicRate = basalMetabolicRate + 5;
        }
        else
        {
            basalMetabolicRate = basalMetabolicRate - 161;
        }
        switch (_activity)
        {
            case 0:
                totalDailyEnergy = basalMetabolicRate * 1.2;
                break;
            case 1:
                totalDailyEnergy = basalMetabolicRate * 1.375;
                break;
            case 2:
                totalDailyEnergy = basalMetabolicRate * 1.55;
                break;
            case 3:
                totalDailyEnergy = basalMetabolicRate * 1.725;
                break;
            case 4:
                totalDailyEnergy = basalMetabolicRate * 1.9;
                break;
            default:
                throw new Exception("Something wrong with your activity");
        }

        double totalCalorieDiffrence = (_trgtWeight - _crtWeight) * 7700;
        double dailyAdjustement = totalCalorieDiffrence / _days;
        dailyCalories = totalDailyEnergy + dailyAdjustement;


        return dailyCalories;
    }
    #endregion
    #region Properties
    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public double CrtWeight
    {
        get
        {
            return _crtWeight;
        }

        set
        {
            _crtWeight = value;
        }
    }

    public double TrgtWeight
    {
        get
        {
            return _trgtWeight;
        }

        set
        {
            _trgtWeight = value;
        }
    }

    public double Height
    {
        get
        {
            return _height;
        }

        set
        {
            _height = value;
        }
    }

    public int Age
    {
        get
        {
            return _age;
        }

        set
        {
            _age = value;
        }
    }

    public string Gender
    {
        get
        {
            return _gender;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("The gender cant be empty");
            }
            _gender = value;
        }
    }

    public int Activity
    {
        get
        {
            return _activity;
        }

        set
        {
            _activity = value;
        }
    }

    public int Days
    {
        get
        {
            return _days;
        }

        set
        {
            _days = value;
        }
    }
    #endregion
}
