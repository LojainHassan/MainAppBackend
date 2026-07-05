using AutoMapper;
using MainAppBackend.Application.Dtos.Product.ProductCategory;
using MainAppBackend.Application.Services.Product;
using MainAppBackend.Domain.Entities.Product;
using MainAppBackend.Domain.Interfaces.Product;
using Moq;

namespace MainAppBackend.Tests;

public class ProductCategoryServiceTests
{
    private readonly Mock<IProductCategoryRepository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly ProductCategoryService _service;

    public ProductCategoryServiceTests()
    {
        _mockRepository = new Mock<IProductCategoryRepository>();
        _mockMapper = new Mock<IMapper>();
        _service = new ProductCategoryService(_mockRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnMappedDto_WhenValidInput()
    {
        // Arrange
        var createDto = new ProductCategoryCreateDto
        {
            Code = "CAT001",
            NameAr = "فئة المنتج",
            NameEn = "Product Category",
            Description = "Test description"
        };

        var category = new ProductCategory
        {
            Id = Guid.NewGuid(),
            Code = createDto.Code,
            NameAr = createDto.NameAr,
            NameEn = createDto.NameEn,
            Description = createDto.Description
        };

        var expectedDto = new ProductCategoryListDto
        {
            Id = category.Id,
            NameAr = category.NameAr,
            NameEn = category.NameEn,
            Description = category.Description
        };

        _mockMapper.Setup(m => m.Map<ProductCategory>(createDto)).Returns(category);
        _mockMapper.Setup(m => m.Map<ProductCategoryListDto>(category)).Returns(expectedDto);
        _mockRepository.Setup(r => r.AddAsync(category)).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateAsync(createDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedDto.Id, result.Id);
        Assert.Equal(expectedDto.NameAr, result.NameAr);
        Assert.Equal(expectedDto.NameEn, result.NameEn);
        Assert.Equal(expectedDto.Description, result.Description);

        _mockRepository.Verify(r => r.AddAsync(category), Times.Once);
        _mockMapper.Verify(m => m.Map<ProductCategory>(createDto), Times.Once);
        _mockMapper.Verify(m => m.Map<ProductCategoryListDto>(category), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMappedDto_WhenCategoryExists()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        var category = new ProductCategory
        {
            Id = categoryId,
            Code = "CAT001",
            NameAr = "فئة المنتج",
            NameEn = "Product Category",
            Description = "Test description"
        };

        var expectedDto = new ProductCategoryListDto
        {
            Id = categoryId,
            NameAr = category.NameAr,
            NameEn = category.NameEn,
            Description = category.Description
        };

        _mockRepository.Setup(r => r.GetByIdAsync(categoryId)).ReturnsAsync(category);
        _mockMapper.Setup(m => m.Map<ProductCategoryListDto>(category)).Returns(expectedDto);

        // Act
        var result = await _service.GetByIdAsync(categoryId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedDto.Id, result.Id);
        Assert.Equal(expectedDto.NameAr, result.NameAr);
        Assert.Equal(expectedDto.NameEn, result.NameEn);
        Assert.Equal(expectedDto.Description, result.Description);

        _mockRepository.Verify(r => r.GetByIdAsync(categoryId), Times.Once);
        _mockMapper.Verify(m => m.Map<ProductCategoryListDto>(category), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenCategoryDoesNotExist()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        _mockRepository.Setup(r => r.GetByIdAsync(categoryId)).ReturnsAsync((ProductCategory?)null);

        // Act
        var result = await _service.GetByIdAsync(categoryId);

        // Assert
        Assert.Null(result);
        _mockRepository.Verify(r => r.GetByIdAsync(categoryId), Times.Once);
        _mockMapper.Verify(m => m.Map<ProductCategoryListDto>(It.IsAny<ProductCategory>()), Times.Never);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMappedDtos_WhenCategoriesExist()
    {
        // Arrange
        var categories = new List<ProductCategory>
        {
            new ProductCategory
            {
                Id = Guid.NewGuid(),
                Code = "CAT001",
                NameAr = "فئة المنتج 1",
                NameEn = "Product Category 1",
                Description = "Test description 1"
            },
            new ProductCategory
            {
                Id = Guid.NewGuid(),
                Code = "CAT002",
                NameAr = "فئة المنتج 2",
                NameEn = "Product Category 2",
                Description = "Test description 2"
            }
        };

        var expectedDtos = new List<ProductCategoryListDto>
        {
            new ProductCategoryListDto
            {
                Id = categories[0].Id,
                NameAr = categories[0].NameAr,
                NameEn = categories[0].NameEn,
                Description = categories[0].Description
            },
            new ProductCategoryListDto
            {
                Id = categories[1].Id,
                NameAr = categories[1].NameAr,
                NameEn = categories[1].NameEn,
                Description = categories[1].Description
            }
        };

        _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(categories);
        _mockMapper.Setup(m => m.Map<List<ProductCategoryListDto>>(categories)).Returns(expectedDtos);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(expectedDtos[0].Id, result[0].Id);
        Assert.Equal(expectedDtos[1].Id, result[1].Id);

        _mockRepository.Verify(r => r.GetAllAsync(), Times.Once);
        _mockMapper.Verify(m => m.Map<List<ProductCategoryListDto>>(categories), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoCategoriesExist()
    {
        // Arrange
        var categories = new List<ProductCategory>();
        var expectedDtos = new List<ProductCategoryListDto>();

        _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(categories);
        _mockMapper.Setup(m => m.Map<List<ProductCategoryListDto>>(categories)).Returns(expectedDtos);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);

        _mockRepository.Verify(r => r.GetAllAsync(), Times.Once);
        _mockMapper.Verify(m => m.Map<List<ProductCategoryListDto>>(categories), Times.Once);
    }
}
