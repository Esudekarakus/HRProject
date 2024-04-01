using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Project.Application.DTOs;
using Project.Application.Features.CQRS.Commands.EmployeeCommands;
using Project.Application.Features.CQRS.Commands.ExpenseCommands;
using Project.Application.Features.CQRS.Handlers.AdvanceHandlers;
using Project.Application.Features.CQRS.Handlers.CompanyHandlers;
using Project.Application.Features.CQRS.Handlers.EmployeeHandlers;
using Project.Application.Features.CQRS.Handlers.EmployerHandlers;
using Project.Application.Features.CQRS.Handlers.EmployerQueries;
using Project.Application.Features.CQRS.Handlers.ExpenseHandlers;
using Project.Application.Features.CQRS.Handlers.LeaveHandler;
using Project.Application.Repositories.Abstract;
using Project.Application.Services.Abstract;
using Project.Application.Services.Concrete;
using Project.Application.UnitOfWork.Abstract;
using Project.Application.Validation;
using Project.Domain.Entities;
using Project.Persistence.Context;
using Project.Persistence.Repositories.Concrete;
using Project.Persistence.UnitOfWork.Concrete;
using Project.WebApi.DTOs.TokenDTOs.OptionsSetup;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


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

builder.Services.AddScoped<JwtConfiguration>();

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

builder.Services.AddScoped<CreateAdvanceCommandHandler>();
builder.Services.AddScoped<UpdateAdvanceCommandHandler>();
builder.Services.AddScoped<RemoveAdvanceCommandHandler>();
builder.Services.AddScoped<GetAdvanceByEmployeeIdQueryResultHandler>();
builder.Services.AddScoped<GetAdvanceQueryResultHandler>();

builder.Services.AddScoped<CreateLeaveCommandHandler>();
builder.Services.AddScoped<UpdateLeaveCommandHandler>();
builder.Services.AddScoped<RemoveLeaveCommandHandler>();
builder.Services.AddScoped<GetLeaveByEmployeeIdQueryResultHandler>();
builder.Services.AddScoped<GetLeaveQueryResultHandler>();

builder.Services.AddScoped<CreateExpenseCommandHandler>();
builder.Services.AddScoped<RemoveExpenseCommandHandler>();
builder.Services.AddScoped<UpdateExpenseCommandHandler>();
builder.Services.AddScoped<GetExpenseByEmployeeIdQueryHandler>();
builder.Services.AddScoped<GetExpensesWithEmployeesQueryHandler>();

builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAdvanceRepository, AdvanceRepository>();
builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<AddingPersonelValid>();
        fv.RegisterValidatorsFromAssemblyContaining<LoginValidation>();
        fv.RegisterValidatorsFromAssemblyContaining<CreateAdvanceValidation>();
        fv.RegisterValidatorsFromAssemblyContaining<ForgotPasswordValidation>();
        fv.RegisterValidatorsFromAssemblyContaining<AddingEmployerValid>();
    });

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer("Employee", options =>
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
//   });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.UseCors(options => options
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);
app.MapControllers();

app.Run();
