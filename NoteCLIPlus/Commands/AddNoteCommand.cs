
namespace NoteCLIPlus.Commands
{
    public class AddNoteCommand : ICommand
    {
        const string NotesFilePath = "notes.txt";

        public void Execute()
        {
            Console.Write("Enter your note: ");
            string? note = Console.ReadLine();
            while (!IsValidNote(note))
            {
                Console.Write("Invalid note! Please enter a valid note: ");
                note = Console.ReadLine();
            }
            note = PreprocessingNote(ref note!);
            Console.WriteLine($"Adding note...");
            Thread.Sleep(1000);
            File.AppendAllText($"{NotesFilePath}", $"{note}\n");
            Console.WriteLine("Note added successfully!");
        }

        private bool IsValidNote(string? note)
        {
            if (string.IsNullOrWhiteSpace(note)) return false;
            return true;
        }

        private string PreprocessingNote(ref string note) => note.Trim();
    }
}