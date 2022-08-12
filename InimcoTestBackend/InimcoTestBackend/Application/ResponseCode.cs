namespace InimcoTestBackend.Application;

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
    Aggregate,
    Ok,
    Other
}