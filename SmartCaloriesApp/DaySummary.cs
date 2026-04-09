namespace SmartCaloriesApp;
/// <summary>
/// a viiew model class just will hold the data so the UI can easliy read it and show it in our collectionView on planner page 
/// </summary>
public class DaySummary
{
        public string Date { get; set; }
        public string Meals { get; set; }
        
        public string Workout { get; set; }
        public double CaloriesEaten { get; set; }
        public double CaloriesBurned { get; set; }
        public double NetCalories { get; set; }
        
        public string Status { get; set; }
}