using InimcoTestBackend.Application.Exceptions;

namespace InimcoTestBackend.Application.Response;

public record Response<T>(ResponseCode ResponseCode, 
    IEnumerable<AApplicationException>? Exceptions, T? Item = default)
{
    public Response(T item): this(ResponseCode.Ok, null, item)
    {
    }
}