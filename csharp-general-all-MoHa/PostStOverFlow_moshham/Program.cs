

using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace testApp3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==Post==");
            var p = new Post();
            p.Title = "Test";
            p.Description = "Test description";
            //p.DateOfCreation = DateTime.Now;
            Console.WriteLine($"title: {p.Title}");
            Console.WriteLine($"description: {p.Description}");
            Console.WriteLine($"created at: {p.DateOfCreation.ToString("HH:mm:ss")}");
            p.UpVote();
            p.UpVote();
            p.UpVote();
            p.DownVote();
            var votes1 = p.GetNumberOfVotes().ToString();
            Console.WriteLine($"votes: {votes1}");
        }
    }

    public class Post
    {
        public string Title;
        public string Description;
        private int _votes;
        public DateTime DateOfCreation;

        public Post()
        {
            _votes = 0;
            DateOfCreation = DateTime.Now;
        }

        public void UpVote()
        {
            _votes++;
        }

        public void DownVote()
        {
            _votes--;
        }

        public int GetNumberOfVotes()
        {
            return _votes;
        }

    }
}