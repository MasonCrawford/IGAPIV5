using System.ComponentModel.DataAnnotations;
using DataAccess.Entities.Interfaces;

namespace DataAccess.Entities.Common;

public abstract class BaseEntity : IEntity
{
    [Key] public Guid Id { get; set; }

    [Required] public DateTime CreatedOnUtc { get; set; }

    public DateTime? LastModifiedOnUtc { get; set; }
}