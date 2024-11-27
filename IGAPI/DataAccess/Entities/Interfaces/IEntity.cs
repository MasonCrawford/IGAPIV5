namespace DataAccess.Entities.Interfaces;

public interface IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? LastModifiedOnUtc { get; set; }
}