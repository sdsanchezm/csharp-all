namespace inheritance
{
    
    public class Text: PresentationObject 
    {
        public int FontSize { get; set; }
        public int FontName { get; set; }

        public void AddHyperlink(string url)
        {
            Console.WriteLine($"link added from inherited class: {url}");
        }
    }
    
}