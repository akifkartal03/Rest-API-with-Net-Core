using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using netflixAPI.Domain;

namespace netflixAPI.Services
{
    public interface IProgramService
    {
        Task<List<ProgramTable>> GetProgramAsync();

        Task<bool> CreateProgramAsync(ProgramTable program);

        Task<ProgramTable> GetProgramByIdAsync(Guid programId);

        Task<bool> UpdateProgramAsync(ProgramTable programToUpdate);

        Task<bool> DeleteProgramAsync(Guid programId);
        
        //Task<bool> UserOwnsProgramAsync(int ProgramId, string userId);
        
    }
}