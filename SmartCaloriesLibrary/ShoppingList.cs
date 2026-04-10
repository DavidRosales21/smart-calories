using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCaloriesLibrary;

internal class ShoppingList
{
    #region Field Variables
    private DateTime _startDate;
    private DateTime _endDate;
    private List<Ingredient> _ingredientList;
    #endregion

    #region Constructor
    public ShoppingList(DateTime startDate, DateTime endDate)
    {
        _startDate = startDate;
        _endDate = endDate;
        _ingredientList = new List<Ingredient>();
    }
    #endregion

    #region Methods
    
    #endregion

    #region Parameters
    public DateTime EndDate
    {
        get
        {
            return _endDate;
        }

        set
        {
            _endDate = value;
        }
    }

    public DateTime StartDate
    {
        get
        {
            return _startDate;
        }

        set
        {
            _startDate = value;
        }
    }
    #endregion
}
