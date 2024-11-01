using ApplicationLayer.DependencyInjection;
using CleanArchitectureTemplate;
using PersistenceLayer.Data;
using InfrastructureLayer.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using InfrastructureLayer.Security.Authentication;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false)
    .AddEnvironmentVariables();

// Add DbContext
builder.Services.AddDbContext<CustomDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), splOptions =>
    {
        splOptions.MigrationsAssembly("PersistenceLayer");
    });
});
// Add services to the container.
builder.Services.ReadConfigurations(builder.Configuration);
builder.Services.ApplicationLayerServicesInjection();
builder.Services.InfrastructureLayerServicesInjection();

builder.Services.AddControllers();

#region addAuth basic and jwt
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = bool.Parse(builder.Configuration["CustomAuthenticate:JwtBearer:ValidateIssuer"]),
        ValidateAudience = bool.Parse(builder.Configuration["CustomAuthenticate:JwtBearer:ValidateAudience"]),
        ValidateLifetime = bool.Parse(builder.Configuration["CustomAuthenticate:JwtBearer:ValidateLifetime"]),
        ValidateIssuerSigningKey = bool.Parse(builder.Configuration["CustomAuthenticate:JwtBearer:ValidateIssuerSigningKey"]),
        ValidIssuer = builder.Configuration["CustomAuthenticate:JwtBearer:ValidIssuer"],
        ValidAudience = builder.Configuration["CustomAuthenticate:JwtBearer:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["CustomAuthenticate:Password"]))
    };
});

builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
#endregion
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        Description = "Input your username and password to access this API."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Basic"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", async context =>
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
