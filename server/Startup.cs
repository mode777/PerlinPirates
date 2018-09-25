using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Endobit.DomainDrivenDesign;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorldServer.Entities;
using WorldServer.EventHandlers;
using WorldServer.Events;
using WorldServer.Services;

namespace WorldServer
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSignalR();

            services.AddScoped<DbContext, WorldDbContext>();
            services.AddDbContext<WorldDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IRepository<WorldEntity>, EfRepository<WorldEntity>>();
            services.AddScoped<ChunkManager>();
            services.AddSingleton<FractalService>();

            services.AddEventPublisher()
                .AddHandler<WorldEntityEvent, WorldEntityEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ConfigureAppDatabase(app);

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
                x.AllowCredentials();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSignalR(routes =>
            {
                routes.MapHub<WorldHub>("");
            });
        }

        private void ConfigureAppDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DbContext>();
                context.Database.Migrate();
            }
        }
    }
}
