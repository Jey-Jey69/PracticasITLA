namespace PlantasOrnamentales.Domain.Entities
{
    public class FotoPlanta
    {
        public int Id { get; set; }
        public string UrlImagen { get; set; } = null!;
        public string? Descripcion { get; set; }

        public int PlantaId { get; set; }
        public Planta Planta { get; set; } = null!;
    }
}
