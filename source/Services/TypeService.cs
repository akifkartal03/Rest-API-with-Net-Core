using Microsoft.EntityFrameworkCore;
using netflixAPI.Data;
using netflixAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Services
{
    public class TypeService:ITypeService
    {
        private readonly DataContext _dataContext;

        public TypeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Types>> GetTypeAsync()
        {
            return await _dataContext.Types.ToListAsync();
        }

        public async Task<Types> GetTypeByIdAsync(Guid typeId)
        {
            return await _dataContext.Types
                .SingleOrDefaultAsync(x => x.TypeID == typeId);
        }

        public async Task<bool> CreateTypeAsync(Types type)
        {

            await _dataContext.Types.AddAsync(type);

            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdateTypeAsync(Types typeToUpdate)
        {

            _dataContext.Types.Update(typeToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteTypeAsync(Guid typeId)
        {
            var type = await GetTypeByIdAsync(typeId);

            if (type == null)
                return false;

            _dataContext.Types.Remove(type);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
