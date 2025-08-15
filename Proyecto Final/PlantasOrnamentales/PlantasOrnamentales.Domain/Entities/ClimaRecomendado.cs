namespace PlantasOrnamentales.Domain.Entities
{
    public class ClimaRecomendado
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;
        public decimal? TemperaturaMin { get; set; }
        public decimal? TemperaturaMax { get; set; }

        public int PlantaId { get; set; }
        public Planta Planta { get; set; } = null!;
    }
}
