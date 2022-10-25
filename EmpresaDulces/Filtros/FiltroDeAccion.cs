using Microsoft.AspNetCore.Mvc.Filters;

namespace EmpresaDulces.Filtros
{
    public class FiltroDeDulcesAccion : IActionFilter
    {
        private readonly ILogger<FiltroDeDulcesAccion> log;

        public FiltroDeDulcesAccion(ILogger<FiltroDeDulcesAccion> log)
        {
            this.log = log;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            log.LogInformation("Antes de ejecutar el filtro de dulces accion");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            log.LogInformation("Despues de ejecutar el filtro de dulces accion");
        }


    }
}