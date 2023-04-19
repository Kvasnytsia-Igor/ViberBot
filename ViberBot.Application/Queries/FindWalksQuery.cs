using MediatR;

namespace Application.Queries
{
    public record FindWalksQuery(string IMEI, int TopCount) : IRequest;
}
