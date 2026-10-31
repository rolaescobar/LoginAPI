using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginApi.Models;

namespace LoginApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly LoginContext _context;

        // Inyección de dependencias del contexto de base de datos
        public UsuariosController(LoginContext context)
        {
            _context = context;
        }

        // GET: api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            // Retorna la lista de usuarios en formato JSON
            return await _context.Usuarios.ToListAsync();
        }
    }
}
