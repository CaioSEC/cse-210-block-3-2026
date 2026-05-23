using System;

class Program
{
    static void Main(string[] args)
        {
            Reference reference = new Reference("Ether", 12, 27);
            string text = "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them.";
            
            Scripture scripture = new Scripture(reference, text);
            

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();

                if (scripture.IsCompletelyHidden())
                {
                    break;
                }

                Console.WriteLine("Press enter to continue or type 'quit' to finish:");
                string input = Console.ReadLine();

                if (input.Trim().ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords(3);
            }
        }
    }

    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public string GetDisplayText()
        {
            if (_isHidden)
            {
                return new string('_', _text.Length);
            }
            return _text;
        }
    }

    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verse;
        private int? _endVerse; 
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _endVerse = null;
        }

        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _verse = startVerse;
            _endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            if (_endVerse == null)
            {
                return $"{_book} {_chapter}:{_verse}";
            }
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }

    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            string[] textWords = text.Split(' ');
            foreach (string word in textWords)
            {
                _words.Add(new Word(word));
            }
        }

        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();
            int hiddenCount = 0;

            while (hiddenCount < numberToHide && !IsCompletelyHidden())
            {
                int randomIndex = random.Next(_words.Count);
                
                if (!_words[randomIndex].IsHidden())
                {
                    _words[randomIndex].Hide();
                    hiddenCount++;
                }
            }
        }

        public string GetDisplayText()
        {
            List<string> displayedWords = new List<string>();
            foreach (Word word in _words)
            {
                displayedWords.Add(word.GetDisplayText());
            }

            return $"{_reference.GetDisplayText()} {string.Join(" ", displayedWords)}";
        }

        public bool IsCompletelyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
            return true;
        }
}