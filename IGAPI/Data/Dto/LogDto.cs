using Data.Dto.Common;

namespace Data.Dto;

public class LogDto : BaseDto
{
    public string? LogLevel { get; set; }
    public string? CategoryName { get; set; }
    public string? Msg { get; set; }
    public string? User { get; set; }
    public DateTime Timestamp { get; set; }
}