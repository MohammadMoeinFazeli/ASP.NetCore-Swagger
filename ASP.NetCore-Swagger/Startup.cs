using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ASP.NetCore_Swagger
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Swagger service properties
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Swagger Demo",
                    Description = "Swagger Demo - angular-netcore.ir",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Mohammad Moein Fazeli",
                        Email = "mmfazeli372@gmail.com",
                        Url = "http://www.angular-netcore.ir"
                    }
                });

                // locate the XML file
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "XMLdocument.xml");

                // config swagger to use those XML comments.
                c.IncludeXmlComments(xmlPath);
            });
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}