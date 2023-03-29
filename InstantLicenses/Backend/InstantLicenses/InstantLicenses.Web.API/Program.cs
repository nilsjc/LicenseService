using InstantLicenses.Business.Interfaces;
using InstantLicenses.Business.Services;
using InstantLicenses.Core.Interfaces;
using InstantLicenses.DataLayer.DbModels;
using InstantLicenses.DataLayer.Services;
using Microsoft.Extensions.Options;
var allowedsite = "_allowedsite";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedsite,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000");
        });
});
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
app.UseCors(allowedsite);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
