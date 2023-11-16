using System;
using System.Collections.Generic;

namespace AmarisConsulting.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Turnos = new HashSet<Turno>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdCliente { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Telefono { get; set; } = null!;

        public virtual ICollection<Turno> Turnos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
