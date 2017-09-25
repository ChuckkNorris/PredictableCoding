using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Microsoft.Extensions.DependencyInjection;
namespace NamingIsHard_Code.Project
{
    public class ServiceConfigurator
    {
            public void Configure(IServiceCollection serviceCollection)
            {
                // Auto-generated attributes and controllers
                serviceCollection.AddMvcControllers("*.Feature.*");
                serviceCollection.AddClassesWithServiceAttribute("*.Feature.*");
                serviceCollection.AddClassesWithServiceAttribute("*.Foundation.*");

                // Email Service
                serviceCollection.AddTransient(typeof(Feature.IEmailSignup), new Feature.EmailSignup());

            }
        
    }
}
