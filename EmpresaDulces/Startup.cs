using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using EmpresaDulces.Services;
using Microsoft.OpenApi.Models;

namespace EmpresaDulces
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
           
            // Se encarga de configurar ApplicationDbContext como un servicio
            services.AddDbContext<AplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            //Transient da nueva instancia de la clase declarada,
            //sirve para funciones que ejecutan una funcionalidad y listo, sin tener
            //que mantener información que será reutilizada en otros lugares
            services.AddTransient<IService, ServiceA>();
            //services.AddTransient<ServiceA>();
            services.AddTransient<ServiceTransient>();
            //Scoped el tiempo de vida de la clase declarada aumenta, sin embargo, Scoped da diferentes instancia
            //de acuerdo a cada quien mande la solicitud es decir Gustavo tiene su intancia y Alumno otra
            //services.AddScoped<IService, ServiceA>();
            services.AddScoped<ServiceScoped>();
            //Singleton se tiene la misma instancia siempre para todos los usuarios en todos los días,
            //todos los usuarios que hagan una petición van a tener la misma info compartida entre todos 
            //services.AddSingleton<IService, ServiceA>();
            services.AddSingleton<ServiceSingleton>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIAlumnos", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
