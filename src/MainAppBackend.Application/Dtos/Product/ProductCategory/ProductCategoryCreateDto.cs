using System;
using System.Collections.Generic;
using System.Text;

namespace MainAppBackend.Application.Dtos.Product.ProductCategory;

public class ProductCategoryCreateDto
{
    public string Code { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;
    public string? NameEn { get; set; } = string.Empty;
    public string? Description { get; set; }
}
