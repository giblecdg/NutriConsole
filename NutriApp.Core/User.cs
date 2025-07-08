namespace NutriApp.Core
{
    public class User
    {
        public string name { get; set; }
        public bool isMale { get; set; }
        public int age { get; set; }
        public double weight { get; set; }
        public double height { get; set; }
        public double activityLevel { get; set; }
        public double targetCalories { get; set; }

        public User() { }
        public User(string name, bool isMale, int age, double weight, double height, double activityLevel, double targetCalories)
        {
            this.name = name;
            this.isMale = isMale;
            this.age = age;
            this.weight = weight;
            this.height = height;
            this.activityLevel = activityLevel;
            this.targetCalories = targetCalories;
        }
    }
}
