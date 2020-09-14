using ConstanceRepo.Data;
using ConstanceRepo.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPConstance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        readonly ApplicationContext db = new ApplicationContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> Get()
        {
            return await db.Estado.AsNoTracking().Where(c => c.Ativo).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> Get(int id)
        {
            return await db.Estado.AsNoTracking().Where(c => c.Ativo && c.Id == id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Estado>> Post([FromBody] Estado estado)
        {
            if (!ModelState.IsValid) return BadRequest();

            db.Estado.Add(estado);

            db.SaveChanges();

            var result = db.Estado.Any(c => c.Id == estado.Id);

            if (!result) return BadRequest();

            return Ok(estado);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Estado>> Put([FromBody] Estado estado)
        {
            if (!ModelState.IsValid) return BadRequest();

            db.Estado.Update(estado);

            db.SaveChanges();

            var result = await db.Estado.AnyAsync(c => c.Id == estado.Id);

            if (!result) return BadRequest();

            return Ok(estado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Estado>> Delete(int id)
        {
            var estado = await db.Estado.FirstOrDefaultAsync(c => c.Id == id);

            if (estado == null) return NotFound();

            db.Estado.Remove(estado);
            db.SaveChanges();

            return Ok(estado);
        }
    }
}
