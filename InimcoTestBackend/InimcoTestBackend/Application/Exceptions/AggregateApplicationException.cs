using InimcoTestBackend.Application.Response;

namespace InimcoTestBackend.Application.Exceptions;

/// <summary>
/// Thrown when the input contains multiple exceptions.
/// </summary>
public class AggregateApplicationException: AApplicationException
{
    public AggregateApplicationException(IEnumerable<AApplicationException> exceptions) : base(ResponseCode.Aggregate)
    {
        Exceptions = exceptions;
    }

    public IEnumerable<AApplicationException> Exceptions { get; }
}