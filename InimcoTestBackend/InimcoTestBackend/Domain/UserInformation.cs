using InimcoTestBackend.Extensions;

namespace InimcoTestBackend.Domain;

public record UserInformation(string FirstName, string LastName, IEnumerable<string> SocialSkills,
    IEnumerable<SocialAccount> SocialAccounts)
{
    public int CountVowelsInFirstAndLastName()
    {
        return FirstName.CountVowels() + LastName.CountVowels();
    }

    public int CountConsonantsInFirstAndLastName()
    {
        return FirstName.CountConsonants() + LastName.CountConsonants();
    }

    public string ReverseFirstName()
    {
        return FirstName.Reverse();
    }

    public string ReverseLastName()
    {
        return LastName.Reverse();
    }
}