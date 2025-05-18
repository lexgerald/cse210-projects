public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
        InitializeLibrary();
    }

    private void InitializeLibrary()
    {
        // Add scriptures to your library
        _scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all things through Christ who strengthens me."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Psalm", 23, 1),
            "The Lord is my shepherd, I lack nothing."
        ));

        // Add more scriptures as needed
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}