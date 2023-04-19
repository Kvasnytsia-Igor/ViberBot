using Application.Models;
using Application.Queries.DTOs;
using Application.Repositories;
using Application.Services;
using MediatR;
using System.Net.Http.Json;

namespace Application.Queries.Handlers
{
    public class FindWalksHandler : IRequestHandler<FindWalksQuery>
    {
        private readonly TrackRepository _trackRepository;
        public FindWalksHandler(TrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public async Task Handle(FindWalksQuery request, CancellationToken cancellationToken)
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
                if (walks.Count != 0)
                {
                    walks = walks
                        .OrderByDescending(a => a.DistanceKilometers)
                        .Take(request.TopCount)
                        .ToList();
                }
            }
            List<WalkDTO> walkDTOs = MapWithDTO(walks);

            
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
}
