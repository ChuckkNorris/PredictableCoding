using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Movie.Api.Entities;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using Movie.Api.Errors;

namespace Movie.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            InjectServices(services);
        }


        private void InjectServices(IServiceCollection services) {
            //services.AddTransient<UserService>();
            //services.AddTransient<MovieService>();

            // Retrieve list of types that implement IService
            var serviceTypes = GetAllServiceTypes<IService>();
            
            // Add each service as a transient
            // Since they 
            foreach (var serviceType in serviceTypes) {
                services.AddTransient(serviceType);
            }
        }

        private static IEnumerable<Type> GetAllServiceTypes<T>() {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes().Where(type =>
                typeof(T).IsAssignableFrom(type) && !type.IsInterface
            ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMvc();
        }
    }
}
