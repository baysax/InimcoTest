namespace InimcoTestBackend.Application.Exceptions;

public class FirstNameInvalidException: AApplicationException
{
    public FirstNameInvalidException(): base(ResponseCode.FirstNameInvalid){}
}