﻿using Syslog.Api.Filters;
using Syslog.Api.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    options =>
        {
            options.Filters.Add<GlobalExceptionFilter>();
            // options.Filters.Add<ApiResponseFilter>();
        });

builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterService(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();