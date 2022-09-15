//Creacion del controlador TiposDeDulcesController

using EmpresaDulces.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpresaDulces.Controllers
{
    [ApiController]
    [Route("EmpresaDulces")]
    public class TiposDeDulcesController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;

        public TiposDeDulcesController(AplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        
        public async Task<ActionResult<List<Dulces>>> Get()
        {

            return await dbContext.TipoDulce.ToListAsync();

        }

        [HttpPost]

        public async Task<ActionResult> Post(Dulces dulce)
        {
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
            var exist = await dbContext.TipoDulce.AnyAsync(n => n.Id == id);
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
