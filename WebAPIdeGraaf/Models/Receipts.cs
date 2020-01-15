using System;
using System.Collections.Generic;

namespace WebAPIdeGraaf.Models
{
    public partial class Receipts
    {
        public Receipts()
        {
            Orders = new HashSet<Orders>();
        }

        public long Id { get; set; }
        public string Payment { get; set; }
        public double? AmountRecieved { get; set; }
        public long? ReservationId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
