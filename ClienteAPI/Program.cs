using ClienteAPI.Data;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using Microsoft.AspNetCore.Builder;  
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;  
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BdClientesContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ClienteDB")));

//HEALTH CHECKS
builder.Services.AddHealthChecks()
    .AddSqlServer(
        connectionString: builder.Configuration.GetConnectionString("ClienteDB"),
        name: "sqlserver",
        failureStatus: HealthStatus.Unhealthy,
        tags: new[] { "database", "sqlserver" }
    );

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClienteAPI", Version = "v1" }); 
}); 

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClienteAPI v1");
    c.RoutePrefix = "swagger";
});

app.UseMetricServer();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseHttpMetrics();
app.MapHealthChecks("/health");
app.MapControllers();

app.Run();