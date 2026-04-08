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
        private string _mealType;

        public Meal(string name, string mealImage, string recipe, 
            List<Ingredient> ingredients, string mealType) : base()
        {
            _name = name;
            _mealImage = mealImage; 
            _reciepe = recipe;
            _ingredientList = ingredients;
            _mealType = mealType;
        }

        public override double Calories
        {
            get
            {
                double calories = 0;
                foreach(Ingredient ingredient in _ingredientList)
                {
                    calories += ingredient.Calories;
                }
                return calories;
            }
        }

        public List<Ingredient> Ingredients
        {
            get { return _ingredientList; }
        }
        public string MealImage
        {
            get { return _mealImage; }
        }
        public string Recipe
        {
            get { return _reciepe; }
        }

        public string MealType
        {
            get { return _mealType; }
        }

        public override string ToString()
        {
            return _name; 
        }
    }
}
