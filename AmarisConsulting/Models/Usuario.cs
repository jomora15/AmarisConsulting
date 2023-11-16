namespace AmarisConsulting.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Clave { get; set; } = null!;

        public virtual Cliente Clientes { get; set; } = null!;
    }
}
