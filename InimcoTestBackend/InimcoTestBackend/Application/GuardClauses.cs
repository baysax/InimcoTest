using Ardalis.GuardClauses;
using InimcoTestBackend.Application.Exceptions;
using InimcoTestBackend.Application.Input;
using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Application;

/// <summary>
/// This static class contains all input validation. Throws the correct exception when input is invalid.
/// </summary>
public static class GuardClauses
{
    /// <summary>
    /// Extension method of IGuardClause. Validates UserInformationInput. Returns a UserInformation object when input is valid.
    /// </summary>
    /// <param name="guardClause">Extension method of <c>IGuardClause</c></param>
    /// <param name="input">The input of the service call</param>
    /// <returns></returns>
    /// <exception cref="AApplicationException">When only a single input validation failed</exception>
    /// <exception cref="AggregateApplicationException">When multiple input validations failed</exception>
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
                input.SocialAccounts!.Select(sa => new SocialAccount(Enum.Parse<SocialAccountType>(sa.Type!), sa.Address!)))
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

    private static void SocialAccountsValidation(IEnumerable<SocialAccountInput>? inputSocialAccounts,
        List<AApplicationException> exceptions)
    {
        if (inputSocialAccounts == null)
        {
            exceptions.Add(new SocialAccountsNullException());
        }
        else
        {
            var socialAccountInputs = inputSocialAccounts as SocialAccountInput[] ?? inputSocialAccounts.ToArray();
            if(socialAccountInputs.Contains(null))
                exceptions.Add(new SocialAccountsContainsNullValueException());
            else
            {
                if (socialAccountInputs.Any(sai => string.IsNullOrEmpty(sai.Address)))
                    exceptions.Add(new SocialAccountsContainsNullAddressValueException());
                if(socialAccountInputs.Any(sai => string.IsNullOrEmpty(sai.Type)))
                    exceptions.Add(new SocialAccountsContainsNullTypeValueException());
                else if(socialAccountInputs.Any(sai => SocialAccountTypeInvalid(sai.Type!)))
                    exceptions.Add(new SocialAccountsContainsInvalidTypeValueException());
            }
        }
    }

    private static bool NameInvalid(string name)
    {
        return !name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '-');
    }

    private static bool SocialAccountTypeInvalid(string type)
    {
        return !Enum.TryParse(typeof(SocialAccountType), type, true, out _);
    }
}