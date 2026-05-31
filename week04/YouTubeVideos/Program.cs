using System;
using System.Collections.Generic;

namespace YouTubeTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videoList = new List<Video>();

            Video video1 = new Video("C# Basics for Beginners", "CodeAcademy", 600);
            video1.Comments.Add(new Comment("Alice", "This cleared up so much confusion. Thanks!"));
            video1.Comments.Add(new Comment("Bob", "Great pacing, looking forward to the next part."));
            video1.Comments.Add(new Comment("Charlie", "Can you explain Interfaces next time?"));
            videoList.Add(video1);

            Video video2 = new Video("How to Design a Clean UI", "PixelPerfect", 450);
            video2.Comments.Add(new Comment("Dave", "Love the minimalist style shown here."));
            video2.Comments.Add(new Comment("Emma", "What color palette generator did you use?"));
            video2.Comments.Add(new Comment("Frank", "Bookmarked! Very helpful workflow tips."));
            videoList.Add(video2);

            Video video3 = new Video("Intro to Object-Oriented Programming", "DevConcepts", 900);
            video3.Comments.Add(new Comment("Grace", "Abstraction finally makes sense to me now."));
            video3.Comments.Add(new Comment("Hank", "The real-world analogies were perfect."));
            video3.Comments.Add(new Comment("Ivy", "Is there a GitHub repo for these class examples?"));
            video3.Comments.Add(new Comment("Jack", "Brilliant explanation of properties vs fields."));
            videoList.Add(video3);

            Console.WriteLine("==================================================");
            Console.WriteLine("          YOUTUBE PRODUCT AWARENESS REPORT        ");
            Console.WriteLine("==================================================\n");

            foreach (Video video in videoList)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");

                foreach (Comment comment in video.Comments)
                {
                    Console.WriteLine($"  - {comment.Name}: \"{comment.Text}\"");
                }

                Console.WriteLine("\n--------------------------------------------------\n");
            }
        }
    }
}