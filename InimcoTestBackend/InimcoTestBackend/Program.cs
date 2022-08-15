using InimcoTestBackend.Application;
using InimcoTestBackend.Application.Input;
using InimcoTestBackend.Application.Response;
using InimcoTestBackend.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserInformationService, UserInformationService>();
builder.Services.AddScoped<IUserInformationRepository, UserInformationFileRepository>();

var app = builder.Build();

app.MapPost("/userinformation",
    async ([FromServices] IUserInformationService service, [FromBody] UserInformationInput userInformationInput) =>
    {
        var (responseCode, exceptions, userInformationFeedback) = await service.AddUserInformationAsync(userInformationInput);
        return responseCode switch
        {
            ResponseCode.Ok => Results.Ok(userInformationFeedback),
            ResponseCode.Other => Results.StatusCode(500),
            ResponseCode.Aggregate 
                => Results.BadRequest(new {ResponseCode = responseCode, Errors = exceptions!.Select(e => e.ResponseCode)}),
            _ => Results.BadRequest(new {ResponseCode = responseCode})
        };
    });

app.Run();
