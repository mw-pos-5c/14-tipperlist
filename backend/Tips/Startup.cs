using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using Tips.Services;
using TipsDb;

namespace Tips
{
  public class Startup
  {
    private readonly string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
    private const string swaggerVersion = "v1";
    private const string swaggerTitle = "Tipps";

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      string dataDirKey = "|DataDirectory|";
      string connectionString = Configuration.GetConnectionString("TipsSqlite");
      //string assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
      string assemblyLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
      string dataDirectory = System.IO.Path.GetDirectoryName(assemblyLocation);
      if (connectionString.Contains(dataDirKey)) connectionString = connectionString.Replace(dataDirKey, dataDirectory);
      Console.WriteLine($"connectionString={connectionString}");
      services.AddDbContext<TipsContext>(options => options.UseSqlite(connectionString));

      services.AddScoped<TipsService>();
      services.AddScoped<DbPopulationService>();
      services.AddScoped<AdminService>();

      services.AddCors(options =>
      {
        options.AddPolicy(myAllowSpecificOrigins,
            x => x.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
          );
      });
      services.AddSwaggerGen(x =>
      {
        x.SwaggerDoc(swaggerVersion, new OpenApiInfo
        {
          Title = swaggerTitle,
          Version = swaggerVersion
        });
      });

      services.AddMvc(options => options.EnableEndpointRouting = false);
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      Console.WriteLine("UseSwagger");
      app.UseSwagger();
      app.UseSwaggerUI(x =>
      {
        x.SwaggerEndpoint(
          $"/swagger/{swaggerVersion}/swagger.json",
          swaggerTitle);
      });

      app.UseCors(myAllowSpecificOrigins);

      app.UseExceptionHandler(config =>
      {
        config.Run(async context =>
        {
          context.Response.StatusCode = 500;
          context.Response.ContentType = "application/json";
          var error = context.Features.Get<IExceptionHandlerFeature>();
          if (error != null)
          {
            await context.Response.WriteAsync(
              $"Exception: {error.Error?.Message} {error.Error?.InnerException?.Message}");
          }
        });
      });

      app.UseMvc();
    }
  }
}
