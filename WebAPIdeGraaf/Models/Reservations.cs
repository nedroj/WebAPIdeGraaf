using System;
using System.Collections.Generic;

namespace WebAPIdeGraaf.Models
{
    public partial class Reservations
    {
        public Reservations()
        {
            ReservationTables = new HashSet<ReservationTables>();
        }

        public long Id { get; set; }
        public long? UserId { get; set; }
        public int? People { get; set; }
        public bool? UsedReservation { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string Comment { get; set; }
        public string ReservationType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<ReservationTables> ReservationTables { get; set; }
    }
}
