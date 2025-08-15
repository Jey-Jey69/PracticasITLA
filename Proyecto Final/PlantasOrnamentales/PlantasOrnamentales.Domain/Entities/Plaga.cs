namespace PlantasOrnamentales.Domain.Entities
{
    public class Plaga
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Tratamiento { get; set; }

        public int PlantaId { get; set; }
        public Planta Planta { get; set; } = null!;
    }
}
