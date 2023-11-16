using AmarisConsulting.Models;
using AmarisConsulting.Models.ViewModels;

namespace AmarisConsulting.Repositorios.Interfaces
{
    public interface ITurnosRepository
    {
        Task<List<TurnoResponse>> ObtenerTurnos(int idCliente);

        Task<int> CrearTurno(Turno turno);

        Task<Turno> ActivarTurno(int idTurno);
    }
}