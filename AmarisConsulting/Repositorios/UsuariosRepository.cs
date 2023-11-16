using AmarisConsulting.Models;
using AmarisConsulting.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmarisConsulting.Repositorios
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly AmarisConsultingContext _dbContext;

        public UsuariosRepository(AmarisConsultingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> Login(Usuario usuario)
        {
            return await _dbContext.Usuarios
                .Where(_usuario => _usuario.NombreUsuario == usuario.NombreUsuario && usuario.Clave == usuario.Clave)
                .Include(_cliente => _cliente.Clientes)
                .FirstOrDefaultAsync();
        }
    }
}
