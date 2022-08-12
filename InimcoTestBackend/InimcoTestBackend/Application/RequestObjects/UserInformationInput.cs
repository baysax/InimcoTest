namespace InimcoTestBackend.Application.RequestObjects;

public record UserInformationInput(string? FirstName, string? LastName, IEnumerable<string?>? SocialSkills,
    IEnumerable<SocialAccountInput>? SocialAccounts);