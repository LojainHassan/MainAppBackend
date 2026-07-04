using MainAppBackend.Application.Common;


namespace MainAppBackend.Application.Dtos.Product.ProductCategory;
public class ProductCategoryListDto : BaseDto
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; }
}