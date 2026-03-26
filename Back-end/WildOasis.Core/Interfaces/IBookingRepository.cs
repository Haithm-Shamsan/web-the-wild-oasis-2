using Api_WildOasis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildOasis.Core.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task<Booking> AddBookingAsync(Booking newBooking);
        Task<Booking> UpdateBookingAsync(int id, Booking updatedBooking);
        Task<bool> DeleteBookingAsync(int id);
    }
}
