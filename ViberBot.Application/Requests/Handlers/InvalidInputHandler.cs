using MediatR;
using ViberBot.Application.Common;
using ViberBot.Application.Services;

namespace ViberBot.Application.Requests.Handlers;

public class InvalidInputHandler : IRequestHandler<InvalidInputRequest>
{
    private readonly MessagesService _messagesService;
    public InvalidInputHandler(MessagesService messagesService)
    {
        _messagesService = messagesService;
    }
    public async Task Handle(InvalidInputRequest request, CancellationToken cancellationToken)
    {
        await _messagesService.Send(
            ViberRequestTemplates.InvalidMessage(
                request.ReceiverId
            ), $"{URLs.BASE_VIBER}/send_message");
    }
}
