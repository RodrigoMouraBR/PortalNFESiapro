using MediatR;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using PortalNFE.Api.Configuration;
using PortalNFE.Identity.Application.AutoMapper;
using PortalNFE.Identity.Application.Extensions;
using PortalNFE.Identity.Data.Context;
using PortalNFE.Register.Companies.Application.AutoMapper;
using PortalNFE.Register.Companies.Data.Context;
using PortalNFE.Register.Users.Application.AutoMapper;
using PortalNFE.Register.Users.Data.Context;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

#region Connections DB

builder.Services.AddIdentityConnectionUseNpgsql(builder.Configuration);
builder.Services.AddCompanyConnectionUseNpgsql(builder.Configuration);
builder.Services.AddUserPersonConnectionUseNpgsql(builder.Configuration);

#endregion

#region Configuration

builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddApiConfig();
builder.Services.AddSwaggerConfig();

#endregion

#region IoC

builder.Services.ResolveDependencies();

#endregion

#region AutoMapper

builder.Services.AddAutoMapper(typeof(AutoMapperCompaniesConfig), 
                               typeof(AutoMapperUserPersonConfig), 
                               typeof(AutomapperIdentityConfig));

#endregion

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure
app.UseApiConfig(app.Environment);
app.UseSwaggerConfig(apiVersionDescriptionProvider);
app.Run();


