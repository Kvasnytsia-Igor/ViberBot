using Application.Requsts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ViberBot.API.RequestEvent;
using ViberBot.API.Validators;
using ViberBot.Application.Requests;
using ViberBot.Application.Responses;

namespace ViberBot.API.Controllers;

[Route("api/viber")]
[ApiController]
public class ViberController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly InputValidator _inputValidator;
    public ViberController(IMediator mediator, InputValidator inputValidator)
    {
        _mediator = mediator;
        _inputValidator = inputValidator;
    }
    [HttpPost("webhook")]
    public async Task<ActionResult> Webhook(ViberEvent viberEvent)
    {
        if (viberEvent == null)
        {
            return BadRequest();
        }
        await Console.Out.WriteLineAsync(viberEvent.Event);
        return viberEvent.Event switch
        {
            "conversation_started" => Ok(new WelcomeMessage()),
            "message" => await Message(viberEvent),
            _ => Ok(),
        };
    }
    private async Task<ActionResult> Message(ViberEvent viberEvent)
    {
        string text = viberEvent.Message.Text;
        if (_inputValidator.ValidateIMEI(text))
        {
            await _mediator.Send(
                new GeneralWalksDataRequest(
                    viberEvent.Sender.Id,
                    viberEvent.Message.Text));
        }
        else if (_inputValidator.ValidateRequest(text))
        {
            string[] reqestData = text.Split(new[] { '/' });
            int topCount = int.Parse(reqestData[2]);
            await _mediator.Send(
                new WalksListRequest(
                    viberEvent.Sender.Id,
                    reqestData[1],
                    topCount));
        }
        else
        {
            await _mediator.Send(new InvalidInputRequest(viberEvent.Sender.Id));
        }
        return Ok();
    }
}
