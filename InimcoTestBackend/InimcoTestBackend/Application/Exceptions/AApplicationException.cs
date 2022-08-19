using InimcoTestBackend.Application.Response;

namespace InimcoTestBackend.Application.Exceptions;

/// <summary>
/// Exception thrown when input is invalid.
/// </summary>
public abstract class AApplicationException: Exception
{
    protected AApplicationException(ResponseCode responseCode)
    {
        ResponseCode = responseCode;
    }
    public ResponseCode ResponseCode { get; }
}