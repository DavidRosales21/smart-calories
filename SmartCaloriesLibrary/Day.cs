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

        public Double TargetCalories
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
    }