using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System;
using ClinicManager.Infrastructure.Persistence;
using ClinicManagerAPI.Repositories.Interface;
using ClinicManager.Infrastructure.Persistence.Repositories;
using ClinicManagerAPI.Entities;
using Microsoft.Extensions.Options;
using Twilio.TwiML.Voice;
using MediatR;
using ClinicManager.Application.Commands.CreateDoctorCommand;
using ClinicManager.Application.Commands.CreatePatientCommand;
using ClinicManager.Application.Commands.CreateServiceClinicCommand;
using ClinicManager.Application.Commands.CreateServiceCommand;
using ClinicManager.Application.Queries.GetIdDoctor;
using ClinicManager.Application.Queries.GetIdPatient;
using ClinicManager.Application.Queries.GetIdServiceClinic;
using ClinicManager.Application.Queries.GetIdService;
using FluentValidation;
using ClinicManagerAPI.Validators;
using ClinicManagerAPI.DTO_s;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Web.WebPages;
using ClinicManager.Application.Email;

var builder = WebApplication.CreateBuilder(args);

string chaveSecreta = "6baf3137-314c-4af5-90cf-24b86066eb65";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ClinicManager - API", Version = "v1" });

    var securitySchems = new OpenApiSecurityScheme
    {
        Name = "JWT Autenticação",
        Description = "Entre com o JWT Bearer Token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    x.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchems);
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securitySchems, new string[] { } }
            });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "ClinicManager",
        ValidAudience = "ClinicManager",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta))
    };
});

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<AppDbContext>(p => p.UseSqlServer(connectionString));

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CreateDoctorCommand)));
builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CreatePatientCommand)));
builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CreateServiceClinicCommand)));
builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CreateServiceCommand)));


builder.Services.AddValidatorsFromAssemblyContaining<AttachmentCreateDTOValidator>().AddFluentValidationAutoValidation();
builder.Services.AddTransient<IValidator<AttachmentCreateDTO>, AttachmentCreateDTOValidator>();


builder.Services.AddTransient<IRequestHandler<GetDoctorByIdQuery, Doctor>, GetDoctorByIdQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetPatientByIdQuery, Patient>, GetPatientByIdQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetServiceByIdQuery, Service>, GetServiceByIdQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetServiceClinicByIdQuery, ServiceClinic>, GetServiceClinicByIdQueryHandler>();


builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IServiceClinicRepository, ServiceClinicRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IAttachmentRepository, AttachmentRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddLogging();

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
