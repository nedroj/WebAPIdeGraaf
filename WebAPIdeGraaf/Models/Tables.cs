using System;
using System.Collections.Generic;

namespace WebAPIdeGraaf.Models
{
    public partial class Tables
    {
        public Tables()
        {
            ReservationTables = new HashSet<ReservationTables>();
        }

        public long Id { get; set; }
        public int? MinCapacity { get; set; }
        public int? MaxCapacity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<ReservationTables> ReservationTables { get; set; }
    }
}
