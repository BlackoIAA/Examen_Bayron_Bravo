using Api_Taller_Mecanicos.Data;
using Api_Taller_Mecanicos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Taller_Mecanicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecanicoController : ControllerBase
    {
        private readonly APITallerDbContext _context;

        public MecanicoController(APITallerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mecanicos>>> GetMecanico()
        {
            // Retorna la lista de mecánicos en la base de datos
            return Ok(await _context.Mecanico.ToListAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<Mecanicos> GetCliente(int id)
        {
            // Busca un mecánico por su ID en la base de datos
            var mecanico = _context.Mecanico.Find(id);

            if (mecanico == null)
            {
                return NotFound(); // Si no se encuentra el mecánico, retorna un error 404
            }

            return Ok(mecanico); // Retorna el mecánico si se encuentra
        }

        [HttpPost]
        public async Task<ActionResult<Mecanicos>> Create(Mecanicos mecanico)
        {
            // Crea un nuevo mecánico en la base de datos.
            _context.Add(mecanico);
            await _context.SaveChangesAsync();

            return Ok(mecanico); // Retorna el mecánico recién creado.
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Mecanicos mecanico)
        {
            if (id != mecanico.IdMecanico)
            {
                return BadRequest(); // Si el ID proporcionado no coincide con el ID del mecanico, retorna un error
            }

            // Actualiza el mecánico en la base de datos.
            _context.Entry(mecanico).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(mecanico); // Retorna el mecanico actualizado.
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Busca el mecánico por su ID en la base de datos.
            var mecanico = await _context.Mecanico.FindAsync(id);

            if (mecanico == null)
            {
                return NotFound("No está correcto el ID del mecánico."); // Si no se encuentra el mecanico, retorna un error
            }

            // Elimina el mecanico de la base de datos.
            _context.Mecanico.Remove(mecanico);
            await _context.SaveChangesAsync();

            return Ok(); // Retorna un Ok indicando que la operación fue exitosa.
        }
    }
}