using Application.Data;
using Application.Models;
using Application.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class TrackService
{
    private readonly TracksContext _tracksContext;
    public TrackService(TracksContext tracksContext)
    {
        _tracksContext = tracksContext;
    }
    public async Task<List<Walk>> GenerateWalksAsync(string IMEI, DateTime? date = null)
    {
        List<TrackLocation> trackLocations = await GetTraksAsync(IMEI, date);
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
    private async Task<List<TrackLocation>> GetTraksAsync(string IMEI, DateTime? date)
    {
        IQueryable<TrackLocation> query =
            _tracksContext.TrackLocations
            .Where(a => a.IMEI == IMEI);
        if (date is not null)
        {
            query.Where(a => a.DateTrack.Equals(date));
        }
        return await query
            .OrderBy(a => a.DateTrack)
            .ToListAsync();
    }
    public async Task<bool> IsExistIMEIAsync(string IMEI)
    {
        return await _tracksContext.TrackLocations
              .Select(a => a.IMEI)
              .Distinct()
              .FirstOrDefaultAsync(a => a == IMEI) is not null;
    }
}
