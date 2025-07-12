using NoteCLIPlus.Commands;

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
            Exit
        }

        public static string PreprocessingInput(string input) => input.ToLower().Trim(' ');

        public static bool IsValidInput(string? input)
        {
            if (input == null) return false;
            foreach (var command in Enum.GetValues(typeof(Commands)))
            {
                if (input == command?.ToString()?.ToLower()) return true;
            }
            return false;
        }

        public static void Main()
        {
            Console.WriteLine("Welcome to NoteCLIPlus!");
            while (true)
            {
                Console.Write("Please enter a command (add, list, search, remove, exit): ");
                string? input = Console.ReadLine();
                while (!IsValidInput(input))
                {
                    Console.Write("You Typed a wrong command! Enter a valid command (add, list, search, remove, exit): ");
                    input = Console.ReadLine();
                }
                input = PreprocessingInput(input!);
                switch (input)
                {
                    case "add":
                        var add = new AddNoteCommand();
                        add.Execute();
                        break;
                    case "list":
                        var list = new ListNotesCommand();
                        list.Execute();
                        break;
                    case "search":
                        var search = new SearchNoteCommand();
                        search.Execute();
                        break;
                    case "remove":
                        var remove = new RemoveNoteCommand();
                        remove.Execute();
                        break;
                    case "exit":
                        var exit = new ExitCommand();
                        exit.Execute();
                        return;
                }
            }
        }
    }
}