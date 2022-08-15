namespace InimcoTestBackend.Application.Input;

public record UserInformationInput(string? FirstName, string? LastName, IEnumerable<string?>? SocialSkills,
    IEnumerable<SocialAccountInput?>? SocialAccounts);