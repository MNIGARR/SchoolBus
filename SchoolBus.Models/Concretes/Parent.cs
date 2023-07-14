using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolBus.Models.Abstracts;

namespace SchoolBus.Models.Concretes
{
    public class Parent : BaseEntity
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual IEnumerable<Student>? Students { get; set; }
    }
}
