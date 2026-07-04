using AutoMapper;
using MainAppBackend.Application.Dtos.Product.ProductCategory;
using MainAppBackend.Application.Interfaces.Product;
using MainAppBackend.Domain.Entities.Product;
using MainAppBackend.Domain.Interfaces.Product;

namespace MainAppBackend.Application.Services.Product;
public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _repository;
    private readonly IMapper _mapper;

    public ProductCategoryService(IProductCategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductCategoryListDto> CreateAsync(ProductCategoryCreateDto dto)
    {
        var category = _mapper.Map<ProductCategory>(dto);
        await _repository.AddAsync(category);
        return _mapper.Map<ProductCategoryListDto>(category);
    }

    public async Task<ProductCategoryListDto?> GetByIdAsync(Guid id)
    {
        var category = await _repository.GetByIdAsync(id);
        return category is null ? null : _mapper.Map<ProductCategoryListDto>(category);
    }

    public async Task<List<ProductCategoryListDto>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync();
        return _mapper.Map<List<ProductCategoryListDto>>(categories);
    }
}
