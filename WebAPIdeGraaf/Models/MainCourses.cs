using System;
using System.Collections.Generic;

namespace WebAPIdeGraaf.Models
{
    public partial class MainCourses
    {
        public MainCourses()
        {
            SubCourses = new HashSet<SubCourses>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<SubCourses> SubCourses { get; set; }
    }
}
