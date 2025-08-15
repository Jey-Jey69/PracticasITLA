using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlantasOrnamentales.Application.Contracts;
using PlantasOrnamentales.Application.DTOs;
using PlantasOrnamentales.Domain.Entities;
using PlantasOrnamentales.Domain.Interfaces;

namespace PlantasOrnamentales.Application.Services
{
    public class PlantaService : IPlantaService
    {
        private readonly IPlantaRepository _repo;

        public PlantaService(IPlantaRepository repo)
        {
            _repo = repo;
        }

        // Mapeos manuales
        private static PlantaReadDto ToDto(Planta p) => new PlantaReadDto
        {
            Id = p.Id,
            Nombre = p.Nombre,
            NombreCientifico = p.NombreCientifico,
            Descripcion = p.Descripcion,
            TemporadaSiembra = p.TemporadaSiembra,
            CategoriaId = p.CategoriaId
        };

        private static Planta FromCreate(PlantaCreateDto d) => new Planta
        {
            Nombre = d.Nombre,
            NombreCientifico = d.NombreCientifico,
            Descripcion = d.Descripcion,
            TemporadaSiembra = d.TemporadaSiembra,
            CategoriaId = d.CategoriaId
        };

        private static void ApplyUpdate(Planta p, PlantaUpdateDto d)
        {
            p.Nombre = d.Nombre;
            p.NombreCientifico = d.NombreCientifico;
            p.Descripcion = d.Descripcion;
            p.TemporadaSiembra = d.TemporadaSiembra;
            p.CategoriaId = d.CategoriaId;
        }

        public async Task<IEnumerable<PlantaReadDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(ToDto);
        }

        public async Task<PlantaReadDto?> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            return p == null ? null : ToDto(p);
        }

        public async Task<bool> CreateAsync(PlantaCreateDto dto)
        {
            var entity = FromCreate(dto);
            await _repo.AddAsync(entity);
            return true;
        }

        public async Task<bool> UpdateAsync(PlantaUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);
            if (existing == null) return false;

            ApplyUpdate(existing, dto);
            await _repo.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exists = await _repo.GetByIdAsync(id);
            if (exists == null) return false;

            await _repo.DeleteAsync(id);
            return true;
        }
    }
}
