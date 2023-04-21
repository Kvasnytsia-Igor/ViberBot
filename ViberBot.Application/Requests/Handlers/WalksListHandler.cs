using Application.Models;
using Application.Requsts.DTOs;
using Application.Services;
using MediatR;

namespace Application.Requsts.Handlers;

public class WalksListHandler : IRequestHandler<WalksListRequest>
{
    private readonly TrackService _trackService;
    public WalksListHandler(TrackService trackService)
    {
        _trackService = trackService;
    }
    public async Task Handle(WalksListRequest request, CancellationToken cancellationToken)
    {
        List<Walk> walks = await _trackService.GenerateWalksAsync(request.IMEI);
        List<WalkDTO> walkDTOs = MapWithDTO(walks.Take(request.TopCount).ToList());


    }
    private static List<WalkDTO> MapWithDTO(List<Walk> walks)
    {
        List<WalkDTO> result = new();
        for (int i = 0; walks.Count > i; i++)
        {
            result.Add(new WalkDTO
            {
                Sequence = i + 1,
                DistanceKilometers = walks[i].DistanceKilometers,
                DurationMinutes = walks[i].DurationMinutes,
            });
        }
        return result;
    }
}
