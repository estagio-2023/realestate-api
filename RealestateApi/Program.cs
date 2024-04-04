using RealEstateApi.Helpers;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Repository;
using RealEstateApi.Service.Interfaces;
using RealEstateApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var configuration = builder.Configuration;
configuration.AddUserSecrets<Program>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddNpgsqlDataSource(SecretsHelper.GetDatabaseConnectionString(builder));

builder.Services.AddScoped<IReferenceDataService, ReferenceDataService>();

builder.Services.AddScoped<IReferenceDataRepository, ReferenceDataRepository>();

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

app.Run();