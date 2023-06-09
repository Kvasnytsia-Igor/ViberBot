﻿using Application.DataModels;
using Application.Requsts.DTOs;
using Application.Services;
using MediatR;
using ViberBot.Application;
using ViberBot.Application.Common;
using ViberBot.Application.Services;

namespace Application.Requsts.Handlers;

public class GeneralWalksDataHandler : IRequestHandler<GeneralWalksDataRequest>
{
    private readonly TrackService _trackService;
    private readonly MessagesService _messagesService;
    public GeneralWalksDataHandler(TrackService trackService, MessagesService messagesService)
    {
        _trackService = trackService;
        _messagesService = messagesService;
    }
    public async Task Handle(GeneralWalksDataRequest request, CancellationToken cancellationToken)
    {
        if (!await _trackService.IsExistIMEIAsync(request.IMEI))
        {
            await _messagesService.Send(
                ViberRequestTemplates.AbsentMessage(request.ReceiverId),
                $"{URLs.BASE_VIBER}/send_message");
            return;
        }
        List<Walk> walks = await _trackService.GenerateWalksAsync(request.IMEI);
        await _messagesService.Send(
            ViberRequestTemplates.GeneralInfoWithKeyboard(new WalksDataDTO
            {
                ReceiverId = request.ReceiverId,
                IMEI = request.IMEI,
                WalksCount = walks.Count,
                TotalDistanceKM = walks.Sum(a => a.DistanceKilometers),
                TotalMinutes = walks.Sum(a => a.DurationMinutes)
            }), $"{URLs.BASE_VIBER}/send_message");
    }
}
