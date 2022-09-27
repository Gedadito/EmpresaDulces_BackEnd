using EmpresaDulces.Entidades;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpresaDulces.Controllers
{

    [ApiController]
    [Route("api/infoDulces")]
    public class InfoDulceController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;

        public InfoDulceController(AplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        [HttpGet("listadoDeDulces-Marca-ID")]
        [HttpGet("/listadoDeDulces-Marca-ID")]

        public async Task<ActionResult<List<InformacionDulce>>> GetAll()
        {
            return await dbContext.InformacionDulces.ToListAsync();

        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<InformacionDulce>> GetById(int id)
        {
            return await dbContext.InformacionDulces.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpGet("{nombre}")]

        public async Task<ActionResult<InformacionDulce>> Get(string nombre)
        {
            var dulce = await dbContext.InformacionDulces.FirstOrDefaultAsync(x => x.MarcaDeDulce.Contains(nombre));

            if (dulce == null)
            {
                return NotFound();
            }

            return dulce;
        }

        [HttpPost]

        public async Task<ActionResult> Post(InformacionDulce dulce)
        {
            var existeDulce = await dbContext.Dulces.AnyAsync(x => x.Id == dulce.DulceId);

            if (!existeDulce)
            {
                return BadRequest($"No existe dulce con id: {dulce.DulceId} ");
            }

            dbContext.Add(dulce);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

       
        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(InformacionDulce dulce, int id)
        {
            var exist = await dbContext.InformacionDulces.AnyAsync(x => x.Id == id);

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
            var exist = await dbContext.InformacionDulces.AnyAsync(x => x.Id==id);

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
