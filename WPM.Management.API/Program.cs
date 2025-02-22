using Microsoft.EntityFrameworkCore;
using WPM.Management.API.Infrastructure;
using WPM.Management.Domain.Interfaces;
using WPM.Management.Domain.DomainServices;
using WPM.Management.API.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBreedServices, BreedService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBreedServices,BreedService>();
builder.Services.AddScoped<ManagementApplicationService>();
builder.Services.AddScoped<ICommandHandler<SetWeightCommand>,SetWeightCommandHandler>();
builder.Services.AddDbContext<ManagementDBContext>(options =>
{
    options.UseSqlite("Data source=WpmMamagement.db");
});

var app = builder.Build();
app.EnsureDbIsCreate();
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
