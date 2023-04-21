using MediatR;

namespace Application.Requsts
{
    public record GeneralWalksDataRequest(string IMEI, string Receiver) : IRequest;
}
