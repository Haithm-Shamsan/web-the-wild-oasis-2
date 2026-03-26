using System;
using System.Collections.Generic;

namespace Api_WildOasis.Entities;

public partial class Booking
{
    public int BookingId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public short NumNights { get; set; }

    public short NumGuests { get; set; }

    public double CabinPrice { get; set; }

    public double ExtrasPrice { get; set; }

    public double TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public bool HasBreakfast { get; set; }

    public bool IsPaid { get; set; }

    public string Observations { get; set; } = null!;

    public int CabinId { get; set; }

    public int PersonId { get; set; }

    //public virtual Cabin? Cabin { get; set; }
    //public virtual Person? Person { get; set; }
}
// DTO for creating a booking

