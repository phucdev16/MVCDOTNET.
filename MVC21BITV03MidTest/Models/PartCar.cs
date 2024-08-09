using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC21BITV03MidTest.Models
{
    public class PartCar
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }
        [ForeignKey("Part")]
        public int PartId { get; set; }
        public Car? CarNav { get; set; }
        public Part? PartNav { get; set; }
    }
}
