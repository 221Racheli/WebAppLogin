using entities;

namespace Service
{
    public interface IProductService
    {
        Task<Product> addProductAsync(Product product);
        Task<IEnumerable<Product>> getProductsWithCategoryAsync();
    }
}