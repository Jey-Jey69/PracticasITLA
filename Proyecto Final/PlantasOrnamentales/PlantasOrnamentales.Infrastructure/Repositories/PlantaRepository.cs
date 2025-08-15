using Microsoft.EntityFrameworkCore;
using PlantasOrnamentales.Domain.Entities;
using PlantasOrnamentales.Domain.Interfaces;
using PlantasOrnamentales.Infrastructure.Data;

namespace PlantasOrnamentales.Infrastructure.Repositories
{
    public class PlantaRepository : IPlantaRepository
    {
        private readonly AppDbContext _context;
        public PlantaRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Planta>> GetAllAsync() =>
            await _context.Plantas.AsNoTracking()
                .Include(p => p.Categoria)
                .Include(p => p.Cuidados)
                .Include(p => p.Calendario)
                .Include(p => p.Plagas)
                .Include(p => p.Climas)
                .Include(p => p.Usos)
                .Include(p => p.Fotos)
                .ToListAsync();

        public async Task<Planta?> GetByIdAsync(int id) =>
            await _context.Plantas.AsNoTracking()
                .Include(p => p.Categoria)
                .Include(p => p.Cuidados)
                .Include(p => p.Calendario)
                .Include(p => p.Plagas)
                .Include(p => p.Climas)
                .Include(p => p.Usos)
                .Include(p => p.Fotos)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Planta planta)
        {
            _context.Plantas.Add(planta);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Planta planta)
        {
            var exists = await _context.Plantas.AnyAsync(x => x.Id == planta.Id);
            if (!exists) return false;

            _context.Attach(planta);
            _context.Entry(planta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Plantas.FindAsync(id);
            if (entity is null) return false;

            _context.Plantas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
