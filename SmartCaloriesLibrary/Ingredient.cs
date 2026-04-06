using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCaloriesLibrary
{
    /// <summary>
    /// the ingredient class represents all the necesary information of an ingredient to be used in a meal
    /// </summary>
    internal class Ingredient
    {
        #region fields
        private string _image;
        private string _name;

        #endregion

        #region constructor
        /// <summary>
        /// The Ingredient constructor creates an ingredient object.
        ///
        /// </summary>
        /// <param name="image"> the image paramether represent the source file location of the igredient image</param>
        /// <param name="name">  the name paramether represent the name or decription of the ingredient </param>
        public Ingredient(string image, string name)
        {
            _image = image;
            _name = name;
        }
        #endregion

        #region properties
        public string Image
        {
            get { return _image; }
        }
        public string Name
        {
            get { return _name; }
        }
        #endregion
    }
}
