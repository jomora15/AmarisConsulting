using AmarisConsulting.Enum;
using AmarisConsulting.Models;
using AmarisConsulting.Models.ViewModels;
using AmarisConsulting.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmarisConsulting.Repositorios
{
    public class TurnosRepository : ITurnosRepository
    {
        private readonly AmarisConsultingContext _dbContext;

        public TurnosRepository(AmarisConsultingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TurnoResponse>> ObtenerTurnos(int idCliente)
        {
            List<TurnoResponse> turnoResponse = new List<TurnoResponse>();

            var turnos = await _dbContext.Turnos.Where(_turno => _turno.IdCliente == idCliente)
                .Include(_et => _et.EstadosTurno)
                .Include(_s => _s.Sucursales)
                .ToListAsync();

            turnos.ForEach(t =>
            {
                turnoResponse.Add(new TurnoResponse
                {
                    Estado = t.EstadosTurno.Estado,
                    FechaHora = t.FechaHora,
                    Sucursal = new SucursalVM
                    {
                        Direccion = t.Sucursales.Direccion,
                        Nombre = t.Sucursales.Nombre,
                        Telefono = t.Sucursales.Telefono
                    },
                    IdTurno = t.IdTurno
                });
            });

            return turnoResponse;
        }

        public async Task<int> CrearTurno(Turno turno)
        {
            turno.IdEstado = (int)EstadoTurnos.Solicitado;

            _dbContext.Turnos.Add(turno);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Turno> ActivarTurno(int idTurno)
        {
            Turno turno = await _dbContext.Turnos.Where(t => t.IdTurno == idTurno).FirstOrDefaultAsync();

            DateTime fechaLimite = turno.FechaHora.AddMinutes(15);

            if (turno.FechaHora >= fechaLimite)
            {
                turno.IdEstado = (int)EstadoTurnos.Cancelado;

                await CrearTurno(new Turno
                {
                    IdSucursal = turno.IdSucursal,
                    IdCliente = turno.IdCliente,
                    FechaHora = DateTime.Now.AddMinutes(5),
                    IdEstado = (int)EstadoTurnos.Activado
                });
            }
            else
            {
                turno.IdEstado = (int)EstadoTurnos.Activado;
            }

            _dbContext.Turnos.Update(turno);
           await _dbContext.SaveChangesAsync();

            return turno;
        }

        public async Task DesactivarTurno(int turnoId)
        {
            //var turno = await ObtenerTurno(turnoId);

            //turno.IdEstado = (int)EstadoTurnos.Cancelado;

            //_dbContext.Turnos.Update(turno);
            //await _dbContext.SaveChangesAsync();
        }
    }
}
