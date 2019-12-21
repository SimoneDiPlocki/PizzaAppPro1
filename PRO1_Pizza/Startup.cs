using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PRO1_Pizza.Models;

namespace PRO1_Pizza
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
            services.AddDbContext<s16695Context>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
               {
                   Title = "Pizza App API",
                   Version = "v1"
               });

               var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
               var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

               c.IncludeXmlComments(xmlPath);


           });
        }

        private XPathDocument xmlPath()
        {
            throw new NotImplementedException();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaAppSwagger");
            });
            app.UseMvc();
        }
    }
}
