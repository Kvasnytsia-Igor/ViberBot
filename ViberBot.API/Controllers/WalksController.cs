using Application.Models;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ViberBot.API.Controllers
{
    [Route("api/viber")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WalksController(IMediator mediator) => _mediator = mediator;

        [HttpPost("webhook")]
        public async Task<ActionResult> Webhook([FromBody] ViberEvent viberEvent)
        {
            if (viberEvent == null)
            {
                return BadRequest();
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Viber-Auth-Token", "50e526ec4be7dcb9-64d0bc28836f2a6c-c5db42f558d31e4f");
            try
            {
                string responseBody = "";
                await Console.Out.WriteLineAsync(viberEvent.Event);
                if (viberEvent.Event == "message")
                {
                    await Console.Out.WriteLineAsync(viberEvent.Sender.Id);
                    HttpResponseMessage response = await client.PostAsJsonAsync(
                        "https://d813-94-230-200-99.ngrok-free.app/api/viber/walks-data", new
                        {
                            IMEI = viberEvent.Message.Text,
                            Receiver = viberEvent.Sender.Id
                        });
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return Ok();
        }

        [HttpPost("walks")]
        public async Task<ActionResult> Walks([FromBody] JObject jobject)
        {
            if (jobject.HasValues)
            {
                await _mediator.Send(new FindWalksQuery(jobject.Value<string>("IMEI") ?? "", jobject.Value<int>("topCount")));
            }
            return Ok();
        }

        [HttpPost("walks-data")]
        public async Task<ActionResult> WalksData([FromBody] GetWalksDataQuery query)
        {
            await _mediator.Send(query);
            return Ok();
        }

        [HttpPost("walks-data-by-date")]
        public async Task<ActionResult> WalksDataByDate([FromBody] GetWalksDataByDateQuery query)
        {
            await _mediator.Send(query);
            return Ok();
        }
    }
}
