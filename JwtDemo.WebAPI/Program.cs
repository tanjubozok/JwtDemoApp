using FluentValidation.AspNetCore;
using JwtDemo.Service.DependencyResolvers;
using JwtDemo.WebAPI.CustomFilters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(ValidIdAttribute<>));
builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.RequireHttpsMetadata = false;
        opt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = "http://localhost",
            ValidAudience = "http://localhost",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tanjutanjutanju1")),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/Error");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
