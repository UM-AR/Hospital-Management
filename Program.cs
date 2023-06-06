using Hospital_Management;
using Hospital_Management.Repository.IRepository;
using Hospital_Management.Repository.Repository_Class;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using ExceptionHandling.CustomMiddlewares;

var connectionString = "Server=DESKTOP-U3VUOI4; Database=Hospital_DB; Trusted_Connection=True; TrustServerCertificate=True;";
Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.WithThreadId()
            .Enrich.WithProcessId()
            .Enrich.WithEnvironmentName()
            .Enrich.WithMachineName()
            .WriteTo.Console()
            .WriteTo.File("F:\\MY WEB\\Serilog\\Apilog.log")
            .WriteTo.MSSqlServer(
                connectionString: connectionString,
                tableName: "ApiLogs", 
                autoCreateSqlTable: true,
                restrictedToMinimumLevel: LogEventLevel.Information)
            .CreateLogger();
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();


// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IHospitalManager,HospitalRep>();
builder.Services.AddScoped<IPermimssions, PermissionsRep>();
builder.Services.AddScoped<IUserRole, UserRoleRep>();
builder.Services.AddScoped<IRoleAssignment, RoleAssignmetnRep>();
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
       });
});


builder.Services.AddControllers().AddJsonOptions(JsonOptions => { JsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null; });
builder.Services.AddDbContext<HospitalManager>(item => item.UseSqlServer(configuration.GetConnectionString("Hospital_DB")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.UseSwaggerUI();
app.UseSwagger();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MainPage}/{action=MainPage}/{id?}");

app.Run();
