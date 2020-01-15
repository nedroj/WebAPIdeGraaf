using System;
using System.Collections.Generic;

namespace WebAPIdeGraaf.Models
{
    public partial class Orders
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public long? ReceiptId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? UserId { get; set; }
        public bool? Completed { get; set; }

        public virtual Products Product { get; set; }
        public virtual Receipts Receipt { get; set; }
        public virtual Users User { get; set; }
    }
}
