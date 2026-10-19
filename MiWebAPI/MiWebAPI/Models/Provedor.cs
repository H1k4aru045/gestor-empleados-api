namespace MiWebAPI.Models
{
    public class Provedor
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? RFC { get; set; }
        public string? Correo { get; set; }
        public decimal Credito { get; set; }
        public string? NombreBanco { get; set; }
    }
}