using netflixAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Services
{
    public interface IProgramTypeService
    {
        Task<List<ProgramTypeTable>> GetProgramTypeAsync();

        Task<bool> CreateProgramTypeAsync(ProgramTypeTable prgType);

        Task<ProgramTypeTable> GetProgramTypeByIdAsync(Guid prgTypeId);

        Task<bool> UpdateProgramTypeAsync(ProgramTypeTable prgTypeToUpdate);

        Task<bool> DeleteProgramTypeAsync(Guid prgTypeId);
    }
}
