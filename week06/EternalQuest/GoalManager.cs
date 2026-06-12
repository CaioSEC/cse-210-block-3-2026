using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            DisplayPlayerInfo();
            
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordGoalEvent(); break;
                case "6": quit = true; break;
                default: Console.WriteLine("Invalid option. Press Enter to retry."); Console.ReadLine(); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\n=== Current Score: {_score} ===");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("(No goals created yet)");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int.TryParse(Console.ReadLine(), out int points);

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int.TryParse(Console.ReadLine(), out int target);
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int.TryParse(Console.ReadLine(), out int bonus);
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type creation cancelled.");
                break;
        }
    }

    public void RecordGoalEvent()
    {
        ListGoalDetails();
        if (_goals.Count == 0) return;

        Console.Write("\nWhich goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _goals.Count)
        {
            Goal selectedGoal = _goals[choice - 1];
            int pointsEarned = selectedGoal.RecordEvent();
            _score += pointsEarned;

            if (pointsEarned > 0)
            {
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals successfully saved!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear(); // Clear current goals before loading new ones
        string[] lines = File.ReadAllLines(filename);
        
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');
            string goalType = parts[0];
            string[] data = parts[1].Split(',');

            if (goalType == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
            }
            else if (goalType == "EternalGoal")
            {
                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            }
            else if (goalType == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
            }
        }
        Console.WriteLine("Goals successfully loaded!");
    }
}