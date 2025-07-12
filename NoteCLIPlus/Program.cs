namespace NoteCLIPlus
{
    class Program
    {
        enum Commands
        {
            Add,
            List,
            Search,
            Remove,
            Weather,
            Exit
        }

        public static bool InputCheck(ref string? input)
        {
            if (input == null) return false;
            input = input.ToLower().Trim(' ');
            foreach (var command in Enum.GetValues(typeof(Commands)))
            {
                if (input == command?.ToString()?.ToLower()) return true;
            }
            return false;
        }

        public static void Main()
        {
            Console.WriteLine("Welcome to NoteCLIPlus!");
            Console.Write("Please enter a command (add, list, search, remove, weather, exit): ");
            string? input = Console.ReadLine();
            while (!InputCheck(ref input))
            {
                Console.Write("You Typed a wrong command! Enter a valid command (add, list, search, remove, weather, exit): ");
                input = Console.ReadLine();
            }
            switch (input)
            {
                case "add":
                    Console.WriteLine("Add command selected.");
                    break;
                case "list":
                    Console.WriteLine("List command selected.");
                    break;
                case "search":
                    Console.WriteLine("Search command selected.");
                    break;
                case "remove":
                    Console.WriteLine("Remove command selected.");
                    break;
                case "weather":
                    Console.WriteLine("Weather command selected.");
                    break;
                case "exit":
                    Console.WriteLine("Exiting the application...");
                    return;
            }
        }
    }
}