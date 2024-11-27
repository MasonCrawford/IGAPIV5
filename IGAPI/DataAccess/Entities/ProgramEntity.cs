using DataAccess.Entities.Common;

namespace DataAccess.Entities;

public class ProgramEntity : BaseEntity
{
    public bool IsActive { get; set; }
    public bool ReSeed { get; set; }
}