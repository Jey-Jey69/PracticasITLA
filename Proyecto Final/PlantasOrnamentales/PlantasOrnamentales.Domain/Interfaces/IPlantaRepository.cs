using PlantasOrnamentales.Domain.Entities;

namespace PlantasOrnamentales.Domain.Interfaces
{
    public interface IPlantaRepository
    {
        Task<IEnumerable<Planta>> GetAllAsync();
        Task<Planta?> GetByIdAsync(int id);
        Task AddAsync(Planta planta);
        Task<bool> UpdateAsync(Planta planta); 
        Task<bool> DeleteAsync(int id);        
    }
}
