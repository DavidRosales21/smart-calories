using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCaloriesLibrary;
/// <summary>
/// Author : Antesh Kumar Sharma
/// Custom Exception class for User Page when the daily calculated calories are less then 700. Derives from the base Exception class
/// </summary>
public class ExtremeWeightLossException:Exception
{
    public ExtremeWeightLossException(string message) : base( message)
    {

    }
}
