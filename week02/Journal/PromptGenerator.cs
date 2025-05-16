public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What am I most grateful for today?",
        "What challenge did I face today and how did I handle it?",
        "What lesson did I learn today?",
        "What made me smile or laugh today?",
        "How did I take care of myself today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void AddPrompt(string newPrompt)
    {
        _prompts.Add(newPrompt);
    }
}