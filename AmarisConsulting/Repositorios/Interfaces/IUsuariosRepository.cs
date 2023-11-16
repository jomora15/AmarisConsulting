using AmarisConsulting.Models;

namespace AmarisConsulting.Repositorios.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<Usuario> Login(Usuario usuario);
    }
}