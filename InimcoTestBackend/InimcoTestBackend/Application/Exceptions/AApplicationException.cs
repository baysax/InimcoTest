namespace InimcoTestBackend.Application.Exceptions;

public abstract class AApplicationException: Exception
{
    protected AApplicationException(ResponseCode responseCode)
    {
        ResponseCode = responseCode;
    }
    public ResponseCode ResponseCode { get; }
}