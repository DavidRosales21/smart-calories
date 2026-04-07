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
    private string _progress;
    private bool _willWorkout;
    #endregion
    #region Constructor
    public User(string name, double crtWeight, double trgtWeight, double height, int age, string gender, string progress, bool willWorkout)
    {
        _name = name;
        _crtWeight = crtWeight;
        _trgtWeight = trgtWeight;
        _height = height;
        _age = age;
        _gender = gender;
        _progress = progress;
        _willWorkout = willWorkout;
    }
    #endregion
    #region Methods
    public double CalcDailyCalories()
    {
        double basalMetabolicRate = (10 * _crtWeight) + (6.25 * _height) - (5 * _age);
        if(_gender == "Male")
        {
            basalMetabolicRate = basalMetabolicRate + 5;
        }
        else
        {
            basalMetabolicRate = basalMetabolicRate - 161;
        }
        double dailyCalories = 0;
        if (_willWorkout == true)
        {
            dailyCalories = basalMetabolicRate * 1.725;
        }
        else
        {
            dailyCalories = basalMetabolicRate * 1.2;
        }
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

    public string Progress
    {
        get
        {
            return _progress;
        }

        set
        {
            _progress = value;
        }
    }

    public bool WillWorkout
    {
        get
        {
            return _willWorkout;
        }

        set
        {
            _willWorkout = value;
        }
    }
    #endregion
}
