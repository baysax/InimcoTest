using System.Text.Json;
using InimcoTestBackend.Application;
using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Infrastructure;

public class UserInformationFileRepository: IUserInformationRepository
{
    private const string FileName = "UserInformations.json";

    public async Task SaveUserInformation(UserInformation userInformation)
    {
        var userInformations = File.Exists(FileName)
            ? (await GetAllUserInformations()).ToList()
            : new List<UserInformation>();

        userInformations.Add(userInformation);
        await File.WriteAllTextAsync(JsonSerializer.Serialize(userInformations), FileName);
        Console.WriteLine("UserInformation has been saved successfully");
    }

    public IEnumerable<SocialAccountType> GetSocialAccountTypes()
    {
        return Enum.GetValues<SocialAccountType>();
    }

    private static async Task<IEnumerable<UserInformation>> GetAllUserInformations()
    {
        //The file needs to exist, or an exception will be thrown
        await using var fileStream = File.OpenRead(FileName);
        return await JsonSerializer.DeserializeAsync<IEnumerable<UserInformation>>(fileStream) ?? new List<UserInformation>();
    }
    
}