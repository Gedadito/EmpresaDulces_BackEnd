namespace EmpresaDulces.Services
{
    public class EscribirEnArchivoDulces : IHostedService
    {
        private readonly IWebHostEnvironment env;
        private readonly string nombreArchivo = "ArchivoDulcesGERA1";
        private Timer timer;

        public EscribirEnArchivoDulces(IWebHostEnvironment env)
        {
            this.env = env;

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Se ejecuta cuando cargamos la aplicacion 1 vez
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(4));
            Escribir("Proceso archivo dulces Iniciado");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Se ejecuta cuando detenemos la aplicacion aunque puede que no se ejecute por algun error. 
            timer.Dispose();
            Escribir("Proceso archivo dulces Finalizado");
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Escribir("Proceso en ejecucion archivo dulces: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            
        }
        private void Escribir(string msg)
        {
            var ruta = $@"{env.ContentRootPath}\wwwroot\{nombreArchivo}";
            using (StreamWriter writer = new StreamWriter(ruta, append: true)) { writer.WriteLine(msg); }
        }

    }
}