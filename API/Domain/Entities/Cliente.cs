namespace Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CorreoElectronico { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
    }
}
