﻿


using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Enable CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//JSON Serializer
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(
            options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()
        );
   

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();

