using entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<Product> addProductAsync(Product product);
        Task<IEnumerable<Product>> getProductsWithCategoryAsync();
    }
}