namespace InimcoTestBackend.Application.Exceptions;

public class SocialAccountsNullException: AApplicationException
{
    public SocialAccountsNullException(): base(ResponseCode.SocialAccountsNull){}
}