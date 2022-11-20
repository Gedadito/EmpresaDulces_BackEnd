using AutoMapper;
using EmpresaDulces.DTOs;
using EmpresaDulces.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> userManager;

        public SaboresController(AplicationDbContext context,
            IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post(int tasteId, SaboresCreacionDTO saboresCreacionDTO)
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;
            var usuario = await userManager.FindByEmailAsync(email);
            var usuarioId = usuario.Id;
            var existeDulce = await context.InformacionDulces.AnyAsync(dulceDB => dulceDB.Id == tasteId);

            if (!existeDulce)
            {
                return NotFound();
            }

            var dulce = mapper.Map<Sabor>(saboresCreacionDTO);
            dulce.TasteId = tasteId;
            dulce.UsuarioId = usuarioId;
            context.Add(dulce);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
