using Ardalis.GuardClauses;
using InimcoTestBackend.Application.Exceptions;
using InimcoTestBackend.Application.RequestObjects;
using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Application;

public class UserInformationService: IUserInformationService
{
    private readonly IUserInformationRepository _repo;

    public UserInformationService(IUserInformationRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<Response<UserInformation>> AddUserInformationAsync(UserInformationInput input)
    {
        try
        {
            var userInformation = Guard.Against.UserInformationInvalidInput(input);
            Console.WriteLine("UserInformation has been validated succesfully");

            await _repo.SaveUserInformation(userInformation);
            
            return new Response<UserInformation>(userInformation);
        }
        catch (AApplicationException e)
        {
            Console.WriteLine($"Input validation failed: {e.ResponseCode}");
            return new Response<UserInformation>(e.ResponseCode);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unknown exception: {e.Message}");
            return new Response<UserInformation>(ResponseCode.Other);
        }
    }

    public Response<IEnumerable<SocialAccountType>> GetSocialAccountTypes()
    {
        try
        {
            var res = _repo.GetSocialAccountTypes();
            return new Response<IEnumerable<SocialAccountType>>(res);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unknown exception: {e.Message}");
            return new Response<IEnumerable<SocialAccountType>>(ResponseCode.Other);
        }
    }
}