using System;

namespace Olih.Common;

public abstract class BaseEntity
{
    public virtual required string Id { get; set; }
    public virtual required string CreatedBy { get; set; }
    public virtual required DateTime CreatedAt { get; set; }
    public virtual required string UpdatedBy { get; set; }
    public virtual required DateTime UpdatedAt { get; set; }
}