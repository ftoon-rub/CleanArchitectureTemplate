using ApplicationLayer.DependencyInjection;
using CleanArchitectureTemplate;
using PersistenceLayer.Data;
using InfrastructureLayer.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false , reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false )
    .AddEnvironmentVariables();

// Add DbContext
builder.Services.AddDbContext<CustomDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),splOptions =>
    {
        splOptions.MigrationsAssembly("InfrastructureLayer");
    });
});
// Add services to the container.
builder.Services.ReadConfigurations(builder.Configuration);
builder.Services.ApplicationLayerServicesInjection();
builder.Services.InfrastructureLayerServicesInjection();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/",async context =>
{
    await context.Response.WriteAsync("api is up and running...");
});

try
{
    using (IServiceScope scop = app.Services.CreateScope())
    {
        if (builder.Configuration.GetValue<bool>("EnableDatabaseMigration"))
        {
            CustomDbContext dbContext = scop.ServiceProvider.GetRequiredService<CustomDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
    app.Run();
}
catch (Exception)
{

    throw;
}
