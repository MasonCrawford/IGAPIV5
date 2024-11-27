using Data.Dto.Common;

namespace Data.Dto;

public class ProgramDto : BaseDto
{
    public bool IsActive { get; set; }
    public bool ReSeed { get; set; }
}