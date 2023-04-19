namespace ConsoleCkeck.Services
{
    public class TracksService
    {
        //private readonly TrackRepository _trackRepository;
        //public TracksService(TrackRepository trackRepository)
        //{
        //    _trackRepository = trackRepository;
        //}

        //// 1.Потрібно розділити данні на окремі прогулянки
        //// (прогулянка вважається новою якщо проміжок часу між останнім сигналом від 30 хвилин)
        //// 2. Прорахувати відстань пройдену за кожну прогулянку
        //// 3. Прорахувати час кожної прогулянки
        //public List<Walk> FindWalks(string IMEI)
        //{
        //    List<TrackLocation> trackLocations = _trackRepository
        //        .GetTraks(a => a.IMEI == IMEI);
        //    List<Walk> result = new();
        //    TimeSpan duration = new();
        //    double distance = 0;
        //    for (int i = 1; i < trackLocations.Count; i++)
        //    {
        //        TimeSpan buffer = trackLocations[i].DateTrack - trackLocations[i - 1].DateTrack;
        //        duration += buffer;
        //        distance += DistanceCalculator.Distance(
        //            (double)trackLocations[i].Latitude, (double)trackLocations[i].Longitude,
        //            (double)trackLocations[i - 1].Latitude, (double)trackLocations[i - 1].Longitude);
        //        if (buffer.TotalMinutes > 30)
        //        {
        //            if (distance > 0)
        //            {
        //                result.Add(new Walk
        //                {
        //                    IMEI = IMEI,
        //                    DurationMinutes = Math.Round(duration.TotalMinutes, 0),
        //                    DistanceKM = Math.Round(distance, 4),
        //                });
        //                distance = 0;
        //            }
        //            duration = new();
        //        }
        //    }
        //    return result;
        //}

        ////4. Прорахувати скільки пройшов за день і скільки часу всього гуляв
        //public double GetDistanceInDay(string IMEI, DateOnly day)
        //{
        //    List<TrackLocation> trackLocations = _trackRepository
        //       .GetTraks(a => a.IMEI == IMEI && DateOnly.FromDateTime(a.DateTrack) == day);
        //    double distance = 0;
        //    for (int i = 1; i < trackLocations.Count; i++)
        //    {
        //        distance += DistanceCalculator.Distance(
        //            (double)trackLocations[i].Latitude, (double)trackLocations[i].Longitude,
        //            (double)trackLocations[i - 1].Latitude, (double)trackLocations[i - 1].Longitude);
        //    }
        //    return distance;
        //}
        //public TimeSpan GetTimeWalkingInDay(string IMEI, DateOnly day)
        //{
        //    List<TrackLocation> trackLocations = _trackRepository
        //      .GetTraks(a => a.IMEI == IMEI && DateOnly.FromDateTime(a.DateTrack) == day);
        //    TimeSpan duration = new();
        //    for (int i = 1; i < trackLocations.Count; i++)
        //    {
        //        double distance = DistanceCalculator.Distance(
        //            (double)trackLocations[i].Latitude, (double)trackLocations[i].Longitude,
        //            (double)trackLocations[i - 1].Latitude, (double)trackLocations[i - 1].Longitude);
        //        if (distance > 0)
        //        {
        //            duration += trackLocations[i].DateTrack - trackLocations[i - 1].DateTrack;
        //        }
        //    }
        //    return duration;
        //}
        //public TimeSpan GetAllTimeWalking(string IMEI)
        //{
        //    List<TrackLocation> trackLocations = _trackRepository
        //        .GetTraks(a => a.IMEI == IMEI);
        //    TimeSpan duration = new();
        //    for (int i = 0; i < trackLocations.Count; i++)
        //    {
        //        double distance = DistanceCalculator.Distance(
        //             (double)trackLocations[i].Latitude, (double)trackLocations[i].Longitude,
        //             (double)trackLocations[i - 1].Latitude, (double)trackLocations[i - 1].Longitude);
        //        if (distance > 0)
        //        {
        //            duration += trackLocations[i].DateTrack - trackLocations[i - 1].DateTrack;
        //        }
        //    }
        //    return duration;
        //}
    }
}
