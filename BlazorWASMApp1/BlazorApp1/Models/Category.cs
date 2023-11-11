
namespace BlazorApp1.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Uri Image { get; set; }
        public DateTimeOffset? CreationAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        //public long Id { get; set; }
        //public string Name { get; set; }
        //public string Image { get; set; }
    }
}
