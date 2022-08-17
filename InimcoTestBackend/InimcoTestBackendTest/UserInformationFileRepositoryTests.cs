using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InimcoTestBackend.Application;
using InimcoTestBackend.Domain;
using InimcoTestBackend.Infrastructure;
using NUnit.Framework;

namespace InimcoTestBackendTest;

public class UserInformationFileRepositoryTests
{
    private static readonly IUserInformationRepository Repo = new UserInformationFileRepository();
    private const string FileName = "UserInformations.json";

    [SetUp]
    public void Setup()
    {
        if(File.Exists(FileName))
            File.Delete(FileName);
    }

    #region SaveUserInformationAsync
    
    [Test]
    public void SaveUserInformationAsync_FileDoesNotExist_FileCreatedSuccessFully()
    {
        var userInformation = CreateValidUserInformation();

        //Don't await this, because the check needs to happen sequentially after the save
        Repo.SaveUserInformationAsync(userInformation);
        
        Assert.IsTrue(File.Exists(FileName), $"The file {FileName} was not created");
    }

    [Test]
    public async Task SaveUserInformationAsync_CorrectDataIsSaved()
    {
        var userInformation = CreateValidUserInformation();

        await Repo.SaveUserInformationAsync(userInformation);

        var userInformations = await Repo.GetAllUserInformationsAsync();
        var informations = userInformations as UserInformation[] ?? userInformations.ToArray();
        Assert.IsTrue(informations.Length == 1, "There were multiple UserInformations in the file (file should be deleted before each test)");
        var created = informations.First();
        Assert.AreEqual("Sander", created.FirstName, "Incorrect first name");
        Assert.AreEqual("De Cock", created.LastName, "Incorrect last name");
        Assert.AreEqual(new[] {"social", "funny"}, created.SocialSkills, "Incorrect social skills");
        Assert.AreEqual(new[] {new SocialAccount(SocialAccountType.Twitter, "@sanderdecock")}, created.SocialAccounts,
            "Incorrect social accounts");
    }

    #endregion

    #region GetSocialAccountTypes

    [Test]
    public void GetSocialAccountTypes_AllTypesArePresent()
    {
        var socialAccountTypes = Enum.GetValues<SocialAccountType>();
        var socialAccountTypesFromRepo = Repo.GetSocialAccountTypes();
        var accountTypes = socialAccountTypesFromRepo as SocialAccountType[] ?? socialAccountTypesFromRepo!.ToArray();
        Assert.AreEqual(socialAccountTypes.Length, accountTypes.Length);
        Assert.AreEqual(socialAccountTypes, accountTypes);
    }

    #endregion

    private static UserInformation CreateValidUserInformation()
    {
        return new UserInformation("Sander", "De Cock", new[] {"social", "funny"},
            new[] {new SocialAccount(SocialAccountType.Twitter, "@sanderdecock")});
    }
}