namespace PlantasOrnamentales.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public ICollection<Planta> Plantas { get; set; } = new List<Planta>();
    }
}
