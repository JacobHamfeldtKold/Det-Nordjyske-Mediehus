using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NordjyskeMediehus.API.Authentication;
using NordjyskeMediehus.DataAccess.Context;
using NordjyskeMediehus.DataAccess.Implementation;
using NordjyskeMediehus.Domain.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo
    { 
        Title = "Jacobs Api for creating and getting phone numbers",
        Description = "An asp.NET core API that allows you to add peoples phone numbers and names and to retrive the added names and phone numbers",
        Contact = new OpenApiContact
        { 
            Name = "Jacob Hamfeldt Kold",
            Email = "koldjacob.jhk@gmail.com"
        },
        Version = "V1"
    }
    );

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.Xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);


    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "The Api key to access the API",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Name = "x-api-key",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });

    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        { 
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };

    var requirement = new OpenApiSecurityRequirement
    {
        {scheme , new List<string>() }
    };

    c.AddSecurityRequirement(requirement);  
}    
);

// Add entity framework
builder.Services.AddDbContext<NordjyskeMediehusDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NordjyskeMediehusConnection")));
builder.Services.AddTransient<IPersonRepository, PersonRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseMiddleware<ApiKeyAuthMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
