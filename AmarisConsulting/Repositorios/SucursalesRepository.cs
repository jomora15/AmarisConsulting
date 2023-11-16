using AmarisConsulting.Enum;
using AmarisConsulting.Models;
using AmarisConsulting.Models.ViewModels;
using AmarisConsulting.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmarisConsulting.Repositorios
{
    public class SucursalesRepository : ISucursalesRepository
    {
        private readonly AmarisConsultingContext _dbContext;

        public SucursalesRepository(AmarisConsultingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SucursalVM>> ObtenerSucursales()
        {
            List<SucursalVM> sucursalResponse = new List<SucursalVM>();

            var sucursales = await _dbContext.Sucursales.ToListAsync();

            sucursales.ForEach(sucu =>
            {
                sucursalResponse.Add(new SucursalVM()
                {
                    Direccion = sucu.Direccion,
                    IdSucursal = sucu.IdSucursal,
                    Nombre = sucu.Nombre,
                    Telefono = sucu.Telefono
                });
            });

            return sucursalResponse;
        }
    }
}
