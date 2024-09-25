using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SimpleCalculator;
using SimpleCalculator.Operations;

namespace SimpleCalculatorApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// Метод для настройки сервисов приложения
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			// Регистрация операций калькулятора
			services.AddTransient<ICalculatorOperation, Addition>();
			services.AddTransient<ICalculatorOperation, Subtraction>();
			services.AddTransient<ICalculatorOperation, Multiplication>();
			services.AddTransient<ICalculatorOperation, Division>();

			// Регистрация калькулятора
			services.AddTransient<Calculator>();

			// Регистрация генератора Swagger для API
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "SimpleCalculator API", Version = "v1" });
			});
		}

		// Метод для настройки HTTP-запросов
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			// Включение middleware для обслуживания Swagger
			app.UseSwagger();

			// Включение middleware для обслуживания Swagger UI
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleCalculator API V1");
				c.RoutePrefix = string.Empty; // Установка Swagger UI на корень приложения
			});
		}
	}
}