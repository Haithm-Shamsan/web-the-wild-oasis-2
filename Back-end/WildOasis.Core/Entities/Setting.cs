using System;
using System.Collections.Generic;

namespace Api_WildOasis.Entities;

public partial class Setting
{
    public int Id { get; set; }

    public short MinBookingLength { get; set; }

    public short MaxBookingLength { get; set; }

    public short MaxGuestsPerBooking { get; set; }

    public double BreakfastPrice { get; set; }
}
