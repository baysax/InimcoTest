using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Application;

/// <summary>
/// The repository, here the actual retrieving/editing of the data is done. 
/// </summary>
public interface IUserInformationRepository
{
    public Task SaveUserInformationAsync(UserInformation userInformation);
    public IEnumerable<SocialAccountType> GetSocialAccountTypes();

    public Task<IEnumerable<UserInformation>> GetAllUserInformationsAsync();
}