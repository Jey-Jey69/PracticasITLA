namespace PlantasOrnamentales.Domain.Entities
{
    public class Uso
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;
        public string? Descripcion { get; set; }


        public int PlantaId { get; set; }
        public Planta Planta { get; set; } = null!;
    }
}
