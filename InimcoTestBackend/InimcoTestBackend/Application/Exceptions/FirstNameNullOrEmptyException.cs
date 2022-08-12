using JetBrains.Annotations;

namespace InimcoTestBackend.Application.Exceptions;

public class FirstNameNullOrEmptyException: AApplicationException
{
    public FirstNameNullOrEmptyException(): base(ResponseCode.FirstNameNullorEmpty){}
}