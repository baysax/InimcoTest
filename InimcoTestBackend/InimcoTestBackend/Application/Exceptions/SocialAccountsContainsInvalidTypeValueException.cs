using InimcoTestBackend.Application.Response;

namespace InimcoTestBackend.Application.Exceptions;

public class SocialAccountsContainsInvalidTypeValueException: AApplicationException
{
    public SocialAccountsContainsInvalidTypeValueException(): base(ResponseCode.SocialAccountsContainsInvalidTypeValue){}
}