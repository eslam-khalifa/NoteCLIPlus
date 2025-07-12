
namespace NoteCLIPlus.Commands
{
    public class SearchNoteCommand : ICommand
    {
        const string NotesFilePath = "notes.txt";

        public void Execute()
        {
            Console.Write("Enter the keyword to search for: ");
            string? keyword = Console.ReadLine();
            while (!IsValidKeyword(keyword))
            {
                Console.Write("Invalid keyword! Please enter a valid keyword: ");
                keyword = Console.ReadLine();
            }
            if (!File.Exists($"{NotesFilePath}"))
            {
                Console.WriteLine("No notes found. Please add a note first.");
                return;
            }
            string[] notes = File.ReadAllLines($"{NotesFilePath}");
            if (notes.Length == 0)
            {
                Console.WriteLine("No notes found. Please add a note first.");
                return;
            }
            Console.WriteLine($"Searching for notes containing '{keyword}'...");
            Thread.Sleep(1000);
            bool found = false;
            for (int i = 0; i < notes.Length; i++)
            {
                if (notes[i].Contains(keyword!))
                {
                    Console.WriteLine($"({i + 1}) {notes[i]}");
                    found = true;
                }
            }
            Console.WriteLine(found ? "Search completed." : "No notes found containing the specified keyword.");
        }

        private bool IsValidKeyword(string? keyword) => string.IsNullOrWhiteSpace(keyword)? false : true;
    }
}