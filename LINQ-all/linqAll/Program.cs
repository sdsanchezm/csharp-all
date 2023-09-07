using System.Linq;


namespace linqAll
{
    public class Program
    {
        static void Main(string[] args)
        {

            LinqQueries queries = new LinqQueries();

            // quest 0, full collection
            //PrintValues(queries.FullCollection());

            // quest 1, books publised after year 2000
            //PrintValues(queries.After2000());

            // quest 2, boos with more than 250 pages and "in action" in title
            //PrintValues(queries.MoreThan250PagesAndInActionIntitle());

            // quest 3 - animals
            var animals = new AnimalQueries();
            //animals.FilterAnimalQuest1();
            animals.FilterAnimalQuest2();

        }

        static void PrintValues(IEnumerable<Book> bookList)
        {
            Console.WriteLine("{0, -60} {1, 14} {2,14} \n", "Book Title", "Page numbers", "Date Pub.");
            foreach (Book book in bookList)
            {
                Console.WriteLine("{0, -60} {1, 14} {2,14}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
            }
        }

        public void InitialTest()
        {
            var fruits = new string[] { "apple", "cherry", "strawberry", "blueberry", "pineapple", "passion fruit", "lima", "papaya" };
            var fruitsList = fruits.Where(p => p.StartsWith("pa")).ToList();

            fruitsList.ForEach(p => { Console.WriteLine(p); });
        }
    }
}