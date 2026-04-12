using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCaloriesLibrary;

/// <summary>
/// Author : Antesh Kumar Sharma
/// Represents the user class that saves all the data from the user page, saves it and does the daily calorie intake calculation
/// </summary>
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
    private double _calories;
    #endregion
    #region Constructor
    public User()
    {
        _name = "";
        _crtWeight = 0;
        _trgtWeight = 0;
        _height = 0;
        _age = 0;
        _gender = "";
        _activity = 0;
        _days = 0;
        _calories = 0;
    }
    #endregion
    #region Methods
    public void CalcDailyCalories()
    {
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
        _calories = totalDailyEnergy + dailyAdjustement;
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
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The name of the user cannot be empty.");
            }
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
                throw new ArgumentException("The gender of the user cannot be empty");
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

    public double Calories
    {
        get
        {
            return _calories;
        }

        set
        {
            _calories = value;
        }
    }
    #endregion
}
