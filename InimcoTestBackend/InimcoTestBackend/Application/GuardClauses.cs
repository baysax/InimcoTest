using Ardalis.GuardClauses;
using InimcoTestBackend.Application.Exceptions;
using InimcoTestBackend.Application.RequestObjects;
using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Application;

public static class GuardClauses
{
    public static UserInformation UserInformationInvalidInput(this IGuardClause guardClause, UserInformationInput input)
    {
        var exceptions = new List<AApplicationException>();

        FirstNameValidation(input.FirstName, exceptions);
        LastNameValidation(input.LastName, exceptions);
        SocialSkillsValidation(input.SocialSkills, exceptions);
        SocialAccountsValidation(input.SocialAccounts, exceptions);

        return exceptions.Count switch
        {
            1 => throw exceptions[0],
            > 1 => throw new AggregateApplicationException(exceptions),
            _ => new UserInformation(input.FirstName!, input.LastName!, input.SocialSkills!.Select(s => s!),
                input.SocialAccounts!.Select(sa => new SocialAccount(sa.Type, sa.Address!)))
        };
    }

    private static void FirstNameValidation(string? firstName, ICollection<AApplicationException> exceptions)
    {
        if (string.IsNullOrEmpty(firstName))
            exceptions.Add(new FirstNameNullOrEmptyException());
        else if(NameInvalid(firstName))
            exceptions.Add(new FirstNameInvalidException());
    }

    private static void LastNameValidation(string? lastName, ICollection<AApplicationException> exceptions)
    {
        if (string.IsNullOrEmpty(lastName))
            exceptions.Add(new LastNameNullOrEmptyException());
        else if(NameInvalid(lastName))
            exceptions.Add(new LastNameInvalidException());
    }

    private static void SocialSkillsValidation(IEnumerable<string?>? inputSocialSkills, ICollection<AApplicationException> exceptions)
    {
        if(inputSocialSkills == null)
            exceptions.Add(new SocialSkillsNullException());
        else if(inputSocialSkills.Any(string.IsNullOrEmpty))
            exceptions.Add(new SocialSkillsContainsNullValueException());
    }

    private static void SocialAccountsValidation(IEnumerable<SocialAccountInput>? inputSocialAccounts, List<AApplicationException> exceptions)
    {
        if(inputSocialAccounts == null)
            exceptions.Add(new SocialAccountsNullException());
        else if(inputSocialAccounts.Any(sai => string.IsNullOrEmpty(sai.Address)))
            exceptions.Add(new SocialAccountsContainsNullAddressValueException());
    }

    private static bool NameInvalid(string name)
    {
        return !name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '-');
    }
}