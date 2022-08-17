using InimcoTestBackend.Domain;

namespace InimcoTestBackend.Application;

public record UserInformationFeedback(UserInformation Request)
{
    public int VowelsCount => Request.CountVowelsInFirstAndLastName();
    public int ConsonantsCount => Request.CountConsonantsInFirstAndLastName();
    public string FullName => $"{Request.FirstName} {Request.LastName}";
    public string ReverseFullName => $"{Request.ReverseLastName()} {Request.ReverseFirstName()}";
}