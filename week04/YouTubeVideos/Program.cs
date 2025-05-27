using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Tutorial for Beginners", "Programming Master", 600);
        video1.AddComment(new Comment("JohnDoe", "Great tutorial!"));
        video1.AddComment(new Comment("JaneSmith", "Very helpful for my project."));
        video1.AddComment(new Comment("CodeNewbie", "Could you make one about classes?"));

        Video video2 = new Video("10 Cooking Hacks You Need to Know", "Chef Amanda", 450);
        video2.AddComment(new Comment("FoodLover", "Hack #3 changed my life!"));
        video2.AddComment(new Comment("HomeCook", "I tried them all, amazing tips!"));
        video2.AddComment(new Comment("GordonFan", "Where's the seasoning?"));
        video2.AddComment(new Comment("KitchenPro", "Simple but effective."));

        Video video3 = new Video("Morning Yoga Routine", "Yoga with Sarah", 1200);
        video3.AddComment(new Comment("YogaBeginner", "Perfect way to start my day"));
        video3.AddComment(new Comment("FitAndFab", "Love this routine!"));
        video3.AddComment(new Comment("MeditationGuru", "The breathing exercises are excellent"));

        Video video4 = new Video("Building a Birdhouse - DIY", "Handy Andy", 900);
        video4.AddComment(new Comment("Woodworker", "Clear instructions, thanks!"));
        video4.AddComment(new Comment("BirdWatcher", "My robins love it!"));
        video4.AddComment(new Comment("DIYEnthusiast", "What type of wood is best?"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Display video information and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine();
        }
    }
}