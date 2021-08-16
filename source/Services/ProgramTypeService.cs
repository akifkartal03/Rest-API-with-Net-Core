using Microsoft.EntityFrameworkCore;
using netflixAPI.Data;
using netflixAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Services
{
    public class ProgramTypeService : IProgramTypeService
    {
        private readonly DataContext _dataContext;

        public ProgramTypeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ProgramTypeTable>> GetProgramTypeAsync()
        {
            return await _dataContext.ProgramTypes.ToListAsync();
        }

        public async Task<ProgramTypeTable> GetProgramTypeByIdAsync(Guid prgTypeId)
        {
            return await _dataContext.ProgramTypes
                .SingleOrDefaultAsync(x => x.PrgTypeId == prgTypeId);
        }

        public async Task<bool> CreateProgramTypeAsync(ProgramTypeTable prgType)
        {

            await _dataContext.ProgramTypes.AddAsync(prgType);

            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdateProgramTypeAsync(ProgramTypeTable prgTypeToUpdate)
        {

            _dataContext.ProgramTypes.Update(prgTypeToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteProgramTypeAsync(Guid prgTypeId)
        {
            var prgType = await GetProgramTypeByIdAsync(prgTypeId);

            if (prgType == null)
                return false;

            _dataContext.ProgramTypes.Remove(prgType);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
