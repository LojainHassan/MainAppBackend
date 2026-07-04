using Microsoft.EntityFrameworkCore;

namespace MainAppBackend.Infrastructure.Repositories.Product;
using MainAppBackend.Domain.Entities.Product;
using MainAppBackend.Domain.Interfaces.Product;
using MainAppBackend.Infrastructure.Persistence;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly ApplicationDbContext _context;

    public ProductCategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductCategory?> GetByIdAsync(Guid id) =>
        await _context.ProductCategories.FindAsync(id);

    public async Task<List<ProductCategory>> GetAllAsync() =>
        await _context.ProductCategories.ToListAsync();

    public async Task AddAsync(ProductCategory category) =>
        await _context.ProductCategories.AddAsync(category);

    public void Update(ProductCategory category) =>
        _context.ProductCategories.Update(category);

    public void Delete(ProductCategory category) =>
        _context.ProductCategories.Remove(category);
}