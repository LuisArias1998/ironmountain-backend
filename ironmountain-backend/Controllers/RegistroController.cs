using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ironmountain_backend.Models;

namespace ironmountain_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly IronmountainContext _context;

        public RegistroController(IronmountainContext context)
        {
            _context = context;
        }
        [HttpGet]
        
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var getRegistros = await _context.Registros.ToListAsync();
            return Ok(getRegistros);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] Registro request)
        {
            await _context.Registros.AddAsync(request);
            await _context.SaveChangesAsync();
            return Ok(request);
        }
        [HttpPost]
        [Route("addList")]
        public async Task<IActionResult> AddList([FromBody] Registro[] request)
        {
            foreach(Registro reg in request)
            {
                await _context.Registros.AddAsync(reg);
            }
            await _context.SaveChangesAsync();
            return Ok(request);
        }
        [HttpDelete]
        [Route("remove/{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removeRegistro = await _context.Registros.FindAsync(id);
            if (removeRegistro==null)
            {
                return BadRequest("Registro no encontrado");
            }
            _context.Registros.Remove(removeRegistro);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("get/{nombre}")]
        public async Task<IActionResult> GetByName(string nombre)
        {
            var registroList = _context.Registros.Where(registro => registro.Nombre.Contains(nombre)).ToList();
            if (registroList == null)
            {
                return BadRequest("Registro no encontrado");
            }
            return Ok(registroList);
        }
        [HttpPut]
        [Route("put")]
        public async Task<IActionResult> Put([FromBody] Registro request)
        {
            _context.Registros.Update(request);
            _context.SaveChanges();
            return Ok();
        }
    }
}
