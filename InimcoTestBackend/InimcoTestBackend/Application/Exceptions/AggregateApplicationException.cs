namespace InimcoTestBackend.Application.Exceptions;

public class AggregateApplicationException: AApplicationException
{
    public AggregateApplicationException(IEnumerable<AApplicationException> exceptions) : base(ResponseCode.Aggregate)
    {
        Exceptions = exceptions;
    }

    public IEnumerable<AApplicationException> Exceptions { get; }
}