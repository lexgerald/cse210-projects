using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _totalPointsEarned;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _totalPointsEarned = 0;
    }

    public void Start()
    {
        LoadGoals();
        DisplayPlayerInfo();
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
        Console.WriteLine($"Total Points Earned: {_totalPointsEarned}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Goal Details:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The Types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is the short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Select goal to record: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            Goal selectedGoal = _goals[choice];
            selectedGoal.RecordEvent();
            int pointsEarned = selectedGoal.GetPoints();
            _score += pointsEarned;
            _totalPointsEarned += pointsEarned;
            
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
            
            if (selectedGoal is ChecklistGoal checklist && checklist.IsComplete())
            {
                Console.WriteLine($"Bonus achieved! You completed the checklist goal!");
            }
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_totalPointsEarned);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            
            if (lines.Length > 0)
            {
                _score = int.Parse(lines[0]);
                _totalPointsEarned = int.Parse(lines[1]);
                
                for (int i = 2; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split('|');
                    string type = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    switch (type)
                    {
                        case "SimpleGoal":
                            bool isComplete = bool.Parse(parts[4]);
                            _goals.Add(new SimpleGoal(name, description, points, isComplete));
                            break;
                        case "EternalGoal":
                            int timesCompleted = int.Parse(parts[4]);
                            _goals.Add(new EternalGoal(name, description, points, timesCompleted));
                            break;
                        case "ChecklistGoal":
                            int bonus = int.Parse(parts[4]);
                            int target = int.Parse(parts[5]);
                            int amountCompleted = int.Parse(parts[6]);
                            _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                            break;
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
    }
}