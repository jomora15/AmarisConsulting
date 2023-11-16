using AmarisConsulting.Models;
using AmarisConsulting.Models.ViewModels;
using AmarisConsulting.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmarisConsulting.Controllers
{
    public class TurnoController : Controller
    {
        private ITurnosRepository _turnosRepository;

        public TurnoController(ITurnosRepository turnosRepository)
        {
            _turnosRepository = turnosRepository;
        }

        [HttpGet]
        [Route("api/turnos/{idCliente}")]
        public async Task<IActionResult> ListarTurnos(int idCliente)
        {
            return Ok(await _turnosRepository.ObtenerTurnos(idCliente));
        }

        [HttpPost]
        [Route("api/turnos")]
        public async Task<IActionResult> CrearTurno([FromBody]TurnoVM turnoVM)
        {
            Turno turno = new Turno()
            {
                FechaHora = turnoVM.FechaHora,
                IdCliente = turnoVM.IdCliente,
                IdSucursal = turnoVM.IdSucursal
            };

            turno.IdTurno = await _turnosRepository.CrearTurno(turno);

            return Ok(turno);
        }

        [HttpPut]
        [Route("api/activarturno/{idTurno}")]
        public async Task<IActionResult> ActivarTurno(int idTurno)
        {            
            return Ok(await _turnosRepository.ActivarTurno(idTurno));
        }

    }
}
