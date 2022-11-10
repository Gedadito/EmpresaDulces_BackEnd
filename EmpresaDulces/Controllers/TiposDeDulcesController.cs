//Creacion del controlador TiposDeDulcesController

using AutoMapper;
using EmpresaDulces.DTOs;
using EmpresaDulces.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpresaDulces.Controllers
{
    [ApiController]
    [Route("api/tipoDulces")]
    public class TiposDeDulcesController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;
        private readonly IMapper mapper;

        public TiposDeDulcesController(AplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }



        [HttpGet("{id:int}")]

        public async Task<ActionResult<TiposDeDulcesDTO>> Get(int id)
        {
            var dulce = await dbContext.Dulces
                .Include(dulcesDB => dulcesDB.DulceInfos)
                .ThenInclude(dulceInfoDB => dulceInfoDB.InformacionDulce)
                .FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<TiposDeDulcesDTO>(dulce);
          
        }

       
        [HttpPost]

        public async Task<ActionResult> Post(TiposDeDulcesCreacionDTO tiposDeDulcesCreacionDTO)
        {
            var dulce = mapper.Map<Dulces>(tiposDeDulcesCreacionDTO);

            dbContext.Add(dulce);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

   
        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(Dulces dulce, int id)
        {
            if (dulce.Id != id)
            {
                return BadRequest("El id del dulce no coincide");
            }

            dbContext.Update(dulce);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

       
        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Dulces.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            dbContext.Remove(new Dulces()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();

        }


        
    }
}
