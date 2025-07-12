namespace NoteCLIPlus.Commands
{
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Exiting the application...");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}