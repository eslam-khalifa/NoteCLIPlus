namespace NoteCLIPlus.Commands
{
    public class RemoveNoteCommand : ICommand
    {
        const string NotesFilePath = "notes.txt";

        private bool IsValidNoteNumber(string? input, out int noteNumber)
        {
            noteNumber = (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out noteNumber) && noteNumber > 0) ? Convert.ToInt32(input) : 0;
            return noteNumber != 0;
        }

        public void Execute()
        {
            Console.Write("Enter the number of the note to remove: ");
            string? input = Console.ReadLine();
            int validNoteNumber = 0;
            while (!IsValidNoteNumber(input, out validNoteNumber))
            {
                Console.Write("Invalid input! Please enter a valid note number: ");
                input = Console.ReadLine();
            }
            if (!File.Exists($"{NotesFilePath}"))
            {
                Console.WriteLine("No notes found. Please add a note first.");
                return;
            }
            string[] notes = File.ReadAllLines($"{NotesFilePath}");
            if (notes.Length == 0 || validNoteNumber > notes.Length)
            {
                Console.WriteLine("No notes found or invalid note number. Please add a note first.");
                return;
            }
            Console.WriteLine($"Removing note number {validNoteNumber}...");
            Thread.Sleep(1000);
            var listNote = notes.ToList();
            listNote.RemoveAt(validNoteNumber - 1);
            notes = listNote.ToArray();
            File.WriteAllLines($"{NotesFilePath}", notes);
            Console.WriteLine("Note removed successfully!");
        }
    }
}