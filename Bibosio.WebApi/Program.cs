using Bibosio.ProductsModule;
using Bibosio.WeatherForecastModule.Endpoints;
using Scalar.AspNetCore;
using Serilog;
using SerilogTracing;

namespace Bibosio.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSerilog(options =>
                options.ReadFrom.Configuration(builder.Configuration));

            using var _ = new ActivityListenerConfiguration()
                .Instrument.AspNetCoreRequests()
                .Instrument.SqlClientCommands()
                .TraceToSharedLogger();
            builder.Services.AddAuthorization();

            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHealthChecks();

            builder.Services.AddProductsModule(builder.Configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapScalarApiReference();
            }

            //app.UseSerilogRequestLogging(options => options.IncludeQueryInRequestPath = true);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseHealthChecks("/healthz");

            app.MapWeatherForecastEndpoint();
            app.MapProductModuleEndpoints();

            app.Run();
        }
    }
}
