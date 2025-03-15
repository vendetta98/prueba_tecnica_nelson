using backendC_.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace backendC_.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/tienda")]

    public class globalController : ControllerBase
    {
        private readonly nombre_apellido_dbContext _context;

        public globalController(nombre_apellido_dbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tiendum>>> GetAll() {
            return Ok(await _context.Tienda.ToListAsync());
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/empleados")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return Ok(await _context.Empleados.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetById(int id) {
            var empleados = _context.Empleados.FindAsync(id);
            if (empleados != null) {
                return Ok(empleados);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var empleado = await _context.Tienda.FindAsync(id);
            _context.Remove(empleado);
            await _context.SaveChangesAsync();
            return Ok(empleado);
        }
    }
}
