using InimcoTestBackend.Application.Response;

namespace InimcoTestBackend.Application.Exceptions;

public class LastNameInvalidException: AApplicationException
{
    public LastNameInvalidException(): base(ResponseCode.LastNameInvalid){}
}