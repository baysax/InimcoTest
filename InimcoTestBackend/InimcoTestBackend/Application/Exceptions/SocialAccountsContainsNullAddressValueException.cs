using InimcoTestBackend.Application.Response;

namespace InimcoTestBackend.Application.Exceptions;

public class SocialAccountsContainsNullAddressValueException: AApplicationException
{
    public SocialAccountsContainsNullAddressValueException(): base(ResponseCode.SocialAccountsContainsNullAddressValue){}
}