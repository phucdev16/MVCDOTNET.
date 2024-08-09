using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC21BITV03MidTest.Models;

public partial class Customer
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]

    public DateTime BirthDate { get; set; }
    
    public bool IsYoungDriver { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
