using System.Text.Json;
using InimcoTestBackend.Application;
using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Infrastructure;

public class UserInformationFileRepository: IUserInformationRepository
{
    private const string FileName = "UserInformations.json";

    public async Task SaveUserInformationAsync(UserInformation userInformation)
    {
        var userInformations = File.Exists(FileName)
            ? (await GetAllUserInformationsAsync()).ToList()
            : new List<UserInformation>();

        userInformations.Add(userInformation);
        await File.WriteAllTextAsync(FileName,
            JsonSerializer.Serialize(userInformations, new JsonSerializerOptions {WriteIndented = true}));
        Console.WriteLine("UserInformation has been saved successfully");
    }

    public IEnumerable<SocialAccountType> GetSocialAccountTypes()
    {
        return Enum.GetValues<SocialAccountType>();
    }

    public async Task<IEnumerable<UserInformation>> GetAllUserInformationsAsync()
    {
        //The file needs to exist, or an exception will be thrown
        await using var fileStream = File.OpenRead(FileName);
        if (fileStream.Length == 0) return new List<UserInformation>();
        return await JsonSerializer.DeserializeAsync<IEnumerable<UserInformation>>(fileStream) ?? new List<UserInformation>();
    }
    
}