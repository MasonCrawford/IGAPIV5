using Data.Dto.Common;
using DataAccess.Entities.Common;

namespace DataFactory.Interfaces;

public interface IBaseDataScervice<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
{
    public TDto? Map(TEntity entity);
    public TEntity? Map(TDto dto);
}