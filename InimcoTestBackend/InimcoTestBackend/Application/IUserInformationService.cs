using InimcoTestBackend.Application.Input;
using InimcoTestBackend.Application.Response;
using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Application;

public interface IUserInformationService
{
    public Task<Response<UserInformationFeedback>> AddUserInformationAsync(UserInformationInput input);
    public Response<IEnumerable<SocialAccountType>> GetSocialAccountTypes();
}