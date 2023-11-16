using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AmarisConsulting.Models.ViewModels
{
    public partial class SucursalVM
    {
        [BindNever]
        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
    }
}
