using System;
using System.Collections.Generic;

namespace WebAPIdeGraaf.Models
{
    public partial class Reviews
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public decimal? Rating { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Completed { get; set; }

        public virtual Users User { get; set; }
    }
}
