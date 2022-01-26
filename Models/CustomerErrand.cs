using System;
using System.Collections.Generic;

namespace WPF_SQL_SYSTEM.Models
{
    public partial class CustomerErrand
    {
        public int Id { get; set; }
        public string ErrandTitle { get; set; } = null!;
        public string ErrandDescription { get; set; } = null!;
        public DateTime ErrandCreatedTime { get; set; }
        public DateTime ErrandChangedTime { get; set; }
        public string ErrandStatus { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
