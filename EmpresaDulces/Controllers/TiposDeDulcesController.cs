//Creacion del controlador TiposDeDulcesController

using EmpresaDulces.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaDulces.Controllers
{
    [ApiController]
    [Route("EmpresaDulces")]
    public class TiposDeDulcesController : ControllerBase
    {
        [HttpGet]
        
        public ActionResult<List<Dulces>> Get()
        {
            return new List<Dulces>()
            {
                new Dulces() { Id = 1, NombreDelDulce = "Lucas Muecas"},
                new Dulces() { Id = 2, NombreDelDulce = "TutsiPop" }
            };
        }
        
    }
}
