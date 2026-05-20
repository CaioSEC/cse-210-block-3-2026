using System;

class Program
{
static void Main(string[] args)
        {
            Journal myJournal = new Journal();
            string choice = "";

            Console.WriteLine("Welcome to your Daily Journal Program!");

            while (choice != "5")
            {
                Console.WriteLine("\nPlease select one of the following choices:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Load the journal from a file");
                Console.WriteLine("4. Save the journal to a file");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");
                
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        myJournal.CreateEntry();
                        break;
                    case "2":
                        myJournal.DisplayAll();
                        break;
                    case "3":
                        Console.Write("Enter the filename to load (e.g., journal.txt): ");
                        string loadFile = Console.ReadLine();
                        myJournal.LoadFromFile(loadFile);
                        break;
                    case "4":
                        Console.Write("Enter the filename to save to (e.g., journal.txt): ");
                        string saveFile = Console.ReadLine();
                        myJournal.SaveToFile(saveFile);
                        break;
                    case "5":
                        Console.WriteLine("\nThank you for journaling today. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }
}