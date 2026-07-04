using MainAppBackend.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainAppBackend.Domain.Interfaces.Product;

public interface IProductCategoryRepository
{
    Task<ProductCategory?> GetByIdAsync(Guid id);
    Task<List<ProductCategory>> GetAllAsync();
    Task AddAsync(ProductCategory category);
    void Update(ProductCategory category);
    void Delete(ProductCategory category);
}