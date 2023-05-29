using TravelPathFinder.Core.Domain;

var builder = WebApplication.CreateBuilder(args);

// Configurar la configuración de la API
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

// Configura los servicios necesarios
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddScoped<IJourneyRoute, JourneyRouteHandler>();
builder.Services.AddControllers();

var app = builder.Build();

var env = app.Services.GetRequiredService<IWebHostEnvironment>();

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hola Mundo");
    });

    endpoints.MapControllers();
});

app.Run();




