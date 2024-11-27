using Data.Dto;
using DataAccess.Entities;

namespace DataFactory.Interfaces;

public interface IProgramDataService : IBaseDataScervice<ProgramEntity, ProgramDto>
{
    ProgramEntity? Get();
    Task<bool> GetIsActive();
}