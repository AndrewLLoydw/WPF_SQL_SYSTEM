using System;
using System.Collections.Generic;

namespace WPF_SQL_SYSTEM.Models
{
    public partial class CustomerErrand
    {
        public int Id { get; set; }
        public string ErrandTitle { get; set; } = null!;
        public string ErrandDescription { get; set; } = null!;
        public string ErrandCreatedTime { get; set; } = null!;
        public string ErrandChangedTime { get; set; } = null!;
        public string ErrandStatus { get; set; } = null!;
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
