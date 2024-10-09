using System.ComponentModel.DataAnnotations;

namespace CustomersWebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [StringLength(60, MinimumLength = 3)] 
        public string Name { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        public string Address { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string City { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string PostCode { get; set; }

        [StringLength(60, MinimumLength = 2)]
        public string Country { get; set; }

        [StringLength(20,MinimumLength = 10)]
        public string Phone { get; set; }
        
        public Customer()
        {
            Id= 0;
            Name = "";
            Address = "";
            City = "";
            PostCode = "";
            Country = "";
            Phone = "";
        }

    }
}
