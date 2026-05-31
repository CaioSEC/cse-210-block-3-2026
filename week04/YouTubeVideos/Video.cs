using System;
using System.Collections.Generic;

namespace YouTubeTracking
{
    public class Video
    {
        // Responsibility: Track video details
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        
        // Responsibility: Store a list of comments
        public List<Comment> Comments { get; set; }

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            Comments = new List<Comment>(); // Initialize the list to avoid null reference errors
        }

        // Responsibility: Return the total number of comments
        public int GetCommentCount()
        {
            return Comments.Count;
        }
    }
}