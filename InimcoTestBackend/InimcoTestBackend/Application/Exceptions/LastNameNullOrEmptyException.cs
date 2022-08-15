using InimcoTestBackend.Application.Response;

namespace InimcoTestBackend.Application.Exceptions;

public class LastNameNullOrEmptyException: AApplicationException
{
    public LastNameNullOrEmptyException(): base(ResponseCode.LastNameNullorEmpty){}
}