using InimcoTestBackend.Application;
using InimcoTestBackend.Application.Input;
using InimcoTestBackend.Application.Response;
using InimcoTestBackend.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy =>
        {
            policy
                .WithOrigins("http://localhost:4200", "http://localhost:5400")
                .WithHeaders(HeaderNames.ContentType, "*/*");
        });
});

builder.Services.AddScoped<IUserInformationService, UserInformationService>();
builder.Services.AddScoped<IUserInformationRepository, UserInformationFileRepository>();

var app = builder.Build();
app.UseCors(x => x.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

app.MapPost("/userinformation",
    async ([FromServices] IUserInformationService service, [FromBody] UserInformationInput userInformationInput) =>
    {
        var res = await service.AddUserInformationAsync(userInformationInput);
        return CreateResult(res);
    });

app.MapGet("/socialaccounttypes", ([FromServices] IUserInformationService service) =>
{
    var res = service.GetSocialAccountTypes();
    return CreateResult(res);
});

app.Run();

IResult CreateResult<T>(Response<T> response)
{
    var (responseCode, aApplicationExceptions, item) = response;
    return responseCode switch
    {
        ResponseCode.Ok => Results.Ok(item),
        ResponseCode.Other => Results.StatusCode(500),
        ResponseCode.Aggregate
            => Results.BadRequest(new
                {ResponseCode = responseCode, Errors = aApplicationExceptions!.Select(e => e.ResponseCode)}),
        _ => Results.BadRequest(new {ResponseCode = responseCode})
    };
}