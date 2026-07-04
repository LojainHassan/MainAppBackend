using MainAppBackend.Application.Dtos.Product.ProductCategory;
using MainAppBackend.Application.Interfaces.Product;
using Microsoft.AspNetCore.Mvc;

namespace MainAppBackend.API.Controllers.Product;

[ApiController]
[Route("api/[controller]")]
public class ProductCategoriesController: ControllerBase
{
    private readonly IProductCategoryService _service;

    public ProductCategoriesController(IProductCategoryService service)
    {
        _service = service;
    }
    [HttpPost]

    public async Task<IActionResult> Create(ProductCategoryCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

}
