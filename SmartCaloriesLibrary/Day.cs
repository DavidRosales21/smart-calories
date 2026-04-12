    namespace SmartCaloriesLibrary;

    /// <summary>
    /// Author : Hossam abdelaziz (Sam)
    ///
    /// it will represend the day the user will pick it  will show the meales and the workout for that day 
    /// </summary>
    public class Day
    {
        #region field Variables
        
        private DateTime _date;
        private List<Meal> _mealList;
        private List<Workout> _workoutList;
        private double _targetCalories;
        
        #endregion
        #region constructor
        public Day(DateTime date, double targetCalories)
        {
            _date = date;
            _targetCalories = targetCalories;
            _mealList = new List<Meal>();
            _workoutList = new List<Workout>();
            
        }
        #endregion
        
        #region properties

        public DateTime Date
        {
            get { return _date; }
        }

        public double TargetCalories
        {
            get { return _targetCalories; }
        }

        public List<Meal>  MealList
        {
            get
            {
                return _mealList;
            }
        }

        public List<Workout> WorkoutList
        {
            get
            {
                return _workoutList;
            }
        }
        #endregion
        
        #region methods

        public void AddMeal(Meal meal)
        {
            _mealList.Add(meal);
        }

        public void AddWorkout(Workout workout)
        {
            _workoutList.Add(workout);
        }
        
        // get the total calories eaten from the list and add it up 
        public  double GetCaloriesEaten()
        {
            double totalCaloriesEaten = 0;
            foreach (Meal meal in _mealList)
            {
                totalCaloriesEaten += meal.Calories;
            }
            return totalCaloriesEaten;
        }
        
        // get the total calories burned and add it up from the workout list
        public double GetCaloriesBurned()
        {
            try
            {
                double totalCaloriesBurned = 0;
                foreach (Workout workout in _workoutList)
                {
                    totalCaloriesBurned += workout.CaloriesBurned;
                }
                return totalCaloriesBurned;
            }
            catch
            {
                return 0;
            }
        }
        
        // calculate the net calories 
        public double GetNetCalories()
        {
             return GetCaloriesEaten()- GetCaloriesBurned();
        }
        
        //compaer net calories to target 

        public string GetCalorieStatus()    
        {
            if (GetNetCalories() < _targetCalories)
            {
                return "Under Goal";
            }
            else if (GetNetCalories() == _targetCalories)
            {
                return "On Goal";
            }
            else
            {
                
                return "Over Goal";
            }

        }
        #endregion
        
    }