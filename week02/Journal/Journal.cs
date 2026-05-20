using System.Runtime.CompilerServices;

public class Journal
{
 private List<Entry> _entries = new List<Entry>();

        private List<string> _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        public void CreateEntry()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            string randomPrompt = _prompts[index];

            Console.WriteLine($"\nPrompt: {randomPrompt}");
            Console.Write("> ");
            string response = Console.ReadLine();

            string dateText = DateTime.Now.ToShortDateString();

            Entry newEntry = new Entry(dateText, randomPrompt, response);
            _entries.Add(newEntry);

            Console.WriteLine("Entry saved to current session!");
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("\nThe journal is currently empty.");
                return;
            }

            Console.WriteLine("\n--- Journal Entries ---");
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
            Console.WriteLine("-----------------------");
        }

        public void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    foreach (Entry entry in _entries)
                    {
                        outputFile.WriteLine(entry.ToFileString());
                    }
                }
                Console.WriteLine($"Journal successfully saved to {filename}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        public void LoadFromFile(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine("File not found. Please check the filename and try again.");
                    return;
                }

                _entries.Clear();

                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                    {
                    string[] parts = line.Split('|');

                    if (parts.Length == 3)
                    {
                        string date = parts[0];
                        string prompt = parts[1];
                        string response = parts[2];

                        Entry loadedEntry = new Entry(date, prompt, response);
                        _entries.Add(loadedEntry);
                    }
                }
                Console.WriteLine($"Journal successfully loaded from {filename}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }

}