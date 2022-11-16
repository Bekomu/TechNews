using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechNews.API.Extensions;
using TechNews.Business.AutoMapper.Profiles;
using TechNews.Business.EntityValidation.Admin;
using TechNews.DataAccess.EntityFrameWork.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TechNewsDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

// FluentValidation
builder.Services.Configure<ApiBehaviorOptions>(o =>
{
    o.SuppressModelStateInvalidFilter = true;
});
// FluentValidation


// Automapper
builder.Services.AddAutoMapper(typeof(IProfile).Assembly);
// Automapper


// Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerbuilder => containerbuilder.RegisterModule(new ServiceModuleExtensions()));
// Autofac


// Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<TechNewsDbContext>();
// Identity


// FluentValidation

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateAdminValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// Seed Data
app.SeedDbAsync();
// Seed Data


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
