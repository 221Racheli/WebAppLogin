using entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        MyShopSite325593952Context _DbContext;

        public ProductRepository(MyShopSite325593952Context dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<Product> addProductAsync(Product product)
        {
            await _DbContext.Products.AddAsync(product);
            await _DbContext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> getProductsWithCategoryAsync()
        {
            return await _DbContext.Products.Include(product => product.Category).ToListAsync();
        }
        public async Task<IEnumerable<Product>> getProductsBySearch(string desc, int minPrice, int maxPrice)
        {
            var query = _DbContext.Products.Where(product =>

                (desc == null ? (true) : product.Description.Contains(desc))
                    &&
                    (minPrice == null ? (true) : product.Price > minPrice)
                    &&
                    (maxPrice == null ? (true) : product.Price < maxPrice)
        ).OrderBy(product => product.Price);

            return await query.ToListAsync();

        }
    }
}
