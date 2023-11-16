using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AmarisConsulting.Models
{
    public partial class UsuarioVM
    {
        public string NombreUsuario { get; set; } = null!;
        public string Clave { get; set; } = null!;

        [BindNever]
        public int IdUsuario { get; set; }

        [BindNever]
        public int IdCliente { get; set; }

        [BindNever]
        public string Nombres { get; set; } = null!;

        [BindNever]
        public string Apellidos { get; set; } = null!;
    }
}

