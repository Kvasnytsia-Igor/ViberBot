using Application.Data;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public class TrackRepository
    {
        private readonly TracksContext _context;
        public TrackRepository(TracksContext context)
        {
            _context = context;
        }
        public async Task<List<TrackLocation>> GetTraksAsync(Expression<Func<TrackLocation, bool>> predicate)
        {
            return await _context.TrackLocations
                .Where(predicate)
                .OrderBy(a => a.DateTrack)
                .ToListAsync();
        }
    }
}
