using System.Text.Json.Serialization;

namespace InimcoTestBackend.Application.Response;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ResponseCode
{
    FirstNameNullorEmpty,
    FirstNameInvalid,
    LastNameInvalid,
    LastNameNullorEmpty,
    SocialSkillsNull,
    SocialSkillsContainsNullValue,
    SocialAccountsNull,
    SocialAccountsContainsNullAddressValue,
    SocialAccountsContainsNullTypeValue,
    SocialAccountsContainsInvalidTypeValue,
    SocialAccountsContainsNullValue,
    Aggregate,
    Ok,
    Other
}