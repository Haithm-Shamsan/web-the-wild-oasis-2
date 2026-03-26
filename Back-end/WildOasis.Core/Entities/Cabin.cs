using System;
using System.Collections.Generic;

namespace Api_WildOasis.Entities;

public partial class Cabin
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public byte MaxCapacity { get; set; }

    public double RegularPrice { get; set; }

    public short Discount { get; set; }

    public string Description { get; set; } = null!;

    public string Image { get; set; } = null!;

    
}
