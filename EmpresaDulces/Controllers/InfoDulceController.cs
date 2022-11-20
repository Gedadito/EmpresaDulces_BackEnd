using EmpresaDulces.Entidades;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;
using EmpresaDulces.Filtros;
using EmpresaDulces.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace EmpresaDulces.Controllers
{

    [ApiController]
    [Route("api/infoDulces")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]

    public class InfoDulceController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;
        private readonly IMapper mapper;

        public InfoDulceController(AplicationDbContext context, IMapper mapper)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<TiposDeDulcesDTO>> Get()
        {
            
            var dulces = await dbContext.InformacionDulces.ToListAsync();
            return mapper.Map<List<TiposDeDulcesDTO>>(dulces);

        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<InfoDulceDTO>> Get(int id)
        {
            var dulce = await dbContext.InformacionDulces.FirstOrDefaultAsync(x => x.Id == id);

            if (dulce == null)
            {
                return NotFound();
            }

            return mapper.Map<InfoDulceDTO>(dulce);
        }

        [HttpGet("{nombre}")]

        public async Task<ActionResult<List<InfoDulceDTO>>> Get(string nombre)
        {
            var dulces = await dbContext.InformacionDulces.Where(x => x.MarcaDeDulce.Contains(nombre)).ToListAsync();

            return mapper.Map<List<InfoDulceDTO>>(dulces);
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] InfoDulceCreacionDTO infoDulceCreacionDTO)
        {
            if(infoDulceCreacionDTO.MarcaId == null)
            {
                return BadRequest("No se puede");
            }

            var marcasId = await dbContext.InformacionDulces.
                Where(marcaBD => infoDulceCreacionDTO.MarcaId.Contains(marcaBD.Id)).Select(x => x.Id).ToListAsync();

            if(infoDulceCreacionDTO.MarcaId.Count != marcasId.Count)
            {
                return BadRequest("No existe");
            }

            var marcaDulce = mapper.Map<InformacionDulce>(infoDulceCreacionDTO);

            dbContext.Add(marcaDulce);
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
