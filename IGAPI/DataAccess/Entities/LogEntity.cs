using DataAccess.Entities.Common;

namespace DataAccess.Entities;

public class LogEntity : BaseEntity
{
    public string LogLevel { get; set; }
    public string CategoryName { get; set; }
    public string Msg { get; set; }
    public string User { get; set; }
    public DateTime Timestamp { get; set; }
}