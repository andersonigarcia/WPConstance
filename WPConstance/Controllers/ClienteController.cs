using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConstanceRepo.Data;
using ConstanceRepo.Domain;
using Microsoft.EntityFrameworkCore;

namespace WPConstance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly ApplicationContext db = new ApplicationContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            var listaClientes = await db.Cliente.AsNoTracking()
                .Include(c => c.Estado)
                .Include(b => b.Telefone)
                .Where(c => c.Ativo)
                .ToListAsync();

            return Ok(listaClientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            return await db.Cliente.AsNoTracking()
                .Include(c => c.Estado)
                .Include(b => b.Telefone)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Post([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid) return BadRequest();

            db.Cliente.Add(cliente);

            db.SaveChanges();

            var result = await db.Cliente.AnyAsync(c => c.Id == cliente.Id);

            if (!result) return BadRequest();

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> Put([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid) return BadRequest();

            db.Cliente.Update(cliente);

            db.SaveChanges();

            var result = await db.Cliente.AnyAsync(c => c.Id == cliente.Id);

            if (!result) return BadRequest();

            return Ok(cliente);
        }

        [HttpDelete("{id}")]        
        public async Task<ActionResult<Estado>> Delete(int id)
        {
            var cliente = await db.Cliente.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null) return NotFound();

            db.Cliente.Remove(cliente);

            db.SaveChanges();

            return Ok(cliente);
        }
    }
}
