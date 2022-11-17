using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TechNews.API.Extensions;
using TechNews.Authentication.TokenServices.Abstract;
using TechNews.Authentication.TokenServices.Concrete;
using TechNews.Business.Abstract;
using TechNews.Business.AutoMapper.Profiles;
using TechNews.Business.Concrete;
using TechNews.Business.EntityValidation.Admin;
using TechNews.DataAccess.Abstract;
using TechNews.DataAccess.EntityFrameWork.Concrete;
using TechNews.DataAccess.EntityFrameWork.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TechNewsDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("ConStrProd")));


// FluentValidation
builder.Services.Configure<ApiBehaviorOptions>(o =>
{
    o.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddCors();

// Automapper
builder.Services.AddAutoMapper(typeof(IProfile).Assembly);


// Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerbuilder => containerbuilder.RegisterModule(new ServiceModuleExtensions()));


// Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<TechNewsDbContext>()
                .AddDefaultTokenProviders();


// FluentValidation \/
// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateAdminValidator>());


// JWT
builder.Services.AddAuthenticationServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
       {{new OpenApiSecurityScheme
             { Reference = new OpenApiReference
               {
                   Type = ReferenceType.SecurityScheme,
                   Id = "Bearer"
               }
             },
             new string[] {}
       }});
});


var app = builder.Build();


// Seed Data
app.SeedDbAsync();
// Seed Data


app.UseCors(x => x
            .SetIsOriginAllowed(origin => true)
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
