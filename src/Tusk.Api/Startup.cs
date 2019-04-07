using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tusk.Api.Filters;
using Tusk.Application;
using Tusk.Domain;
using Tusk.Persistence;
using FluentValidation.AspNetCore;
using Tusk.Application.Projects.Commands;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using FluentValidation;

namespace Tusk.Api
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
            // Add MediatR
            services.AddMediatR();
            
            // Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Tusk API", Version = "v1" });
            });

            // Add AutoMapper
            services.AddAutoMapper(cfg => {
                cfg.AddProfiles(new [] {
                    "Tusk.Application"
                });
            });

            // Add Tusk services
            services.AddTransient<IProjectRepository, ProjectRepository>();

            // Add DbContext using SQL Server Provider
            services.AddDbContext<TuskDbContext>(options => 
                options.UseInMemoryDatabase(new Guid().ToString()));

            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilter)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => 
                {
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    fv.RegisterValidatorsFromAssemblyContaining<CreateProjectValidator>();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tusk API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
