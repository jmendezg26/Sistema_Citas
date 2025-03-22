using Sistema_Citas.AccesoDatos;

namespace Sistema_Citas
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            environment = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton(_ => Configuration);
            services.AddCors(options =>
                options.AddPolicy("AllowWebApp", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod()));
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
            app.UseCors("AllowWebApp");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            BDConexion.SetDBConfiguration(Configuration);

        }
    }

}
