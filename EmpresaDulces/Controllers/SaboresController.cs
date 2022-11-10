using AutoMapper;
using EmpresaDulces.DTOs;
using EmpresaDulces.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpresaDulces.Controllers
{
    [ApiController]
    [Route("api/infoDulce/{tasteId:int}/sabores")]

    public class SaboresController : ControllerBase
    {
        private readonly AplicationDbContext context;
        private readonly IMapper mapper;

        public SaboresController(AplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SaborDTO>>> Get(int tasteId)
        {
            var existeDulce = await context.InformacionDulces.AnyAsync(dulceDB => dulceDB.Id == tasteId);

            if (!existeDulce)
            {
                return NotFound();
            }

            var dulces = await context.Sabores
                .Where(dulceDB => dulceDB.TasteId == tasteId).ToListAsync();

            return mapper.Map<List<SaborDTO>>(dulces);
        }
            

        [HttpPost]
        public async Task<ActionResult> Post(int tasteId, SaboresCreacionDTO saboresCreacionDTO)
        {
            var existeDulce = await context.InformacionDulces.AnyAsync(dulceDB => dulceDB.Id == tasteId);

            if (!existeDulce)
            {
                return NotFound();
            }

            var dulce = mapper.Map<Sabor>(saboresCreacionDTO);
            dulce.TasteId = tasteId;
            context.Add(dulce);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
