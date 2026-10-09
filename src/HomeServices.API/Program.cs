using HomeServices.API.Extensions;
using HomeServices.API.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

// Add Configuration
builder.Configuration.AddEnvironmentVariables();

// Add Services
builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.AddHealthCheckConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwaggerConfiguration();

if (app.Environment.IsDevelopment())
{
    
}
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Middlewares
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();
app.MapHealthCheckEndpoints();

app.Run();
