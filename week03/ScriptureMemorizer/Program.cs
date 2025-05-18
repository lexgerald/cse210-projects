using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a sample scripture
        Reference reference = new Reference("1 Nephi", 3, 7);
        Scripture scripture = new Scripture(reference, 
            "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");
        
        // Main program loop
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
            
            // Hide a few random words each time
            scripture.HideRandomWords(3);
        }
    }
}