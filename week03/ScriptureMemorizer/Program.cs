class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish.");
            
            string input = Console.ReadLine();
            if (input.ToLower() == "quit" || scripture.IsCompletelyHidden())
            {
                break;
            }
            
            scripture.HideRandomWords(3); // Hide 3 words at a time
        }
    }
}