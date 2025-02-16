﻿namespace CourseManagement.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime CreatedUtc { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime LastModifiedUtc { get; set; }

    public string? LastModifiedBy { get; set; }
}
