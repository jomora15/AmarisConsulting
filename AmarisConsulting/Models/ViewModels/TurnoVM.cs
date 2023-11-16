using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmarisConsulting.Models.ViewModels
{
    public class TurnoVM
    {
        [BindNever]
        public int IdTurno { get; set; }
        public int IdSucursal { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaHora { get; set; }

        [BindNever]
        public int IdEstado { get; set; }
    }

    public class TurnoResponse
    {
        public int IdTurno { get; set; }
        public DateTime FechaHora { get; set; }
        public SucursalVM? Sucursal { get; set; }

        public string? Estado { get; set; }
    }
}
