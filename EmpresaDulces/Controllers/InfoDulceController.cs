using EmpresaDulces.Entidades;
using EmpresaDulces.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpresaDulces.Controllers
{

    [ApiController]
    [Route("InfoDulces")]
    public class InfoDulceController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;

        public InfoDulceController(AplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<InformacionDulce>>> GetAll()
        {
            return await dbContext.InfoDulce.ToListAsync();

        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<InformacionDulce>> GetById(int id)
        {
            return await dbContext.InfoDulce.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]

        public async Task<ActionResult> Post(InformacionDulce dulce)
        {
            var existeDulce = await dbContext.InfoDulce.AnyAsync(x => x.Id == dulce.DulceId);

            if (!existeDulce)
            {
                return BadRequest($"No existe dulce con id; {dulce.DulceId} ");
            }

            dbContext.Add(dulce);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(InformacionDulce dulce, int id)
        {
            var exist = await dbContext.InfoDulce.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El dulce no existe");
            }

            if (dulce.DulceId == id)
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
            var exist = await dbContext.InfoDulce.AnyAsync(x => x.Id==id);

            if (!exist)
            {
                return NotFound("No se encontro el recurso");
            }

            dbContext.Remove(new InformacionDulce { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
