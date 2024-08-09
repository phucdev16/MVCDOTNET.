using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC21BITV03MidTest.Models
{
    public class ListCustomers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required]
        [ForeignKey("Car")]
        public int CarId { get; set; }
        [ForeignKey("Sale")]
        public int SaleId { get; set; }
        public Sale Sales { get; set; }
        public Car CarNav { get; set; }
        public Customer CustomerNav { get; set; }

    }
}
