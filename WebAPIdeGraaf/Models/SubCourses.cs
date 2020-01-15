using System;
using System.Collections.Generic;

namespace WebAPIdeGraaf.Models
{
    public partial class SubCourses
    {
        public SubCourses()
        {
            Products = new HashSet<Products>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? MainCourseId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual MainCourses MainCourse { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
