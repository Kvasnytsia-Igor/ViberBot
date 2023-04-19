using Application.Models;
using Application.Queries.DTOs;
using Application.Repositories;
using Application.Services;
using MediatR;

namespace Application.Queries.Handlers
{
    public class GetWalksDataByDateHandler : IRequestHandler<GetWalksDataByDateQuery>
    {
        private readonly TrackRepository _trackRepository;
        public GetWalksDataByDateHandler(TrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public async Task Handle(GetWalksDataByDateQuery request, CancellationToken cancellationToken)
        {
            List<TrackLocation> trackLocations =
                await _trackRepository.GetTraksAsync(a => a.IMEI == request.IMEI && a.DateTrack.Date == request.Date);
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
        }
    }
}
