using MediatR;

namespace Application.Requsts
{
    public record WalksListRequest(string IMEI, int TopCount) : IRequest;
}
