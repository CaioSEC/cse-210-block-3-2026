using System;

namespace YouTubeTracking
{
    public class Comment
    {
        // Responsibility: Track the commenter's name and the comment text
        public string Name { get; set; }
        public string Text { get; set; }

        // Constructor to easily initialize a comment
        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }
}