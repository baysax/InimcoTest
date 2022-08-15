using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Application;

public record UserInformationFeedback(UserInformation UserInformation)
{
    public int VowelsCount => UserInformation.CountVowelsInFirstAndLastName();
    public int ConsonantsCount => UserInformation.CountConsonantsInFirstAndLastName();
    public string FullName => $"{UserInformation.FirstName} {UserInformation.LastName}";
    public string ReverseFullName => $"{UserInformation.ReverseLastName()} {UserInformation.ReverseFirstName()}";
}