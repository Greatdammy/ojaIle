using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ojaIle.abstraction;
using ojaIle.facade;
using ojaIle.webapi.Controllers.Data;
using ojaIle.webapi.Model;
using OjaIle.data.Models;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddLogging();
//builder.services.
var connectionString  = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ojaileDbContext>(options => 
options.UseSqlServer(connectionString));


builder.Services.AddDbContext<OjaileContext>(options =>
{
    options.UseSqlServer(connectionString, sqlServerOption =>
    {
        sqlServerOption.MigrationsAssembly("Ojaile.Data");
    });
   
});
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
.AddEntityFrameworkStores<ojaileDbContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        //ValidateIssuerSigningKey = true,
        //ValidateIssuer = true,
        //ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]))
    });
//.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => builder.Configuration
//.Bind(nameof(CookieAuthenticationDefaults.AuthenticationScheme), options));

builder.Services.AddScoped<IPropertyUnitService, PropertyUnitService>();

builder.Services.AddScoped<IPropertyItemServices, PropertyItemService>();

////Google Authentication

//builder.Services.AddAuthentication(
//    options =>
//    {
//        options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
//        options.DefaultChallengeScheme = GoogleDefaults.TokenEndpoint;
//    })
//    .AddGoogle(options =>
//    {
//        options.ClientId = "";
//        options.ClientSecret = "";
//    });
////Twitter Authentication 
//builder.Services.AddAuthentication(
//    options =>
//    {
//        options.DefaultAuthenticateScheme = TwitterDefaults.AuthenticationScheme;
//        //options.DefaultChallengeScheme = TwitterDefaults.TokenEndpoint;
//    })
//    .AddTwitter(options =>
//    {
//        options.ConsumerKey = "";
//        options.ConsumerSecret = "";
//    });
////Facebook Authentication
//builder.Services.AddAuthentication(
//    options =>
//    {
//        options.DefaultAuthenticateScheme = FacebookDefaults.AuthenticationScheme;
//        options.DefaultChallengeScheme = FacebookDefaults.TokenEndpoint;
//    })
//    .AddFacebook(options =>
//    {
//        options.AppId = "";
//        options.AppSecret = "";
//    });

builder.Services.AddLogging();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();



app.MapControllers();

app.Run();
