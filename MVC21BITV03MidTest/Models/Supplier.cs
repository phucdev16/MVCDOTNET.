using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC21BITV03MidTest.Models;

public partial class Supplier
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsImporter { get; set; }

    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
