using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base.Configuration;
using InformationManagement.Aplication.Core.Administration.Administration.Configurator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InformationManagement.WebApi
{
    public class Startup
    {
        //public IConfiguration Configuration { get; }
        //public IHostEnvironment Environment { get; }
        //public Startup(IHostEnvironment env)
        //{
        //    Environment = env;
        //    var configurationBuilder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json", false, true)
        //        .AddJsonFile($"appsettings{env.EnvironmentName}.json", true, true)
        //        .AddEnvironmentVariables();
        //    //.EnableSubstitutions();
        //    Configuration = configurationBuilder.Build();
        //}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        //aquí falta
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            var dbSettings = Configuration.GetSection("DbConnectionString").Get<string>();
            services.ConfigureAdministrationService(new DbSettings { ConnectionString = dbSettings });
            //services.AddDbContext<ContextoDb>(x => x.UseSqlServer(dbSettings));


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
