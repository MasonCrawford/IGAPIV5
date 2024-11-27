namespace Data.Dto.Common;

public class BaseDto
{
    public Guid? Id { get; set; }
    
    public DateTime CreatedOnUtc { get; set; }

    public DateTime? LastModifiedOnUtc { get; set; }
}