using BlazorApp1.Models;

namespace BlazorApp1.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>?> Get();
        Task Add(Product product);
        Task Delete(long productId);
    }
}