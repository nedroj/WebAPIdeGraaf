using System;
using System.Collections.Generic;

namespace WebAPIdeGraaf.Models
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
            Reservations = new HashSet<Reservations>();
            Reviews = new HashSet<Reviews>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Infix { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public string Password { get; set; }
        public int? Isadmin { get; set; }
        public bool? Active { get; set; }
        public bool? Blocked { get; set; }
        public string RememberToken { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Reservations> Reservations { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
        public string Token { get; internal set; }
    }
}
