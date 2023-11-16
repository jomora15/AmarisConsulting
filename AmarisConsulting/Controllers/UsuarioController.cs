using AmarisConsulting.Models;
using AmarisConsulting.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AmarisConsulting.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuariosRepository _usuariosRepository;

        public UsuarioController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        [HttpPost]
        [Route("api/usuarios")]
        public async Task<IActionResult> Login([FromBody]UsuarioVM usuarioVM)
        {
            Usuario usuario = new Usuario()
            {
                NombreUsuario = usuarioVM.NombreUsuario,
                Clave = usuarioVM.Clave
            };

            var usuarioResponse = await _usuariosRepository.Login(usuario);

            if (usuarioResponse == null)
            {
                return BadRequest("Usuario o clave incorrecta");
            }
            else
            {
                usuarioVM.IdCliente = usuarioResponse.Clientes.IdCliente;
                usuarioVM.IdUsuario = usuarioResponse.IdUsuario;
                usuarioVM.Nombres = usuarioResponse.Clientes.Nombres;
                usuarioVM.Apellidos = usuarioResponse.Clientes.Apellidos;

                return Ok(usuarioVM);
            }
        }        
    }
}
