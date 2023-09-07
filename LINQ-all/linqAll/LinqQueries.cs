using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace linqAll
{
    public class LinqQueries
    {
        private List<Book> booksCollection = new List<Book>();
        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                //JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<Book>().ToList();
                //JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!
            }
        }
        public IEnumerable<Book> FullCollection()
        {
            return booksCollection;
        }

        public IEnumerable<Book> After2000()
        {
            // extension method
            //return booksCollection.Where(item => item.PublishedDate.Year > 2000);

            // Query Expression Method (Linq as expression):
            return from b in booksCollection where b.PublishedDate.Year > 2000 select b;

        }

        public IEnumerable<Book> MoreThan250PagesAndInActionIntitle()
        {
            // Extension method
            //return booksCollection.Where(item => item.PageCount > 250).Where(item => item.Title.ToLower().Contains("in action"));
            // another way
            //return booksCollection.Where(item => item.PageCount > 250 && item.Title.ToLower().Contains("in action"));

            // Query Expression
            return from b in booksCollection where b.PageCount > 250 && b.Title.ToLower().Contains("in action") select b;
        }

        public bool AllBooksHaveStatus()
        {
            //return booksCollection.Any(p => p.Status != "" );
            return booksCollection.All(p => p.Status != string.Empty);
        }

        public bool AnyBookFrom2005()
        {
            //return booksCollection.Any(p => p.Status != "" );
            return booksCollection.Any(p => p.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> BooksWithCategoriesPython()
        {
            // Extension method
            //return booksCollection.Where(item => item.Categories.Contains("Python"));

            // Query expression
            return from b in booksCollection where b.Categories.Contains("Python") select b;

        }
        public IEnumerable<Book> BooksOrderByCategory()
        {
            // Extension Method
            //return booksCollection.Where(item => item.Categories.Contains("Java")).OrderBy(p => p.Title);

            // Query expression
            return from b in booksCollection where b.Categories.Contains("Java") orderby b.Title select b;
        }

        public IEnumerable<Book> MoreThan450PagesOrdByNumPagesDesc()
        {
            // Extension Method
            //return booksCollection.Where(item => item.PageCount > 450).OrderByDescending(p => p.PageCount);

            // Query expression
            return from b in booksCollection where b.PageCount > 450 orderby b.PageCount descending select b;
        }

        public IEnumerable<Book> Take3MostRecentBooksCategoryJava()
        {
            //return booksCollection
            //    .Where(item => item.Categories
            //    .Contains("Java"))
            //    .OrderByDescending(p => p.PublishedDate)
            //    .Take(3);

            //return booksCollection
            //    .Where(item => item.Categories
            //    .Contains("Java"))
            //    .OrderBy(p => p.PublishedDate)
            //    .TakeLast(3);

            return (from book in booksCollection
                    where book.Categories.Contains("Java")
                    orderby book.PublishedDate descending
                    select book).Take(3);


        }

        public IEnumerable<Book> Take3rd4thWithMoreThan400Pages()
        {
            //return booksCollection
            //    .Where(item => item.PageCount > 400)
            //    .Take(4)
            //    .Skip(2);

            return (from book in booksCollection
                    where book.PageCount > 400
                    select book).Take(4).Skip(2);
        }

        public IEnumerable<Book> First3BooksOfbookCollection()
        {
            return booksCollection.Take(3)
                .Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
                //.Select(p => new { p.Title, p.PageCount });
        }

        // Code from a comment
        public IEnumerable<dynamic> GetCustomBook(
                Func<Book, dynamic> select,
                Func<Book, bool> where,
                Func<Book, object> order,
                int take,
                int skip = 0)
        {
            return this.booksCollection
                .Where(where)
                .OrderBy(order)
                .Take(take)
                .Select(select);
        }

        public int CountBooks200to500Pages()
        {
            //return booksCollection.Where(item => item.PageCount >= 200 && item.PageCount <= 500).Count();
            return booksCollection.Count(item => item.PageCount >= 200 && item.PageCount <= 500);
        }

        public long CountBooks200to500PagesLonCount()
        {
            //return booksCollection.Where(item => item.PageCount >= 200 && item.PageCount <= 500).Count();
            return booksCollection.LongCount(item => item.PageCount >= 200 && item.PageCount <= 500);
        }

        public DateTime PublishedDateMin()
        {
            return booksCollection.Min(p => p.PublishedDate);
        }

        public DateTime PublishedDateMax()
        {
            return booksCollection.Max(p => p.PublishedDate);
        }

        public int MaxNumberOfPages()
        {
            return booksCollection.Max(item => item.PageCount);
        }

        public Book BooksWithMinbyPageCount()
        {
            return booksCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
        }

        public Book BooksWithMaxbyPageCount()
        {
            return booksCollection.MaxBy(p => p.PublishedDate);
        }

        public int TotalSumOfBooksPagesBtw0and500Pages()
        {
            return booksCollection.Where(p => p.PageCount > 0 && p.PageCount <= 500).Sum(item => item.PageCount);
        }

        public string BookTitlesAfter2015Concatenated()
        {
            return booksCollection
            .Where(p => p.PublishedDate.Year > 2015)
                .Aggregate("", (BookTitles, next) =>
                {
                    if (BookTitles != string.Empty)
                        BookTitles += " - " + next.Title;
                    else
                        BookTitles += next.Title;

                    return BookTitles;
                });
        }

        public double AverageOfCharsOftitle()
        {
            return booksCollection.Average(p => p.Title.Length);
        }

        public IEnumerable<IGrouping<int, Book>> BooksAfter2000GroupedByYear()
        {
            return booksCollection
                .Where(item => item.PublishedDate.Year > 2000)
                .GroupBy(p => p.PublishedDate.Year);
        }



        



    }
}


