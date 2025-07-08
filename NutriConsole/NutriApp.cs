using NutriApp.Core;
namespace NutriConsole
{
    class NutriApp
    {
        NutriInputUserData NutriInputUserData = new NutriInputUserData();
        NutriInputMeals NutriInputMeals = new NutriInputMeals();
        NutriManager NutriManager = new NutriManager();
        public void ShowMenu()
        {
            loadUserData();
            NutriManager.ClearMealsIfNewDay();
            NutriManager.LoadMealsDataFromFile();
            while (true)
                {
                    Console.WriteLine("-------------");
                    Console.WriteLine("Nutri Console");
                    Console.WriteLine("-------------");

                    Console.WriteLine();

                    Console.WriteLine("1. Edit user data");
                    Console.WriteLine("2. Display nutrition goals.");
                    Console.WriteLine("3. Add meal");
                    Console.WriteLine("4. Remove meal");
                    Console.WriteLine("5. Save and exit");

                    Console.WriteLine();

                    Console.Write("Enter your choice: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            EnterUserData();
                            break;
                        case "2":
                            DisplayNutritionGoals();
                            break;
                        case "3":
                            AddMeal();
                            break;
                        case "4":
                            RemoveMeal();
                            break;
                        case "5":
                            SaveToFile();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please enter a correct option.");
                            break;
                    }
                }
        }
        private void EnterUserData()
        {
            string name;
            bool isMale;
            int age;
            double weight;
            double height;
            double activityLevel;
            double targetCalories;

            name = NutriInputUserData.AskForName();
            isMale = NutriInputUserData.AskForGender();
            age = NutriInputUserData.AskForAge();
            weight = NutriInputUserData.AskForWeight();
            height = NutriInputUserData.AskForHeight();
            activityLevel = NutriInputUserData.AskForActivityLevel();
            targetCalories = NutriInputUserData.AskForTargetCalories();


            NutriManager.appUser = NutriManager.AddUser(name, isMale, age, weight, height, activityLevel, targetCalories);

            Console.Clear();
            Console.WriteLine($"User data edited successfully!");
        }

        private void DisplayNutritionGoals()
        {
            if (NutriManager.appUser != null)
            {
                int mealIndex = 1;
                Console.Clear();

                NutriManager.CalculateDailyProtein();
                NutriManager.CalculateBMR(NutriManager.appUser);

                Console.WriteLine($"Hi, {NutriManager.appUser.name}!");
                Console.WriteLine($"To reach your goal you need to eat {NutriManager.caloriesPerDay} kcal per day.");
                Console.WriteLine($"You should eat {NutriManager.proteinPerDay}g of protein per day.");
                Console.WriteLine();

                double caloriesEaten = NutriManager.CountTotalCalories();
                double proteinsEaten = NutriManager.CountTotalProteins();

                if (caloriesEaten > 0)
                {
                    if (proteinsEaten > 0) {
                    Console.WriteLine($"Goal for {DateTime.Now.ToString("dd-MM-yyyy")} (today):");
                    Console.WriteLine();
                    Console.WriteLine($"You still have {caloriesEaten} kcal to eat.");
                    Console.WriteLine($"You still have {proteinsEaten}g of protein to eat.");
                    }
                    else
                    {
                        Console.WriteLine($"Goal for {DateTime.Now.ToString("dd-MM-yyyy")} (today):");
                        Console.WriteLine();
                        Console.WriteLine($"You still have {caloriesEaten} kcal to eat.");
                        Console.WriteLine($"You don't have to eat more protein for today!");
                    }
                }
                else
                {
                    double totalCalories = 0;
                    double totalProteins = 0;

                    foreach (var meal in NutriManager.Meals)
                    {
                        totalCalories += meal.calories;
                        totalProteins += meal.proteins;
                    }

                    Console.WriteLine("You have completed your daily goal!");
                    Console.WriteLine($"You have eaten {totalCalories}kcal and {totalProteins}g of proteins.");
                }


            if (NutriManager.Meals.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Eaten meals: ");

                    foreach (Meal meal in NutriManager.Meals)
                    {
                        Console.WriteLine($"{mealIndex}. '{meal.name}', Proteins: {meal.proteins}g , {meal.calories}kcal");
                        mealIndex++;
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.Clear();
                return;
            }
        }
        private void AddMeal()
        {
            string productName;
            double calories;
            double proteins;
            double grams;   

            productName = NutriInputMeals.AskForProductName();
            calories = NutriInputMeals.AskForProductCalories();
            proteins = NutriInputMeals.AskForProductProteins();
            grams = NutriInputMeals.AskForProductGrams();

            calories = (calories * grams) / 100;
            proteins = (proteins * grams) / 100;

            NutriManager.AddMeal(productName, calories, proteins);

            Console.Clear();
            Console.WriteLine($"Added '{productName}' {calories}kcal {proteins}g of proteins, eaten {grams}g");
        }
        private void RemoveMeal()
        {
            int mealIndex = 1;

            Console.Clear();

            if (NutriManager.Meals.Count > 0) 
            {
                while (true)
                {
                    Console.WriteLine("Which product you want to remove?");

                    foreach (Meal meal in NutriManager.Meals)
                    {
                        Console.WriteLine($"{mealIndex}. '{meal.name}', Proteins: {meal.proteins}g, {meal.calories}kcal");
                        mealIndex++;
                    }

                    Console.WriteLine();
                    Console.Write("Enter your choice: ");

                    try
                    {
                        int mealToRemove = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine($"Removed '{NutriManager.Meals[mealToRemove - 1]}'.");
                        NutriManager.Meals.RemoveAt(mealToRemove - 1);
                        break;
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter an correct option.");
                        mealIndex = 1;
                        continue;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You don't have any meals to remove.");
                return;
            }
        }
        private void SaveToFile()
        {
            NutriManager.SaveUserDataToFile();
            NutriManager.SaveMealsDataToFile();
            Console.Clear();
        }

        private void loadUserData()
        {
            var fileInfo = new FileInfo("user.json");

            if (File.Exists("user.json"))
            {
                if (fileInfo.Length == 0)
                {
                    EnterUserData();
                }
                else
                {
                    NutriManager.appUser = NutriManager.LoadUserDataFromFile();

                    if (NutriManager.appUser == null)
                    {
                        EnterUserData();
                    }
                }
            }
            else
            {
                EnterUserData();
            }
        }
    }
}
