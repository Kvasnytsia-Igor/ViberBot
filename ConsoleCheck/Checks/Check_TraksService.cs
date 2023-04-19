using Application.Data;
using Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ConsoleCkeck.Checks
{
    public class Check_TrakcService
    {
        private static readonly TracksContext _tracksContext;
        private static readonly TrackRepository _trackRepository;
        static Check_TrakcService()
        {
            var contextOptions = new DbContextOptionsBuilder<TracksContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TrackDB;Trusted_Connection=True")
                .Options;
            _tracksContext = new(contextOptions);
            _trackRepository = new(_tracksContext);
        }
        public static void Check_FindWalks(string IMEI)
        {
            //Task response = (new FindWalksHandler(_trackRepository)).Handle(new FindWalksQuery(IMEI, 10), new CancellationTokenSource().Token);

            //List<WalkDTO> walks = response.Result;

            //int sequence = 1;
            //Console.WriteLine($"IMEI - {IMEI}");
            //Console.WriteLine("{0,-11} {1,-19} {2,-19}", "IMEI", "DistanceKM", "DurationMinutes");
            //foreach (WalkDTO walk in walks.OrderByDescending(a => a.DistanceKilometers))
            //{
            //    Console.WriteLine(string.Format(
            //        "{0,-11} {1,-19} {2,-19}",
            //        sequence,
            //        walk.DistanceKilometers,
            //        walk.DurationMinutes));
            //    sequence++;
            //}
        }
    }
}
