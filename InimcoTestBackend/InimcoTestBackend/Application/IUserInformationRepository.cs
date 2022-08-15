using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Application;

public interface IUserInformationRepository
{
    public Task SaveUserInformationAsync(UserInformation userInformation);
    public IEnumerable<SocialAccountType> GetSocialAccountTypes();

    public Task<IEnumerable<UserInformation>> GetAllUserInformationsAsync();
}