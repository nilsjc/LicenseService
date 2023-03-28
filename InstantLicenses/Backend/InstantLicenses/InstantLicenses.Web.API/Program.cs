using InstantLicenses.Business.Interfaces;
using InstantLicenses.Business.Services;
using InstantLicenses.Core.Interfaces;
using InstantLicenses.DataLayer.DbModels;
using InstantLicenses.DataLayer.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ILicenseDBService<License>, LicenseDBService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
