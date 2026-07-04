using MainAppBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainAppBackend.Domain.Entities.Product;

public class ProductCategory: AuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;
    public string? NameEn { get; set; } = string.Empty;
    public string? Description { get; set; }
}
