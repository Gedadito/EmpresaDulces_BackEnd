using Microsoft.AspNetCore.Mvc.Filters;

namespace EmpresaDulces.Filtros
{
    public class FiltroDeDulcesExcepcion : ExceptionFilterAttribute
    {
        private readonly ILogger<FiltroDeDulcesExcepcion> log;

        public FiltroDeDulcesExcepcion(ILogger<FiltroDeDulcesExcepcion> log)
        {
            this.log = log;
        }

        public override void OnException(ExceptionContext context)
        {
            log.LogError(context.Exception, context.Exception.Message);

            base.OnException(context);
        }
    }
}