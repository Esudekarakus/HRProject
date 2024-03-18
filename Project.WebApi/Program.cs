using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Project.Application.DTOs;
using Project.Application.Features.CQRS.Commands.EmployeeCommands;
using Project.Application.Features.CQRS.Handlers.CompanyHandlers;
using Project.Application.Features.CQRS.Handlers.EmployeeHandlers;
using Project.Application.Features.CQRS.Handlers.EmployerHandlers;
using Project.Application.Features.CQRS.Handlers.EmployerQueries;

using Project.Application.Repositories.Abstract;
using Project.Application.Services.Abstract;
using Project.Application.Services.Concrete;
using Project.Application.UnitOfWork.Abstract;
using Project.Application.Validation;
using Project.Domain.Entities;
using Project.Persistence.Context;
using Project.Persistence.Repositories.Concrete;
using Project.Persistence.UnitOfWork.Concrete;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
//var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<RoleManager<IdentityRole>>();

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

builder.Services.AddScoped<CreateEmployeeCommand>();


builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<AddingPersonelValid>();
    });

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer("Employer", options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = jwtIssuer,
//            ValidAudience = jwtIssuer,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
//        };
//    });

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
