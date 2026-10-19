namespace MiWebAPI.Models
{
    public class Mobiliario
    {
        public long IdMobiliario { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Material { get; set; }
        public string? Color { get; set; }
        public decimal Costo { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}