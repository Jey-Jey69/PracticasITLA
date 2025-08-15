namespace PlantasOrnamentales.Domain.Entities
{
    public class CalendarioSiembra
    {
        public int Id { get; set; }
        public string Mes { get; set; } = null!;

        public int PlantaId { get; set; }
        public Planta Planta { get; set; } = null!;
    }
}
