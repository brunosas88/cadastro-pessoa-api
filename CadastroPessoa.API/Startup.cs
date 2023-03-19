using CadastroPessoa.API.Data;
using CadastroPessoa.API.Repository;
using CadastroPessoa.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoa.API
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
			services.AddDbContext<Contexto>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped<Contexto, Contexto>();
			services.AddScoped<PessoaService, PessoaService>();
			services.AddScoped<EnderecoService, EnderecoService>();
			services.AddScoped<PessoaRepository,PessoaRepository>();
			services.AddScoped<EnderecoRepository, EnderecoRepository>();
			services.AddCors();
			services.AddControllers();
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Title = "Cadastro de Pessoas API"
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseCors(opcoes => opcoes.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			app.UseSwagger();
			app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));
		}
	}
}
