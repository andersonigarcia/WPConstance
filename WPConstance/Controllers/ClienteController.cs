using AutoMapper;
using ConstanceRepo.Data;
using ConstanceRepo.Domain;
using ConstanceRepo.Dtos.Command;
using ConstanceRepo.Dtos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WPConstance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly IMapper _mapper;
        public ClienteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        readonly ApplicationContext db = new ApplicationContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> Get()
        {
            var listaClientes = await db.Cliente.AsNoTracking()
                .Include(c => c.Estado)
                .Include(b => b.Telefone)
                .Where(c => c.Ativo)
                .ToListAsync();

            return Ok(_mapper.Map<List<ClienteViewModel>>(listaClientes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await db.Cliente.
                AsNoTracking().
                Include(c => c.Estado).
                Include(b => b.Telefone).
                Where(c => c.Id == id).
                FirstOrDefaultAsync();

            return Ok(_mapper.Map<ClienteViewModel>(cliente));
        }

        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> Post([FromBody] ClienteCommand cliente)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                await db.Cliente.AddAsync(_mapper.Map<Cliente>(cliente));

                await db.SaveChangesAsync();

                return Ok(cliente);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> Put(long id, [FromBody]  ClienteCommand cliente)
        {
            if (!ModelState.IsValid) return BadRequest();

            var existe = await db.Cliente.AnyAsync(c => c.Id == id);

            if (!existe) return BadRequest("Cliente não encontrado na base");

            db.Cliente.Update(_mapper.Map<Cliente>(cliente));

            await db.SaveChangesAsync();

            var result = await db.Cliente.FindAsync(id);

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Estado>> Delete(int id)
        {
            try
            {
                var cliente = await db.Cliente.FindAsync(id);

                if (cliente == null) return NotFound();

                db.Cliente.Remove(cliente);

                await db.SaveChangesAsync();

                return Ok(cliente);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
