using AmarisConsulting.Repositorios;
using AmarisConsulting.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmarisConsulting.Controllers
{    
    public class SucursalController : Controller
    {
        private ISucursalesRepository _sucursalesRepository;

        public SucursalController(ISucursalesRepository sucursalesRepository)
        {
            _sucursalesRepository = sucursalesRepository;
        }

        [HttpGet]
        [Route("api/sucursal")]
        public async Task<IActionResult> ListarSucursales()
        {
            return Ok(await _sucursalesRepository.ObtenerSucursales());
        }
    }
}
