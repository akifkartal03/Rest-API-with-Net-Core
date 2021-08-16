using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using netflixAPI.Data;
using netflixAPI.Domain;

namespace netflixAPI.Services
{
    public class ProgramService : IProgramService
    {
        private readonly DataContext _dataContext;

        public ProgramService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ProgramTable>> GetProgramAsync()
        {
            return await _dataContext.Programs.ToListAsync();
        }

        public async Task<ProgramTable> GetProgramByIdAsync(Guid programId)
        {
            return await _dataContext.Programs
                .SingleOrDefaultAsync(x => x.ProgramID == programId);
        }

        public async Task<bool> CreateProgramAsync(ProgramTable program)
        {
           
            await _dataContext.Programs.AddAsync(program);

            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdateProgramAsync(ProgramTable programToUpdate)
        {
            
            _dataContext.Programs.Update(programToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteProgramAsync(Guid programId)
        {
            var program = await GetProgramByIdAsync(programId);

            if (program == null)
                return false;

            _dataContext.Programs.Remove(program);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}