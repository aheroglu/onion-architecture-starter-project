using Server.Application;
using Server.Domain.Entities;
using Server.Persistence;
using Server.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices();

builder.Services
    .AddPersistenceServices(builder.Configuration);

builder.Services
    .AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services
    .AddControllers();

builder.Services
    .AddEndpointsApiExplorer();

builder.Services
    .AddSwaggerGen();

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
