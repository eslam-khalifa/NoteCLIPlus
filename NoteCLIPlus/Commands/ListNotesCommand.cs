using NoteCLIPlus.Helpers;

namespace NoteCLIPlus.Commands
{
    public class ListNotesCommand : ICommand
    {
        const string NotesFilePath = "notes.txt";

        public void Execute()
        {
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
            Console.Write($"Choose a page number (default is 1): ");
            string? pageInput = Console.ReadLine();
            int pageNumber = 0;
            if (string.IsNullOrWhiteSpace(pageInput) || !int.TryParse(pageInput, out pageNumber) || pageNumber < 1)
            {
                Console.WriteLine($"Invalid input. Taking default page number = 1...");
                Thread.Sleep(1000);
            }
            PaginationOptions.PageNumber = (pageNumber != 0) ? pageNumber : 1;
            var startIndex = (PaginationOptions.PageNumber - 1) * PaginationOptions.PageSize;
            int lastIndex = (notes.Length - startIndex < PaginationOptions.PageSize)? notes.Length - 1 : startIndex + PaginationOptions.PageSize - 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Listing all notes in a page {PaginationOptions.PageNumber}");
            Console.WriteLine($"(Notes {startIndex + 1} to {lastIndex + 1}) of {notes.Length} notes");
            Console.WriteLine("-----------------------------");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = startIndex; i <= lastIndex; i++)
            {
                if (!string.IsNullOrWhiteSpace(notes[i]))
                {
                    Console.WriteLine($"({i + 1}) {notes[i]}");
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}