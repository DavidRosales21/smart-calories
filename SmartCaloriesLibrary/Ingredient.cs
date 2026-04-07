using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCaloriesLibrary
{
    /// <summary>
    /// the ingredient class represents all the necesary information of an ingredient to be used in a meal
    /// </summary>
    internal class Ingredient:FoodItem
    {
        #region fields
        private string _image;
        private string _quantity;
        #endregion

        #region constructor
        /// <summary>
        /// The Ingredient constructor creates an ingredient object.
        ///
        public Ingredient(string image, string quantity) : base()
        {
            _image = image;
            _quantity = quantity;
        }
        #endregion

        #region properties
        public string Image
        {
            get { return _image; }
        }
        public string Quantity
        {
            get { return _quantity; }
        }
        public override double Calories
        {
            get { return _calories; }
        }
        #endregion

        
    }
}
