using BlazorApp1.Models;

namespace BlazorApp1.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>?> Get();
    }
}