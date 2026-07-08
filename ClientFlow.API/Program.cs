using ClientFlow.API.Data;
using ClientFlow.API.Entities;
using ClientFlow.API.Contracts;
using ClientFlow.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

/**
 * ==============================================================================================================================
 * ==============================================================================================================================
 * ==============================================================================================================================
 *                                                          SERVICES CONFIG
 * ==============================================================================================================================
 * ==============================================================================================================================
 * ==============================================================================================================================
 */
var builder = WebApplication.CreateBuilder(args);

// Cors config
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(cors => { cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});

// Data config
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper config
builder.Services.AddAutoMapper(o => { }, typeof(Program));

// Controllers config
builder.Services.AddControllers();

// Services config DI
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientNoteService, ClientNoteService>();
builder.Services.AddScoped<IUserService, UserService>();

// Auth services config
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<SignInManager<User>>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication().AddJwtBearer(o =>
{
    o.MapInboundClaims = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["key"]!)),
        ClockSkew = TimeSpan.Zero
    };
});



/**
 * ==============================================================================================================================
 * ==============================================================================================================================
 * ==============================================================================================================================
 *                                                          APP CONFIG
 * ==============================================================================================================================
 * ==============================================================================================================================
 * ==============================================================================================================================
 */
var app = builder.Build();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

/// Minimal Endpoint de prueba
app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
