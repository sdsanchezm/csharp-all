using System.Text.Json;

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
    }
}


