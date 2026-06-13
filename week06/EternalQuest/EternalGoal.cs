public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    { }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override bool IsComplete() => false; 

    public override string GetDetailsString()
    {
        return $"[ ] {GetShortName()} ({GetDescription()}) - (Eternal Goal)";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{GetShortName()},{GetDescription()},{GetPoints()}";
    }
}