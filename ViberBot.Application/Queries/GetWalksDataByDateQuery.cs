using MediatR;

namespace Application.Queries
{
    public record GetWalksDataByDateQuery(string IMEI, DateTime Date) : IRequest;
}
