using FluentValidation.AspNetCore;
using JwtDemo.Service.DependencyResolvers;
using JwtDemo.WebAPI.CustomFilters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(ValidId<>));
builder.Services.AddDependencies(builder.Configuration);

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

app.UseAuthorization();
app.MapControllers();
app.Run();
