using System;
using System.Collections.Generic;

namespace AmarisConsulting.Models
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Turnos = new HashSet<Turno>();
        }

        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;

        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
