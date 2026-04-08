    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace SmartCaloriesLibrary
    {
        /// <summary>
        /// The FoodItem class represents the base class for a meal or ingredient
        /// </summary>
        public abstract class FoodItem
        {
            #region fields
            protected string _name;
            protected double _calories;
            #endregion
            #region properties
            public string Name
            {
                get { return _name; }
            }
            public abstract double Calories
            {
                get;
            }
            #endregion
            #region methods
            public override string ToString()
            {
                return $"{this._name} [{this._calories} Calories]";
            }
            #endregion
        }
    }
