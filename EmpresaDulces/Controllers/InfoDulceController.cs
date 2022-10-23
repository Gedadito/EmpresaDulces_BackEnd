using EmpresaDulces.Entidades;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmpresaDulces.Services;

namespace EmpresaDulces.Controllers
{

    [ApiController]
    [Route("api/infoDulces")]
    public class InfoDulceController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;
        private readonly IService service;
        private readonly ServiceTransient serviceTransient;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;
        private readonly ILogger<InfoDulceController> logger;

        public InfoDulceController(AplicationDbContext context, IService service,
            ServiceTransient serviceTransient, ServiceScoped serviceScoped,
            ServiceSingleton serviceSingleton, ILogger<InfoDulceController> logger)
        {
            this.dbContext = context;
            this.service = service;
            this.serviceTransient = serviceTransient;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
            this.logger = logger;
        }

        [HttpGet("GUID")]

        public ActionResult ObtenerGuid()
        {
            return Ok(new
            {
                InfoDulceControllerTransient = serviceTransient.guid,
                ServiceA_Transient = service.GetTransient(),
                InfoDulceControllerScoped = serviceScoped.guid,
                ServiceA_Scoped = service.GetScoped(),
                InfoDulceControllerSingleton = serviceSingleton.guid,
                ServiceA_Singleton = service.GetSingleton()
            });
        }

        [HttpGet]
        [HttpGet("listadoDeDulces-Marca-ID")]
        [HttpGet("/listadoDeDulces-Marca-ID")]

        public async Task<ActionResult<List<InformacionDulce>>> Get()
        {
            logger.LogInformation("Se obtiene el listado de dulces");
            logger.LogWarning("Prueba waring");
            service.EjecutarJob();
            return await dbContext.InformacionDulces.Include(x => x.Sabor).ToListAsync();

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

        public async Task<ActionResult> Post([FromBody]InformacionDulce dulce)
        {
            //Ejemplo para validar desde el controlador haciendo uso de la BD con ayuda del dbContext

            var existeDulceMismaMarca = await dbContext.InformacionDulces.AnyAsync(x => x.MarcaDeDulce == dulce.MarcaDeDulce);

            if (existeDulceMismaMarca)
            {
                return BadRequest("Ya existe dulce con esa Marca");
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
