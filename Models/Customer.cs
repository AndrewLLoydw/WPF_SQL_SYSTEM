using System;
using System.Collections.Generic;

namespace WPF_SQL_SYSTEM.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerErrands = new HashSet<CustomerErrand>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int AddressId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual ICollection<CustomerErrand> CustomerErrands { get; set; }
    }
}
