namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new string[] { "1", "2", "3", "4", "5" };
            var numbers2 = new List<int>() { 6, 7, 8, 9, 10 };
            DisplayList(numbers);
            DisplayList(numbers2);

            Movie myMovie = new Movie { Name = "Movie", Year = 1986 };
            Book myBook = new Book { Name = "Book", Year = 1996 };

            myMovie.Show();
            myBook.Show();

            var myClasses = new List<IMedia> { 
                new Movie { Name = "Movie", Year = 1986 },
                new Book { Name = "Book", Year = 1996 }
            };
            myClasses.ShowList();
        }
        public static void DisplayList<T>(IEnumerable<T> numbers)
        {
            foreach(var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }

    public interface IMedia
    {
        string Name { get; set; }
        int Year { get; set; }
    }

    class Movie : IMedia
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }

    class Book : IMedia
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }

    public static class MediaExtensions
    {
        public static void Show(this IMedia media)
        {
            Console.WriteLine($"{media.Name} | {media.Year}");
        }

        public static void ShowList(this IEnumerable<IMedia> media)
        {
            foreach(IMedia item in media)
            {
                Console.WriteLine(item.Name + " " + item.Year);
            }
        }
    }
}

