
using Microsoft.EntityFrameworkCore;
using Project.Application.Features.CQRS.Handlers.CompanyHandlers;
using Project.Application.Features.CQRS.Handlers.EmployeeHandlers;
using Project.Application.Features.CQRS.Handlers.EmployerHandlers;
using Project.Application.Features.CQRS.Handlers.EmployerQueries;

using Project.Application.Repositories.Abstract;
using Project.Application.UnitOfWork.Abstract;

using Project.Persistence.Context;
using Project.Persistence.Repositories.Concrete;
using Project.Persistence.UnitOfWork.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("connectionStr")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


builder.Services.AddScoped<GetEmployerQueryHandler>();
builder.Services.AddScoped<GetEmployerByIdQueryHandler>();
builder.Services.AddScoped<CreateEmployerCommandHandler>();
builder.Services.AddScoped<UpdateEmployerCommandHandler>();
builder.Services.AddScoped<RemoveEmployerCommandHandler>();
builder.Services.AddScoped<GetEmployerWithCompanyQueryResultHandler>();
builder.Services.AddScoped<GetEmployerByIdWithCompanyQueryHandler>();

builder.Services.AddScoped<CreateCompanyCommandHandler>();
builder.Services.AddScoped<UpdateCompanyCommandHandler>();
builder.Services.AddScoped<RemoveCompanyCommandHandler>();
builder.Services.AddScoped<GetCompanyByIdQueryHandler>();
builder.Services.AddScoped<GetCompanyQueryHandler>();

builder.Services.AddScoped<CreateEmployeeCommandHandler>();
builder.Services.AddScoped<UpdateEmployeeCommandHandler>();
builder.Services.AddScoped<RemoveEmployeeCommandHandler>();
builder.Services.AddScoped<GetEmployeeByIdWithCompanyHandler>();
builder.Services.AddScoped<GetEmployeeWithCompanyHandler>();


builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

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
