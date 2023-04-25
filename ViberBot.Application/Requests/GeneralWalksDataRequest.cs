using MediatR;

namespace Application.Requsts;
public record GeneralWalksDataRequest(string ReceiverId, string IMEI) : IRequest;
