namespace NutriConsole
{
    public class NutriInputUserData
    {
        public bool AskForGender()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Are you male or female?: ");

                string userGender = Console.ReadLine().ToLower();

                if (userGender == "male")
                {
                    return true;
                }
                else if (userGender == "female")
                {
                    return false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a correct option.");
                    continue;
                }
            }
        }
        public int AskForAge()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("Enter your age: ");

                if (int.TryParse(Console.ReadLine(), out int userAge))
                {
                    Console.Clear();
                    return userAge;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter correct age.");
                    continue;
                }
            }
        }
        public double AskForHeight()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("Enter your height (in cm): ");

                if (double.TryParse(Console.ReadLine(), out double userHeight))
                {
                    Console.Clear();
                    return userHeight;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter correct height.");
                    continue;
                }
            }
        }
        public double AskForWeight()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("Enter your weight (in kg): ");

                if (double.TryParse(Console.ReadLine(), out double userWeight))
                {
                    Console.Clear();
                    return userWeight;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter correct weight.");
                    continue;
                }
            }
        }
        public double AskForActivityLevel()
        {
            while (true)
            {

                Console.WriteLine("What is your activity level?");
                Console.WriteLine("1. None");
                Console.WriteLine("2. 1-3x workouts per week");
                Console.WriteLine("3. 3-5x workouts per week");
                Console.WriteLine("4. 6-7x workouts per week");

                Console.WriteLine();

                Console.Write("Enter your choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            return 1.2;
                        }
                    case "2":
                        {
                            return 1.375;
                        }
                    case "3":
                        {
                            return 1.55;
                        }
                    case "4":
                        {
                            return 1.725;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Please select a correct option.");
                            break;
                        }
                }
            }
        }
        public string AskForName()
        {
            while (true)
            {
                Console.Write("What is your name?: ");
                var name = Console.ReadLine();

                if (name.Length > 0)
                {
                    return name;
                }
                else
                {
                    Console.Clear();
                    continue;
                }
            }
        }
        public double AskForTargetCalories()
        {
            Console.Clear();
            while (true)
            {

                Console.WriteLine("What is your goal?");
                Console.WriteLine("1. I want to lose weight");
                Console.WriteLine("2. I want to bulk");
                Console.WriteLine("3. i want to maintain my weight");

                Console.WriteLine();

                Console.Write("Enter your choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            return 0.8;
                        }
                    case "2":
                        {
                            return 1.1;
                        }
                    case "3":
                        {
                            return 1;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Please select a correct option.");
                            break;
                        }
                }
            }
        }
    }
}
