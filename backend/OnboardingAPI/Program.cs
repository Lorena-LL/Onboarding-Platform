using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OnboardingAPI.Data;
using OnboardingAPI.Services;
using OnboardingAPI.Services.Interfaces;

DotNetEnv.Env.Load();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITeamMemberService, TeamMemberService>();
builder.Services.AddScoped<IOnboardingTaskService, OnboardingTaskService>();

string jwtKey = builder.Configuration["Jwt:Key"]!;
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Meridian API", Version = "v1" });

    Microsoft.OpenApi.Models.OpenApiSecurityScheme jwtSecurityScheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Description = "Add the JWT token (without 'Bearer ')",
        Reference = new Microsoft.OpenApi.Models.OpenApiReference
        {
            Id = "Bearer",
            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition("Bearer", jwtSecurityScheme);
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

WebApplication app = builder.Build();

// automatic database migration
using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;
    try
    {
        AppDbContext context = services.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occured when applying migrations to database.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();