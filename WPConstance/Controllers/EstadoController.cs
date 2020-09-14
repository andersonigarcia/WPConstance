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
    public class EstadoController : ControllerBase
    {
        readonly ApplicationContext db = new ApplicationContext();
        readonly IMapper _mapper;

        public EstadoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstadoViewModel>>> Get()
        {
            return _mapper.Map<List<EstadoViewModel>>(await db.Estado.AsNoTracking().Where(c => c.Ativo).ToListAsync());
        }

        [HttpGet("{sigla}")]
        public async Task<ActionResult<EstadoViewModel>> Get(string sigla)
        {
            return _mapper.Map<EstadoViewModel>(await db.Estado.AsNoTracking().Where(c => c.Ativo && c.Sigla.ToUpper().Equals(sigla.ToUpper())).FirstOrDefaultAsync());
        }

        [HttpPost]
        public async Task<ActionResult<EstadoViewModel>> Post([FromBody] EstadoCommand estado)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                db.Estado.Add(_mapper.Map<Estado>(estado));

                await db.SaveChangesAsync();

                return Ok(estado);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<EstadoViewModel>> Put(string sigla, [FromBody] EstadoCommand estado)
        {
            if (!ModelState.IsValid) return BadRequest();

            var existe = await db.Estado.AnyAsync(c => c.Sigla.ToUpper().Equals(sigla.ToUpper()));

            if (!existe) return BadRequest("Estado não encontrado na base");

            db.Estado.Update(_mapper.Map<Estado>(estado));

            await db.SaveChangesAsync();

            var result = await db.Estado.FirstAsync(c => c.Sigla.ToUpper().Equals(sigla.ToUpper()));

            if (result == null) return BadRequest();

            return Ok(estado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Estado>> Delete(int id)
        {
            try
            {
                var estado = await db.Estado.FirstOrDefaultAsync(c => c.Id == id);

                if (estado == null) return NotFound();

                db.Estado.Remove(estado);
                await db.SaveChangesAsync();

                return Ok(estado);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
