using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }
    public abstract string GetStringRepresentation();
    public virtual int GetPoints() => _points;
}

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points) 
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
    }
}

public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, string description, int points) 
        : base(name, description, points) 
    {
        _timesCompleted = 0;
    }

    public EternalGoal(string name, string description, int points, int timesCompleted)
        : base(name, description, points)
    {
        _timesCompleted = timesCompleted;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Completed times {_timesCompleted}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}|{_timesCompleted}";
    }
}

public class ChecklistGoal : Goal
{
    private int _bonus;
    private int _target;
    private int _amountCompleted;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base(name, description, points)
    {
        _bonus = bonus;
        _target = target;
        _amountCompleted = 0;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _bonus = bonus;
        _target = target;
        _amountCompleted = amountCompleted;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override int GetPoints()
    {
        return IsComplete() ? _points + _bonus : _points;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Completed times {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
    }
}