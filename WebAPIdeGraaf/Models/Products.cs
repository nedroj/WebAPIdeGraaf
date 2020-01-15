using System;
using System.Collections.Generic;

namespace WebAPIdeGraaf.Models
{
    public partial class Products
    {
        public Products()
        {
            Orders = new HashSet<Orders>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public long? SubCourseId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual SubCourses SubCourse { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
