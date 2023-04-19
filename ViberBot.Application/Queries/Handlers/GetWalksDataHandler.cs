using Application.Models;
using Application.Queries.DTOs;
using Application.Repositories;
using Application.Services;
using MediatR;
using System.Drawing;
using System.Net.Http.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Queries.Handlers
{
    public class GetWalksDataHandler : IRequestHandler<GetWalksDataQuery>
    {
        private readonly TrackRepository _trackRepository;
        public GetWalksDataHandler(TrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public async Task Handle(GetWalksDataQuery request, CancellationToken cancellationToken)
        {
            List<TrackLocation> trackLocations =
                await _trackRepository.GetTraksAsync(a => a.IMEI == request.IMEI);
            List<Walk> walks;
            if (trackLocations.Count == 0)
            {
                walks = new List<Walk>();
            }
            else
            {
                walks = TrackService.GenerateWalks(trackLocations);
            }
            var dto = new WalksDataDTO
            {
                WalksCount = walks.Count,
                TotalDistanceKM = walks.Sum(a => a.DistanceKilometers),
                TotalMinutes = walks.Sum(a => a.DurationMinutes)
            };
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Viber-Auth-Token", "50e526ec4be7dcb9-64d0bc28836f2a6c-c5db42f558d31e4f");
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://chatapi.viber.com/pa/send_message", new
                {
                    receiver = request.Receiver,
                    type = "rich_media",
                    //text =
                    //$"Number: {dto.WalksCount}\n" +
                    //$"Kilometers: {dto.TotalDistanceKM}\n" +
                    //$"Minutes: {dto.TotalMinutes}\n",
                    min_api_version = 2,
                    rich_media = new
                    {
                        Type = "rich_media",
                        ButtonsGroupColumns = 6,
                        ButtonsGroupRows = 1,
                        BgColor = "#FFFFFF",
                        Buttons = new[] {
                            new {
                                ActionType = "open-url",
                                ActionBody = "https://www.example.com/",
                                Text = "Visit our website",
                                Rows = 1,
                                Columns = 6,
                                BgColor = "#2db9b9",
                                TextSize = "regular",
                                TextHAlign = "center",
                                TextVAlign = "middle"
                                }
                            },
                            Text = "Check out our website!",
                            Media = "https://example.com/image.jpg",
                            Thumbnail = "https://example.com/thumbnail.jpg"
                    },
                    sender = new
                    {
                        name = "Bot"
                    }
                });
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            await Console.Out.WriteLineAsync(responseBody);
        }
    }
}
