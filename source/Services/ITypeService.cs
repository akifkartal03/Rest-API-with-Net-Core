using netflixAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflixAPI.Services
{
    public interface ITypeService
    {
        Task<List<Types>> GetTypeAsync();

        Task<bool> CreateTypeAsync(Types type);

        Task<Types> GetTypeByIdAsync(Guid typeId);

        Task<bool> UpdateTypeAsync(Types typeToUpdate);

        Task<bool> DeleteTypeAsync(Guid typeId);
    }
}
