using MediatR;

namespace Application.Requsts
{
    public record WalksListRequest(string ReceiverId, string IMEI, int TopCount) : IRequest;
}
