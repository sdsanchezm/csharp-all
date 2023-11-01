using System;
using System.Collections.Generic;

namespace Indexers
{
    public class HttpCookieObject
    {
        private readonly Dictionary<string, string> _dictionary;
        public DateTime ExpiryDate { get; set; }

        public HttpCookieObject()
        {
            _dictionary = new Dictionary<string, string>();
        }

        public void SetItem(string key, string value)
        {

        }

        public string GetItem(string key)
        {

        }

        // this is a way to implement this ussage: cookie["name"] = "Jamecho";
        public string this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value; }
        }
    }
}

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            var cookie = new HttpCookieObject();
            // accessing elements by using a key value
            cookie["name"] = "Jamecho";
            Console.WriteLine(cookie["name"]);
        }
    }
}
