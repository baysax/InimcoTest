using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Application;

public interface IUserInformationRepository
{
    public Task SaveUserInformation(UserInformation userInformation);
    public IEnumerable<SocialAccountType> GetSocialAccountTypes();
}