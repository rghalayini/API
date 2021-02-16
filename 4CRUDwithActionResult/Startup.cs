using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace _4CRUDwithActionResult
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup (IConfiguration  configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices (IServiceCollection services)
        {
            services.AddControllers();
        }
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
    }
}
