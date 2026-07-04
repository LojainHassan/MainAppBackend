using System;
using System.Collections.Generic;
using System.Text;

namespace MainAppBackend.Application.Common;
public abstract class BaseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}