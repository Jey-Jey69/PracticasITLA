namespace PlantasOrnamentales.Domain.Entities
{
    public class Cuidados
    {
        public int Id { get; set; }
        public string? Luz { get; set; }
        public string? Riego { get; set; }
        public string? Suelo { get; set; }

        public int PlantaId { get; set; }
        public Planta Planta { get; set; } = null!;
    }
}
