namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new string[]{ "1", "2", "3", "4", "5" };
            var numbers2 = new List<int>() { 6, 7, 8, 9, 10 };
            DisplayList(numbers);
            DisplayList(numbers2);
        }

        public static void DisplayList<T>(IEnumerable<T> numbers)
        {
            foreach(var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
