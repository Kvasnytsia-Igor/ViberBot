using Application.Models;
using Application.Requsts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ViberBot.API.Validators;
using ViberBot.Application;
using ViberBot.Application.Common;
using ViberBot.Application.Services;

namespace ViberBot.API.Controllers;

[Route("api/viber")]
[ApiController]
public class ViberController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly MessagesService _messagesService;
    public ViberController(IMediator mediator, MessagesService messagesService)
    {
        _mediator = mediator;
        _messagesService = messagesService;
    }
    [HttpPost("webhook")]
    public async Task<ActionResult> Webhook(ViberEvent viberEvent)
    {
        if (viberEvent == null)
        {
            return BadRequest();
        }
        return viberEvent.Event switch
        {
            "conversation_started" => ConversationStarted(),
            "message" => await Message(viberEvent),
            _ => Ok(),
        };
    }
    private ActionResult ConversationStarted()
    {
        return Ok(ResponseTemplates.WelcomeMessage());
    }
    private async Task<ActionResult> Message(ViberEvent viberEvent)
    {
        if (!IMEI_Validator.ValidateIMEI(viberEvent.Message.Text))
        {
            await _messagesService.SendWithResponse(
                ResponseTemplates.InvalidIMEIMessage(viberEvent.Sender.Id),
                $"{URLs.BASE_VIBER}/send_message");
        }
        else
        {
            await _messagesService.Send(new
        {
            IMEI = viberEvent.Message.Text,
            Receiver = viberEvent.Sender.Id,
        }, $"{URLs.BASE_URL}/general-walks-data");
        }
        return Ok();
    }

    [HttpPost("general-walks-data")]
    public async Task<ActionResult> GeneralWalksData(GeneralWalksDataRequest request)
    {
        await _mediator.Send(request);
        return Ok();
    }
    [HttpPost("walks-list")]
    public async Task<ActionResult> WalksList(WalksListRequest request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}
