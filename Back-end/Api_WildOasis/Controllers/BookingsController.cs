using Api_WildOasis.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WildOasis.Core.Interfaces;

namespace Api_WildOasis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingsController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        /// <summary>
        /// Retrieves all bookings.
        /// </summary>
        /// <returns>A list of bookings.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Booking>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllBookings()
        {
            try
            {
                var bookings = await _bookingRepository.GetBookingsAsync();
                return Ok(bookings);
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Retrieves a booking by its ID.
        /// </summary>
        /// <param name="id">The ID of the booking.</param>
        /// <returns>The booking details.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Booking), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetBookingById(int id)
        {
            try
            {
                var booking = await _bookingRepository.GetBookingByIdAsync(id);

                if (booking == null)
                {
                    return NotFound();
                }

                return Ok(booking);
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Adds a new booking.
        /// </summary>
        /// <param name="newBooking">The booking to add.</param>
        /// <returns>The created booking.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Booking), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBooking([FromBody] Booking createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var booking = await _bookingRepository.AddBookingAsync(createDto);

            return CreatedAtAction(nameof(GetBookingById), new { id = booking.BookingId }, booking);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] Booking updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var booking = await _bookingRepository.UpdateBookingAsync(id, updateDto);

            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

       
        /// <summary>
        /// Deletes a booking by its ID.
        /// </summary>
        /// <param name="id">The ID of the booking to delete.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            try
            {
                var success = await _bookingRepository.DeleteBookingAsync(id);

                if (!success)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
