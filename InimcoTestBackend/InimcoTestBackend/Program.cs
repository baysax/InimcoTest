using InimcoTestBackend.Application;
using InimcoTestBackend.Application.RequestObjects;
using InimcoTestBackend.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserInformationService, UserInformationService>();
builder.Services.AddScoped<IUserInformationRepository, UserInformationFileRepository>();

var app = builder.Build();

app.MapPost("/",
    async ([FromServices] IUserInformationService service, [FromBody] UserInformationInput userInformationInput) =>
        (await service.AddUserInformationAsync(userInformationInput)).Item);

app.Run();
