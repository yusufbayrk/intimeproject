using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext __context;
        public ProductRepository(StoreContext context)
        {
            __context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await __context.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.ProductType)
            .FirstOrDefaultAsync(p=>p.Id==id);
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            


            return await __context.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.productBrand)
            .ToListAsync();
        }

        public Task<IReadOnlyList<Product>> GetProductAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
           return await __context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
           return await __context.ProductTypes.ToListAsync();
        }
    }
}