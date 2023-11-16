using System;
using System.Collections.Generic;

namespace AmarisConsulting.Models
{
    public partial class EstadoTurno
    {
        public EstadoTurno()
        {
            Turnos = new HashSet<Turno>();
        }

        public int IdEstado { get; set; }
        public string Estado { get; set; } = null!;

        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
