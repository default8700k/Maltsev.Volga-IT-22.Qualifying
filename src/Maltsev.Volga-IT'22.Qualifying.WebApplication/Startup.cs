using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.WebEncoders;
using Microsoft.OpenApi.Models;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Maltsev.Volga_IT_22.Qualifying.WebApplication;

public class Startup
{
    private readonly IConfiguration configuration;

    public Startup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });
        services.Configure<WebEncoderOptions>(options => { options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All); });

        services.AddControllersWithViews().AddNewtonsoftJson();

        services.AddSwaggerGenNewtonsoftSupport();
        services.AddSwaggerGen(x =>
        {
            x.EnableAnnotations();
            x.SwaggerDoc("v1", new OpenApiInfo { Title = "Maltsev.Volga-IT'22.Qualifying.WebApplication", Version = "v1" });
        });

        services.AddHealthChecks();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment() == true)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Maltsev.Volga-IT'22.Qualifying.WebApplication v1"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();

            endpoints.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            endpoints.MapHealthChecks("/health/lite", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                Predicate = (check) => !check.Tags.Contains("deep")
            });
        });
    }
}
