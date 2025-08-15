namespace PlantasOrnamentales.Application.DTOs
{
    public class PlantaReadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string? NombreCientifico { get; set; }
        public string? Descripcion { get; set; }
        public string? TemporadaSiembra { get; set; }
        public int CategoriaId { get; set; }
    }

    public class PlantaCreateDto
    {
        public string Nombre { get; set; } = "";
        public string? NombreCientifico { get; set; }
        public string? Descripcion { get; set; }
        public string? TemporadaSiembra { get; set; }
        public int CategoriaId { get; set; }
    }

    public class PlantaUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string? NombreCientifico { get; set; }
        public string? Descripcion { get; set; }
        public string? TemporadaSiembra { get; set; }
        public int CategoriaId { get; set; }
    }
}
