namespace InimcoTestBackend.Application;

public record Response<T>(ResponseCode ResponseCode, T? Item = default)
{
    public Response(T item): this(ResponseCode.Ok, item)
    {
    }
}