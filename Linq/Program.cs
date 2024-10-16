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

            Func<int, int> multiply = (x) => x * 2;
            Console.WriteLine(multiply(5));

            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine(add(5,5));

            Func<string, string> versal = (x) => x.ToUpper();
            Console.WriteLine(versal("Bacon"));

            ProcessNumber(add, 100);
            Console.WriteLine(GenericProcess(20, multiply));
            Console.WriteLine(GenericProcess("Apple", versal));

            List<int> myNumbers = Enumerable.Range(1, 10).ToList();
            var evenNumbers = myNumbers.Where(n => n % 2 == 0);
            Looper(evenNumbers);

            List<int> myInts = Enumerable.Range(1, 5).ToList();
            var intsToDouble = myInts.Select(n => n / 0.33);
            Looper(intsToDouble);

            var myNames = new List<string> { "Alice", "Charlie", "Bob", "Eve", "David" };
            var mySortedNames = myNames.OrderBy(n => n);
            Looper(mySortedNames);

            var randomNumbers = new List<int> { 10, 3, 5, 2, 8, 7 };
            var manipulateNumbers = randomNumbers.Where(num => num > 5)
                .Select(num => num * 0.33)
                .OrderByDescending(num => num);
            Looper(manipulateNumbers);

            var games = new List<VideoGame> { 
                new VideoGame("Half-Life", 1998, "First-person Shooter", true),
                new VideoGame("The Witcher 3: Wild Hunt", 2015, "Action RPG", false),
                new VideoGame("Cyberpunk 2077", 2020, "Action RPG", false),
                new VideoGame("Doom Eternal", 2020, "First-person Shooter", true),
                new VideoGame("Minecraft", 2011, "Sandbox", true),
                new VideoGame("Grand Theft Auto V", 2013, "Action-adventure", true),
                new VideoGame("Overwatch", 2016, "First-person Shooter", true)
            };

            string searchOption = HandleSearchOptions();
            SearchVideoGames(searchOption, games);
        }

        public static string HandleSearchOptions()
        {
            Console.WriteLine("Select how you'd like to search for your video game:");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Year");
            Console.WriteLine("3. Genre");
            Console.WriteLine("4. Multiplayer");

            while(true)
            {
                string input = Console.ReadLine();
                List<int> oneToFour = Enumerable.Range(1, 4).ToList();

                foreach(int num in oneToFour)
                {
                    if(input == num.ToString())
                    {
                        return input;
                    }
                }

                Console.WriteLine("Press a number between 1 - 4!");
            }
        }

        public static void SearchVideoGames(string searchOption, List<VideoGame> games)
        {
            var filteredGames = new List<VideoGame>();

            switch(searchOption)
            {
                case "1":
                    break;
                case "2":
                    Console.WriteLine("Type a year:");
                    string userInput = Console.ReadLine();
                    filteredGames = games.Where(game => game.ReleaseYear == Int32.Parse(userInput)).ToList();
                    break;
                default:
                    Console.WriteLine($"Default: {searchOption}");
                    break;
            }

            foreach(var game in filteredGames)
            {
                Console.WriteLine($"{game.Title} {game.ReleaseYear} {game.Genre} {game.Multiplayer}");
            }
        }

        public static void Looper<T>(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static TResult GenericProcess<T, TResult>(T input, Func<T, TResult> operation)
        {
            return operation(input);
        }

        public static void ProcessNumber(Func<int, int, int> operation, int y)
        {
            int num = 10;
            int sum = operation(y, num);
            Console.WriteLine(sum);
        }

        public static void DisplayList<T>(IEnumerable<T> numbers)
        {
            /*foreach(var item in numbers)
            {
                Console.WriteLine(item);
            }*/

            using(IEnumerator<T> enumerator = numbers.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    T item = enumerator.Current;
                    Console.WriteLine(item);
                }
            }
        }
    }

    class VideoGame
    {
        public string Title { get; }
        public int ReleaseYear { get; }
        public string Genre { get; }
        public bool Multiplayer { get; }

        public VideoGame(string title, int releaseYear, string genre, bool multiplayer)
        {
            Title = title;
            ReleaseYear = releaseYear;
            Genre = genre;
            Multiplayer = multiplayer;
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

