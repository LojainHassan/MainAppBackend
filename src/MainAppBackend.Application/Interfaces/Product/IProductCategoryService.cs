using MainAppBackend.Application.Dtos.Product.ProductCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainAppBackend.Application.Interfaces.Product;

public interface IProductCategoryService
{
    Task<ProductCategoryListDto> CreateAsync(ProductCategoryCreateDto dto);
    Task<ProductCategoryListDto?> GetByIdAsync(Guid id);
    Task<List<ProductCategoryListDto>> GetAllAsync();
}