using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCaloriesLibrary;

public class ExtremeWeightLossException:Exception
{
    public ExtremeWeightLossException(string message) : base( message)
    {

    }
}
