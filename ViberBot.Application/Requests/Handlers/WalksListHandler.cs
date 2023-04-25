using Application.DataModels;
using Application.Requsts.DTOs;
using Application.Services;
using MediatR;
using ViberBot.Application.Common;
using ViberBot.Application.Services;
using ViberBot.Application;
using ViberBot.Application.Requests.DTOs;
using ViberBot.Application.Responses.ViberApiResponses;

namespace Application.Requsts.Handlers;

public class WalksListHandler : IRequestHandler<WalksListRequest>
{
    private readonly TrackService _trackService;
    private readonly MessagesService _messagesService;
    public WalksListHandler(TrackService trackService, MessagesService messagesService)
    {
        _trackService = trackService;
        _messagesService = messagesService;
    }
    public async Task Handle(WalksListRequest request, CancellationToken cancellationToken)
    {
        List<Walk> walks = await _trackService.GenerateWalksAsync(request.IMEI);
        walks = walks
            .OrderByDescending(a => a.DistanceKilometers)
            .Take(request.TopCount)
            .ToList();
        await _messagesService.SendWithResponse<SendMessageResponse>(
           ViberRequestTemplates.WalksTableList(new WalksTableDTO
           {
               IMEI = request.IMEI,
               Walks = walks,
               ReceiverId = request.ReceiverId,
           }), 
           $"{URLs.BASE_VIBER}/send_message");
    }
    
}
