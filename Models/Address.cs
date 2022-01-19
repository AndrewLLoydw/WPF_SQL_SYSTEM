using System;
using System.Collections.Generic;

namespace WPF_SQL_SYSTEM.Models
{
    public partial class Address
    {
        public Address()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string StreetName { get; set; } = null!;
        public int StreetNumber { get; set; }
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
