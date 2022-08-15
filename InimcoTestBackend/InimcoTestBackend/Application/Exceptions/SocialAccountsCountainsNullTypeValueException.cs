using InimcoTestBackend.Application.Response;

namespace InimcoTestBackend.Application.Exceptions;

public class SocialAccountsContainsNullTypeValueException: AApplicationException
{
    public SocialAccountsContainsNullTypeValueException(): base(ResponseCode.SocialAccountsContainsNullTypeValue){}
}