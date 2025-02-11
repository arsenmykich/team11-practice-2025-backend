using Data_Access_Layer.Data;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data_Access_Layer.Repositories
{
    public class BookingRepository : GenericRepository<Booking>
    {
        public BookingRepository(CinemaContext context) : base(context) { }

        public async Task<bool> IsSeatAvailableAsync(int sessionId, int seatId)
        {
            return !await context.Bookings.AnyAsync(b => b.SessionId == sessionId && b.SeatId == seatId);
        }

        public async Task<bool> IsSeatInCorrectHallAsync(int sessionId, int seatId)
        {
            var session = await context.Sessions.Include(s => s.Hall).FirstOrDefaultAsync(s => s.Id == sessionId);
            var seat = await context.Seats.Include(s => s.Hall).FirstOrDefaultAsync(s => s.Id == seatId);
            return session != null && seat != null && session.HallId == seat.HallId;
        }

        public async Task<float> GetSessionPriceAsync(int sessionId)
        {
            var session = await context.Sessions.FindAsync(sessionId);
            return session?.Price ?? 0;
        }
    }
}