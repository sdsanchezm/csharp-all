using System.Linq;


namespace linqAll
{
    public class Program
    {
        static void Main(string[] args)
        {

            LinqQueries queries = new LinqQueries();
            var animals = new AnimalQueries();

            // quest 0, full collection
            //PrintValues(queries.FullCollection());

            // quest 1, books publised after year 2000
            //PrintValues(queries.After2000());

            // quest 2, boos with more than 250 pages and "in action" in title
            //PrintValues(queries.MoreThan250PagesAndInActionIntitle());

            // quest 3 - animals
            //animals.FilterAnimalQuest1();
            //animals.FilterAnimalQuest2();

            // quest 4- books All, Any
            //Console.WriteLine(queries.AllBooksHaveStatus());

            // quest 5 - Any
            //Console.WriteLine(queries.AnyBookFrom2005());

            // quest 6 - contains
            //PrintValues(queries.BooksWithCategoriesPython());

            // quest 7 - Order
            //PrintValues(queries.BooksOrderByCategory());

            // quest 8 - Order
            //PrintValues(queries.MoreThan450PagesOrdByNumPagesDesc());


            // quest 9 - Order animals by name
            //animals.OrderAnimalByName1();
            //animals.OrderAnimalByName2();

            // quest 10 - 
            //PrintValues(queries.Take3MostRecentBooksCategoryJava());

            // quest 11 - 


            // quest 12 - select
            //PrintValues(queries.First3BooksOfbookCollection());

            // quest 13 - Count
            //Console.WriteLine(queries.CountBooks200to500Pages());
            //Console.WriteLine(queries.CountBooks200to500PagesLonCount());

            // quest 14 - Min Max wuith datetime
            //Console.WriteLine(queries.PublishedDateMin().ToShortDateString());
            //Console.WriteLine(queries.PublishedDateMax().ToShortDateString());

            // quest 15 - max with page numbers
            //Console.WriteLine(queries.MaxNumberOfPages());

            // quest 16 - minby
            //var book1 = queries.BooksWithMinbyPageCount();
            //Console.WriteLine($"{book1.Title} - {book1.PublishedDate} - {book1.PageCount}");

            // quest 17 - MaxBy
            //var book2 = queries.BooksWithMaxbyPageCount();
            //Console.WriteLine($"{book2.Title} - {book2.PublishedDate} - {book2.PageCount}");

            // quest 18 - sum
            //Console.WriteLine(queries.TotalSumOfBooksPagesBtw0and500Pages());

            // question 19 - Aggregate
            //Console.WriteLine(queries.BookTitlesAfter2015Concatenated());

            // quest 20
            //Console.WriteLine(queries.AverageOfCharsOftitle());

            // quest 21
            //PrintGroup(queries.BooksAfter2000GroupedByYear());

            // quest 22 - GroupBy (from repl.it
            //animals.GropingAnimalsByColor();

            // quest 23 - Lookup
            //var booksLocal = queries.BookDictionaryByStartingChar();
            //PrintDictionary(booksLocal, 'P');

            // quest 24 - Join
            //PrintValues(queries.BooksAfter2005WithMoreThan500Pages());
            PrintValues(queries.BooksAfter2005WithMoreThan500Pages2());


        }


        static void PrintDictionary(ILookup<char, Book> bookList, char letterLocal)
        {
            char upperLetter = Char.ToUpper(letterLocal);
            if (bookList[upperLetter].Count() == 0)
            {
                Console.WriteLine($"No books starting with: '{upperLetter}'");
            }
            else
            {
                Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Title", "N. Pages", "Published Date");
                foreach (var book in bookList[upperLetter])
                {
                    Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
                }
            }
        }

        static void PrintGroup(IEnumerable<IGrouping<int, Book>> booksCollection)
        {
            foreach (var group in booksCollection)
            {
                Console.WriteLine("--");
                Console.WriteLine($"## Group: {group.Key}");
                Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Title", "N. Pages", "Published on");
                foreach (var item in group)
                {
                    Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
                }
            }
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