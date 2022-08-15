using InimcoTestBackend.Application.Response;

namespace InimcoTestBackend.Application.Exceptions;

public class SocialAccountsContainsNullValueException: AApplicationException
{
    public SocialAccountsContainsNullValueException(): base(ResponseCode.SocialAccountsContainsNullValue){}
}