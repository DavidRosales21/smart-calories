using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCaloriesLibrary
{
    /// <summary>
    /// The meal class represents a set of ingredients and instructions for cooking a meal, 
    /// it also contains the nutritional information of the
    /// </summary>
    public class Meal:FoodItem
    {
        private string _mealImage;
        private string _reciepe;
        private List<Ingredient> _ingredientList;

        public Meal( string image, string reciepe, List<Ingredient> ingredients):base()
        {
            _mealImage = image;
            _reciepe = reciepe;
            _ingredientList = ingredients;

        }

        public override double Calories
        {
            get
            {
                double calories = 0;
                foreach(Ingredient ingredient in _ingredientList)
                {
                    calories =+ ingredient.Calories;
                }
                return calories;
            }
        }

        public List<Ingredient> Ingredients
        {
            get { return _ingredientList; }
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
