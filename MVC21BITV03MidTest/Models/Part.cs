using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC21BITV03MidTest.Models;

public partial class Part
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public double? Price { get; set; }
    [Required]
    public int Quantity { get; set; }

    [ForeignKey("Supplier")]
    [Required]
    public int SupplierId { get; set; }

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
