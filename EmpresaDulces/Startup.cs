using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json.Serialization;

using Microsoft.OpenApi.Models;
using EmpresaDulces.Middlewares;
using EmpresaDulces.Filtros;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace EmpresaDulces
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opciones =>
            {
                opciones.Filters.Add(typeof(FiltroDeDulcesExcepcion));
            }).AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
           
            // Se encarga de configurar ApplicationDbContext como un servicio
            services.AddDbContext<AplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(opciones => opciones.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = false,
                                ValidateAudience = false,
                                ValidateLifetime = false,
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey(
                                    Encoding.UTF8.GetBytes(Configuration["llavejwt"])),
                                ClockSkew = TimeSpan.Zero
                            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmpresaDulces", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id ="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

            });

            services.AddAutoMapper(typeof(Startup));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(opciones =>
            {
                opciones.AddPolicy("EsAdmin", politica => politica.RequireClaim("esAdmin"));
            });

            services.AddCors(opciones =>
            {
                opciones.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://apirequest.io").AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            //Use me permite agregar mi propio proceso sin afectar a los demas como Run
            //app.Use(async (context, siguiente) =>
            //{
            //    using (var ms = new MemoryStream())
            //    {
            //        //Se asigna el body del response en una variable y se le da el valor de memorystream
            //        var bodyOriginal = context.Response.Body;
            //        context.Response.Body = ms;

            //        //Permite continuar con la linea
            //        await siguiente.Invoke();

            //        //Guardamos lo que le respondemos al cliente en el string
            //        ms.Seek(0, SeekOrigin.Begin);
            //        string response = new StreamReader(ms).ReadToEnd();
            //        ms.Seek(0, SeekOrigin.Begin);

            //        //Leemos el stream y lo colocamos como estaba
            //        await ms.CopyToAsync(bodyOriginal);
            //        context.Response.Body = bodyOriginal;

            //        logger.LogInformation(response);
            //    }
            //});

            //Metodo para utilizar la clase middleware propia
            //app.UseMiddleware<ResponseHttpMiddleware>();

            //Metodo para utilizar la clase middleware sin exponer la clase. 
            //app.UseResponseHttpMiddleware();


            //Atrapara todas las peticiones http que mandemos y retornar un string
            //Para detener todos los otros middleware se utiliza la funcion RUN

            //Para condicionar la ejecucion del middleware segun una ruta especifica se utiliza Map
            //Al utilizar Map permite que en lugar de ejecutar linealmente podemos agregar rutas especificas para
            // nuestro middleware
            


            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
