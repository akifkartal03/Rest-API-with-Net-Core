using netflixAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Services
{
    public interface IUserProgramService
    {
        Task<List<UserProgramTable>> GetUserProgramAsync();

        Task<bool> CreateUserProgramAsync(UserProgramTable userProgram);

        Task<UserProgramTable> GetUserProgramByIdAsync(Guid userProgramId);

        Task<bool> UpdateUserProgramAsync(UserProgramTable userProgramToUpdate);

        Task<bool> DeleteUserProgramAsync(Guid userProgramId);
    }
}
