using Application.Utilities;
using Application.Models;

namespace Application.Services
{
    public class TrackService
    {
        public static List<Walk> GenerateWalks(List<TrackLocation> trackLocations)
        {
            List<Walk> result = new();
            TimeSpan duration = new();
            decimal distance = 0;
            TrackLocation lastTrackLocation = trackLocations.Last();
            for (int i = 1; i < trackLocations.Count; i++)
            {
                TimeSpan buffer = trackLocations[i].DateTrack - trackLocations[i - 1].DateTrack;
                duration += buffer;
                distance += DistanceCalculator.Distance(
                    trackLocations[i].Latitude, trackLocations[i].Longitude,
                    trackLocations[i - 1].Latitude, trackLocations[i - 1].Longitude);
                if (buffer.TotalMinutes > 30 || lastTrackLocation == trackLocations[i])
                {
                    if (distance > 0)
                    {
                        result.Add(new Walk
                        {
                            DurationMinutes = (int)Math.Round(duration.TotalMinutes, 0),
                            DistanceKilometers = Math.Round(distance, 4),
                        });
                        distance = 0;
                    }
                    duration = new();
                }
            }
            return result;
        }
    }
}
