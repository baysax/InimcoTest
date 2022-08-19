using InimcoTestBackend.Application.Input;
using InimcoTestBackend.Application.Response;
using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Application;

/// <summary>
/// All logic like input validation, error handling... is done here.
/// The service will call the repositories to retrieve/update data.
/// </summary>
public interface IUserInformationService
{
    public Task<Response<UserInformationFeedback>> AddUserInformationAsync(UserInformationInput input);
    public Response<IEnumerable<SocialAccountType>> GetSocialAccountTypes();
}