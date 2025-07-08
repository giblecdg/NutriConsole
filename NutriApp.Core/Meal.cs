namespace NutriApp.Core
{
    public class Meal
    {
        public string name { get; set; }
        public double calories {  get; set; }
        public double proteins { get; set; }

        public Meal(string name, double calories, double proteins)
        {
            this.name = name;
            this.calories = calories;
            this.proteins = proteins;
        }
        public override string ToString()
        {
            return this.name;
        }
    }
}
