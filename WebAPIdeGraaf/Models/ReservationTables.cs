using System;
using System.Collections.Generic;

namespace WebAPIdeGraaf.Models
{
    public partial class ReservationTables
    {
        public long ReservationId { get; set; }
        public long TableId { get; set; }

        public virtual Reservations Reservation { get; set; }
        public virtual Tables Table { get; set; }
    }
}
