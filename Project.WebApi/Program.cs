using Microsoft.EntityFrameworkCore;
using Project.Application.Repositories.Abstract;
using Project.Application.UnitOfWork.Abstract;
using Project.Application.UnitOfWork.Concrete;
using Project.Persistence.Context;
using Project.Persistence.Repositories.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("Tarık")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllers();

app.Run();
