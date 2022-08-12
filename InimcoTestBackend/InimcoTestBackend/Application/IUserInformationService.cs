using InimcoTestBackend.Application.RequestObjects;
using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Application;

public interface IUserInformationService
{
    public Task<Response<UserInformation>> AddUserInformationAsync(UserInformationInput input);
    public Response<IEnumerable<SocialAccountType>> GetSocialAccountTypes();
}