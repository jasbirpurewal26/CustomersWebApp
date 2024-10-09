namespace CustomersWebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
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
