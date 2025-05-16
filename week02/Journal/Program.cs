class Program
{
    static void Main(string[] args)
    {
        //Initialize core components
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("********************************");

        //Main program loop
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            //Process user choice
            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    LoadJournal(journal);
                    break;
                case "4":
                    SaveJournal(journal);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Journal Program!");
    }

    // Displays the main menu options to the user
    static void DisplayMenu()
    {
        Console.WriteLine("\nPlease select one of the following choices:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Load the journal from a file");
        Console.WriteLine("4. Save the journal to a file");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice (1-5): ");
    }

    // Handles the creation of a new journal entry
    // The Journal object to add entries to
    // The PromptGenerator to get random prompts
    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("MM/dd/yyyy");

        Entry entry = new Entry(date, prompt, response);
        journal.AddEntry(entry);

        Console.WriteLine("Entry added successfully!");
    }

    // Handles saving the journal to a file
    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }

    // Handles loading the journal from a file
    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }
}