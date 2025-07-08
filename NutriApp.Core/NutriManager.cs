using System.Text.Json;
namespace NutriApp.Core
{
    public class NutriManager
    {
        public User appUser { get; set; }
        public double caloriesPerDay { get; set; }
        public double proteinPerDay {  get; set; }
        public double caloriesLeft { get; set; }
        public double proteinsLeft { get; set; }
        public List<Meal> Meals = new List<Meal>();
        public User AddUser(string name, bool isMale, int age, double weight, double height, double activityLevel, double targetCalories)
        {
            return new User(name, isMale, age, weight, height, activityLevel, targetCalories);
        }
        public User AddUser(User loadedUser)
        {
            return new User(loadedUser.name, loadedUser.isMale, loadedUser.age, loadedUser.weight, loadedUser.height, loadedUser.activityLevel, loadedUser.targetCalories);
        }
        public void AddMeal(string productName, double calories, double proteins)
        {
            Meals.Add(new Meal(productName, calories, proteins));
        }
        public double CountTotalCalories()
        {
            foreach (var meal in Meals)
            {
                caloriesPerDay -= meal.calories;
            }
            return caloriesPerDay;
        }
        public double CountTotalProteins()
        {
            foreach (var meal in Meals)
            {
                proteinPerDay -= meal.proteins;
            }
            return proteinPerDay;
        }
        public void CalculateBMR(User appUser)
        {
            if (appUser.isMale)
            {
                caloriesPerDay = Math.Round(((10 * (appUser.weight) + 6.25 * (appUser.height) - 5 * (appUser.age) + 5) * appUser.activityLevel) * appUser.targetCalories);
            } 
            else
            {
                caloriesPerDay = Math.Round(((10 * (appUser.weight) + 6.25 * (appUser.height) - 5 * (appUser.age) + 161) * appUser.activityLevel) * appUser.targetCalories);
            }
        }
        public void CalculateDailyProtein()
        {
            switch (appUser.targetCalories)
                {
                    case 0.8 or 1: 
                        {
                            proteinPerDay = Math.Round(appUser.weight* 2.0);
                            break;
                        }
                    case 1.1:
                        {
                            proteinPerDay = Math.Round(appUser.weight * 2.2);
                            break;
                        }
                }
        }
        public void SaveUserDataToFile()
        {
            string json = JsonSerializer.Serialize(appUser);
            File.WriteAllText("user.json", json);
        }
        public User LoadUserDataFromFile()
        {
            if (File.Exists("user.json"))
            {   
                try 
                { 
                string json = File.ReadAllText("user.json");
                User loadedUser = AddUser(JsonSerializer.Deserialize<User>(json));

                return loadedUser;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public void SaveMealsDataToFile()
        {
            string json = JsonSerializer.Serialize(Meals);
            File.WriteAllText("meals.json", json);
        }
        public void LoadMealsDataFromFile()
        {
            if (File.Exists("meals.json"))
            {
                FileInfo fileInfo = new FileInfo("meals.json");

                if (fileInfo.Length == 0)
                {
                    return;
                }
                
                try
                {
                    string json = File.ReadAllText("meals.json");
                    Meals = JsonSerializer.Deserialize<List<Meal>>(json);
                }
                catch
                {
                    return;
                }
            }
        }
        public void ClearMealsIfNewDay()
        {
            string dateFile = "last_used.txt";
            string mealsFile = "meals.json";
            string today = DateTime.Now.ToShortDateString();

            if (!File.Exists(dateFile))
            {
                File.WriteAllText(dateFile, today);
                return;
            }

            string lastUsed = File.ReadAllText(dateFile);

            if (lastUsed != today)
            {
                File.WriteAllText(mealsFile, "[]");
                File.WriteAllText(dateFile, today);
            }
        }
    }
}
