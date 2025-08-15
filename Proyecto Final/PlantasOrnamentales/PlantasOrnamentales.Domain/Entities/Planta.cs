namespace PlantasOrnamentales.Domain.Entities
{
    public class Planta
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? NombreCientifico { get; set; }
        public string? Descripcion { get; set; }
        public string? TemporadaSiembra { get; set; }

        // Relación con Categoría (N plantas → 1 categoría)
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = null!;

        // Relación 1–1
        public Cuidados? Cuidados { get; set; }

        // Relaciones 1–N
        public ICollection<CalendarioSiembra> Calendario { get; set; } = new List<CalendarioSiembra>();
        public ICollection<Plaga> Plagas { get; set; } = new List<Plaga>();
        public ICollection<ClimaRecomendado> Climas { get; set; } = new List<ClimaRecomendado>();
        public ICollection<Uso> Usos { get; set; } = new List<Uso>();
        public ICollection<FotoPlanta> Fotos { get; set; } = new List<FotoPlanta>();
    }
}
