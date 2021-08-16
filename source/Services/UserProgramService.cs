using Microsoft.EntityFrameworkCore;
using netflixAPI.Data;
using netflixAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Services
{
    public class UserProgramService : IUserProgramService
    {
        private readonly DataContext _dataContext;

        public UserProgramService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<UserProgramTable>> GetUserProgramAsync()
        {
            return await _dataContext.UserPrograms.ToListAsync();

        }

        public async Task<bool> CreateUserProgramAsync(UserProgramTable userProgram)
        {
            await _dataContext.UserPrograms.AddAsync(userProgram);

            var created = await _dataContext.SaveChangesAsync();
            return created > 0;

        }

        public async Task<UserProgramTable> GetUserProgramByIdAsync(Guid userProgramId)
        {
            return await _dataContext.UserPrograms
                .SingleOrDefaultAsync(x => x.UserPrgID == userProgramId);
        }

        public async Task<bool> UpdateUserProgramAsync(UserProgramTable userProgramToUpdate)
        {
            _dataContext.UserPrograms.Update(userProgramToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteUserProgramAsync(Guid userProgramId)
        {
            var userProgram = await GetUserProgramByIdAsync(userProgramId);

            if (userProgram == null)
                return false;

            _dataContext.UserPrograms.Remove(userProgram);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
