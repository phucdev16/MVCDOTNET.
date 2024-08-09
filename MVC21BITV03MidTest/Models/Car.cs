using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC21BITV03MidTest.Models;

public partial class Car
{
    [Key]
    public int Id { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public long TravelledDistance { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
