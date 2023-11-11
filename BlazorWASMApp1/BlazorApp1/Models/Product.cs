namespace BlazorApp1.Models
{
    public partial class Product
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long Price { get; set; }
        public string Description { get; set; }
        public Uri[] Images { get; set; }
        public DateTimeOffset CreationAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public Category? Category { get; set; }
        //public long Id { get; set; }
        //public string Title { get; set; }
        //public decimal? Price { get; set; }
        //public string Description { get; set; }
        //public string Images { get; set; }
        //public DateTimeOffset? CreationAt { get; set; }
        //public DateTimeOffset? UpdatedAt { get; set; }
        public int? CategoryId { get; set; }
        //public Category? category { get; set; }
    }
}
