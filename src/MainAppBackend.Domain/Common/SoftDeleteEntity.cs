using System;
using System.Collections.Generic;
using System.Text;

namespace MainAppBackend.Domain.Common;

public abstract class SoftDeleteEntity : AuditableEntity
{
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}