using Api_WildOasis.Data;
using Api_WildOasis.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildOasis.Core.Interfaces;
using System.Xml.Linq;

namespace WildOasis.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly WildOasisContext _context;

        public BookingRepository(WildOasisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task<Booking> AddBookingAsync(Booking newBookingDto)
        {

            var newBooking = new Booking
            {
                StartDate = newBookingDto.StartDate,
                EndDate = newBookingDto.EndDate,
                NumNights = newBookingDto.NumNights,
                NumGuests = newBookingDto.NumGuests,
                CabinPrice = newBookingDto.CabinPrice,
                ExtrasPrice = newBookingDto.ExtrasPrice,
                TotalPrice = newBookingDto.TotalPrice,
                Status = newBookingDto.Status,
                HasBreakfast = newBookingDto.HasBreakfast,
                IsPaid = newBookingDto.IsPaid,
                Observations = newBookingDto.Observations,
                CabinId = newBookingDto.CabinId,
                PersonId = newBookingDto.PersonId
            };
            _context.Bookings.Add(newBooking);
            await _context.SaveChangesAsync();
            return newBooking;
        }

        public async Task<Booking> UpdateBookingAsync(int id, Booking updatedBooking)
        {
            var existingBooking = await _context.Bookings.FindAsync(id);
            if (existingBooking == null) return null;

            existingBooking.Status = updatedBooking.Status ?? existingBooking.Status;
            existingBooking.NumNights = updatedBooking.NumNights != 0 ? updatedBooking.NumNights : existingBooking.NumNights;
            existingBooking.NumGuests = updatedBooking.NumGuests != 0 ? updatedBooking.NumGuests : existingBooking.NumGuests;
            existingBooking.StartDate = updatedBooking.StartDate != default ? updatedBooking.StartDate : existingBooking.StartDate;
            existingBooking.EndDate = updatedBooking.EndDate != default ? updatedBooking.EndDate : existingBooking.EndDate;
            existingBooking.CabinPrice = updatedBooking.CabinPrice != 0 ? updatedBooking.CabinPrice : existingBooking.CabinPrice;
            existingBooking.ExtrasPrice = updatedBooking.ExtrasPrice != 0 ? updatedBooking.ExtrasPrice : existingBooking.ExtrasPrice;
            existingBooking.TotalPrice = updatedBooking.TotalPrice != 0 ? updatedBooking.TotalPrice : existingBooking.TotalPrice;
            existingBooking.HasBreakfast = updatedBooking.HasBreakfast;
            existingBooking.IsPaid = updatedBooking.IsPaid;
            existingBooking.Observations = updatedBooking.Observations ?? existingBooking.Observations;
            existingBooking.CabinId = updatedBooking.CabinId != 0 ? updatedBooking.CabinId : existingBooking.CabinId;
            existingBooking.PersonId = updatedBooking.PersonId != 0 ? updatedBooking.PersonId : existingBooking.PersonId;

            await _context.SaveChangesAsync();
            return existingBooking;
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return false;

            _context.Bookings.Remove(booking);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}


