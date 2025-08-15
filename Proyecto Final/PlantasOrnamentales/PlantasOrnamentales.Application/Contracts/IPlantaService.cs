using System.Collections.Generic;
using System.Threading.Tasks;
using PlantasOrnamentales.Application.DTOs;

namespace PlantasOrnamentales.Application.Contracts
{
    public interface IPlantaService
    {
        Task<IEnumerable<PlantaReadDto>> GetAllAsync();
        Task<PlantaReadDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(PlantaCreateDto dto);
        Task<bool> UpdateAsync(PlantaUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
