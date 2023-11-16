using AmarisConsulting.Models;
using AmarisConsulting.Models.ViewModels;

namespace AmarisConsulting.Repositorios.Interfaces
{
    public interface ISucursalesRepository
    {
        Task<List<SucursalVM>> ObtenerSucursales();
    }
}