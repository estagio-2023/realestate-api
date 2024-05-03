using RealEstateApi.Helpers;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Repository;
using RealEstateApi.Service.Interfaces;
using RealEstateApi.Service;
using FluentValidation.AspNetCore;
using RealEstateApi.Dto.Request;
using RealEstateApi.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();

var configuration = builder.Configuration;
configuration.AddUserSecrets<Program>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddNpgsqlDataSource(SecretsHelper.GetDatabaseConnectionString(builder));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});

builder.Services.AddScoped<IValidator<ReferenceDataRequestDto>, AddReferenceDataValidator>();
builder.Services.AddScoped<IValidator<CustomerRequestDto>, AddCustomerValidator>();
builder.Services.AddScoped<IValidator<AddRealEstateRequestDto>, AddRealEstateValidator>();

ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;

builder.Services.AddScoped<IReferenceDataService, ReferenceDataService>();
builder.Services.AddScoped<IRealEstateService, RealEstateService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IRealEstateRepository, RealEstateRepository>();
builder.Services.AddScoped<IReferenceDataRepository, ReferenceDataRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();