using Ardalis.GuardClauses;
using InimcoTestBackend.Application.Exceptions;
using InimcoTestBackend.Application.Input;
using InimcoTestBackend.Application.Response;
using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Application;

public class UserInformationService: IUserInformationService
{
    private readonly IUserInformationRepository _repo;

    public UserInformationService(IUserInformationRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<Response<UserInformationFeedback>> AddUserInformationAsync(UserInformationInput input)
    {
        try
        {
            var userInformation = Guard.Against.UserInformationInvalidInput(input);
            Console.WriteLine("UserInformation has been validated succesfully");

            await _repo.SaveUserInformationAsync(userInformation);
            
            return new Response<UserInformationFeedback>(new UserInformationFeedback(userInformation));
        }
        catch (AApplicationException e)
        {
            Console.WriteLine($"Input validation failed: {e.ResponseCode}");
            if (e is AggregateApplicationException)
            {
                var ex = e as AggregateApplicationException;
                return new Response<UserInformationFeedback>(ex!.ResponseCode, ex.Exceptions);
            }
            return new Response<UserInformationFeedback>(e.ResponseCode, null);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unknown exception: {e.Message}");
            return new Response<UserInformationFeedback>(ResponseCode.Other, null);
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
            return new Response<IEnumerable<SocialAccountType>>(ResponseCode.Other, null);
        }
    }
}