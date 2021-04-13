using Biotronic.Poultry.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Biotronic.Poultry
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            
            services.AddControllers();

            services.AddDbContext<PoultryDbContext>(
                options => options.UseSqlServer());

            /*
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    var authSection = Configuration.GetSection("Authentication:Google");
                    options.ClientId = authSection["ClientId"];
                    options.ClientSecret = authSection["ClientSecret"];
                })
                //.AddFacebook(options =>
                //{
                //    var authSection = Configuration.GetSection("Authentication:Facebook");
                //    options.ClientId = authSection["ClientId"];
                //    options.ClientSecret = authSection["ClientSecret"];
                //})
                ;
            */

            //services.AddCors(c => c.AddDefaultPolicy(cb => cb.AllowAnyOrigin()));
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
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseCors();

            /*
            app.Use((context, next) =>
            {
                context.Items["__CorsMiddlewareInvoked"] = true;
                return next();
            });
            */
        }
    }
}
