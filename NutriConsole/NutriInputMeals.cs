namespace NutriConsole
{
    public class NutriInputMeals
    {
        public string AskForProductName()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("Enter product name: ");
                string productName = Console.ReadLine();

                if (productName.Length > 0)
                {
                    Console.Clear();
                    return productName;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a product name.");
                    continue;
                }
            }
        }
        public double AskForProductCalories()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("Enter calories of the product per 100g: ");

                if (double.TryParse(Console.ReadLine(), out double calories))
                {
                    Console.Clear();
                    return calories;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter correct calories of the product.");
                    continue;
                }
            }
        }
        public double AskForProductProteins()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("Enter amount of proteins per 100g: ");

                if (double.TryParse(Console.ReadLine(), out double proteins))
                {
                    Console.Clear();
                    return proteins;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter correct amount of proteins.");
                    continue;
                }
            }
        }
        public double AskForProductGrams()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("How many g of the product have you eaten?: ");

                if (double.TryParse(Console.ReadLine(), out double grams))
                {
                    Console.Clear();
                    return grams;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter correct amount of g.");
                    continue;
                }
            }
        }
    }
}
