using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCaloriesLibrary
{
    /// <summary>
    /// The meal class represents a set of ingredients and instructions for cooking a meal, 
    /// it also contains the nutritional information of the
    /// </summary>
    internal class Meal
    {
        private string _name;
        private double _calories;
        private string _mealImage;
        private string _reciepe;
        private List<Ingredient> _ingredientList;

        public Meal(string name,double calories, string image, string reciepe, List<Ingredient> ingredients)
        {
            _name = name;
            _calories = calories;
            _mealImage = image;
            _reciepe = reciepe;
            _ingredientList = ingredients;

        }

        public List<Ingredient> Ingredients
        {
            get { return _ingredientList; }
        }
        public string Name
        {
            get { return _name; }
        }
        public string Image
        {
            get { return _mealImage; }
        }
        public string Reciepe
        {
            get { return _reciepe; }
        }
    }
}
