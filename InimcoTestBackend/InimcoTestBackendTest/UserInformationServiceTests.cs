using System.Threading.Tasks;
using InimcoTestBackend.Application;
using InimcoTestBackend.Application.Input;
using InimcoTestBackend.Application.Response;
using InimcoTestBackend.Domain;
using Moq;
using NUnit.Framework;

namespace InimcoTestBackendTest;

public class UserInformationServiceTests
{
    private static readonly IUserInformationService Service =
        new UserInformationService(CreateRepositoryMock());

    #region AddUserInformationAsync

    [Test]
    public async Task AddUserInformationAsync_FirstNameNull_ResponseCodeEqualsFirstNameNullOrEmpty()
    {
        var input = new UserInformationInput(null, "De Cock", new[] {"social", "funny"},
            new[] {new SocialAccountInput("Twitter", "@sanderdecock")});
        
        var response = await Service.AddUserInformationAsync(input);
        
        Assert.IsTrue(response.ResponseCode == ResponseCode.FirstNameNullorEmpty);
        Assert.IsNull(response.Item);
    }

    [Test]
    public async Task AddUserInformationAsync_LastNameNull_ResponseCodeEqualsLastNameNullOrEmpty()
    {
        var input = new UserInformationInput("Sander", null, new[] {"social", "funny"},
            new[] {new SocialAccountInput("Twitter", "@sanderdecock")});
        
        var response = await Service.AddUserInformationAsync(input);
        
        Assert.IsTrue(response.ResponseCode == ResponseCode.LastNameNullorEmpty);
        Assert.IsNull(response.Item);
    }

    [Test]
    public async Task AddUserInformationAsync_FirstNameInvalid_ResponseCodeEqualsFirstNameInvalid()
    {
        var input = new UserInformationInput("123,,,aa", "De Cock", new[] {"social", "funny"},
            new[] {new SocialAccountInput("Twitter", "@sanderdecock")});
        
        var response = await Service.AddUserInformationAsync(input);
        
        Assert.IsTrue(response.ResponseCode == ResponseCode.FirstNameInvalid);
        Assert.IsNull(response.Item);
    }

    [Test]
    public async Task AddUserInformationAsync_LastNameInvalid_ResponseCodeEqualsLastNameInvalid()
    {
        var input = new UserInformationInput("Sander", "De Cock,,,,", new[] {"social", "funny"},
            new[] {new SocialAccountInput("Twitter", "@sanderdecock")});
        
        var response = await Service.AddUserInformationAsync(input);
        
        Assert.IsTrue(response.ResponseCode == ResponseCode.LastNameInvalid);
        Assert.IsNull(response.Item);
    }

    [Test]
    public async Task AddUserInformationAsync_SocialSkillsNull_ResponseCodeEqualsSocialSkillsNull()
    {
        var input = new UserInformationInput("Sander", "De Cock", null,
            new[] {new SocialAccountInput("Twitter", "@sanderdecock")});
        
        var response = await Service.AddUserInformationAsync(input);
        
        Assert.IsTrue(response.ResponseCode == ResponseCode.SocialSkillsNull);
        Assert.IsNull(response.Item);
    }

    [Test]
    public async Task AddUserInformationAsync_SocialSkillsContainsNullValue_ResponseCodeEqualsSocialSkillsContainsNullValue()
    {
        var input = new UserInformationInput("Sander", "De Cock", new []{ null, "test"},
            new[] {new SocialAccountInput("Twitter", "@sanderdecock")});
        
        var response = await Service.AddUserInformationAsync(input);
        
        Assert.IsTrue(response.ResponseCode == ResponseCode.SocialSkillsContainsNullValue);
        Assert.IsNull(response.Item);
    }

    [Test]
    public async Task AddUserInformationAsync_SocialAccountsNull_ResponseCodeEqualsSocialAccountsNull()
    {
        var input = new UserInformationInput("Sander", "De Cock", new []{ "da", "test"},
            null);
        
        var response = await Service.AddUserInformationAsync(input);
        
        Assert.IsTrue(response.ResponseCode == ResponseCode.SocialAccountsNull);
        Assert.IsNull(response.Item);
    }

    [Test]
    public async Task AddUserInformationAsync_SocialAccountsContainsNullValue_ResponseCodeEqualsSocialAccountsContainsNullValue()
    {
        var input = new UserInformationInput("Sander", "De Cock", new []{ "da", "test"},
            new[] {null, new SocialAccountInput("Twitter", "@sanderdecock")});
        
        var response = await Service.AddUserInformationAsync(input);
        
        Assert.IsTrue(response.ResponseCode == ResponseCode.SocialAccountsContainsNullValue);
        Assert.IsNull(response.Item);
    }

    [Test]
    public async Task AddUserInformationAsync_SocialAccountsContainsNullAddressValue_ResponseCodeEqualsSocialAccountsContainsNullAddressValue()
    {
        var input = new UserInformationInput("Sander", "De Cock", new []{ "da", "test"},
            new[] {new SocialAccountInput("Twitter", null)});
        
        var response = await Service.AddUserInformationAsync(input);
        
        Assert.IsTrue(response.ResponseCode == ResponseCode.SocialAccountsContainsNullAddressValue);
        Assert.IsNull(response.Item);
    }

    [Test]
    public async Task AddUserInformationAsync_SocialAccountsContainsNullTypeValue_ResponseCodeEqualsSocialAccountsContainsNullTypeValue()
    {
        var input = new UserInformationInput("Sander", "De Cock", new []{ "da", "test"},
            new[] {new SocialAccountInput(null, "@sanderdecock")});
        
        var response = await Service.AddUserInformationAsync(input);
        
        Assert.IsTrue(response.ResponseCode == ResponseCode.SocialAccountsContainsNullTypeValue);
        Assert.IsNull(response.Item);
    }

    [Test]
    public async Task AddUserInformationAsync_SocialAccountsContainsInvalidTypeValue_ResponseCodeEqualsSocialAccountsContainsInvalidTypeValue()
    {
        var input = new UserInformationInput("Sander", "De Cock", new []{ "da", "test"},
            new[] {new SocialAccountInput("invalid", "@sanderdecock")});
        
        var response = await Service.AddUserInformationAsync(input);
        
        Assert.IsTrue(response.ResponseCode == ResponseCode.SocialAccountsContainsInvalidTypeValue);
        Assert.IsNull(response.Item);
    }

    [Test]
    public async Task AddUserInformationAsync_MultipleErrors_ResponseCodeEqualsAggregate()
    {
        var input = new UserInformationInput("Sander", "De Cock", new []{ null, "test"},
            new[] {new SocialAccountInput("invalid", "@sanderdecock")});
        
        var response = await Service.AddUserInformationAsync(input);
        
        Assert.IsTrue(response.ResponseCode == ResponseCode.Aggregate);
        Assert.IsNull(response.Item);
    }
    
    

    [Test]
    public async Task AddUserInformationAsync_CorrectRequest_ResponseCodeEqualsOk()
    {
        var input = new UserInformationInput("Sander", "De Cock", new []{ "funny", "test"},
            new[] {new SocialAccountInput("Twitter", "@sanderdecock")});
        
        var response = await Service.AddUserInformationAsync(input);
        
        Assert.IsTrue(response.ResponseCode == ResponseCode.Ok);
        Assert.IsNotNull(response.Item);
    }

    #endregion

    private static IUserInformationRepository CreateRepositoryMock()
    {
        var repoMock = new Mock<IUserInformationRepository>();
        
        var userInformation = new UserInformation("Sander", "De Cock", new[] {"hallo"},
            new[] {new SocialAccount(SocialAccountType.Twitter, "@sanderdecock")});
        repoMock.Setup(x => x.GetAllUserInformationsAsync()).ReturnsAsync(new[] {userInformation});

        return repoMock.Object;
    }

}