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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Listing all notes: ");
            Console.WriteLine("---------------------");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < notes.Length; i++)
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