using FindArt.Api.Extensions;
using FindArt.Core;
using FindArt.Root;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindArt.Api
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
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
					builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());
			});

			services.ConfigureSqlContext(Configuration);

			services.AddAutoMapper(typeof(MappingProfile));

			services.AddAuthentication();

			services.ConfigureIdentity();

			services.ConfigureJWT(Configuration);

			services.InjectAllServices();

			services.InjectAllActionFilters();

			services.ConfigureResponseCaching();

			services.AddControllers(config =>
				{
					config.CacheProfiles.Add("120SecondsDuration", new CacheProfile { Duration = 120 });
				})
				.AddFluentValidation(s => 
				{ 
					s.RegisterValidatorsFromAssemblyContaining<Startup>(); 
					s.RunDefaultMvcValidationAfterFluentValidationExecutes = false; 
				})
				.AddNewtonsoftJson();

			services.ConfigureSwagger();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.ConfigureExceptionHandler();

			app.UseCors("CorsPolicy");

			app.UseResponseCaching();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();
			app.UseSwaggerUI(s =>
			{
				s.SwaggerEndpoint("/swagger/v1/swagger.json", "FindArt");
			});
		}
	}
}
