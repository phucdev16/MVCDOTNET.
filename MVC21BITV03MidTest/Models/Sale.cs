using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC21BITV03MidTest.Models;

public partial class Sale
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Car")]
    public int? CarId { get; set; }
    [ForeignKey("Customer")]
    public int? CustomerId { get; set; }

    public double Discount { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Customer? Customer { get; set; }
}
