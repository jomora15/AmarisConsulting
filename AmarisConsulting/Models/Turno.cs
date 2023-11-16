namespace AmarisConsulting.Models
{
    public partial class Turno
    {
        public int IdTurno { get; set; }
        public int IdSucursal { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaHora { get; set; }
        public int IdEstado { get; set; }

        public virtual Cliente Clientes { get; set; } = null!;
        public virtual EstadoTurno EstadosTurno { get; set; } = null!;
        public virtual Sucursal Sucursales { get; set; } = null!;
    }
}
