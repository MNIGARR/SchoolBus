using SchoolBus.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus.Models.Concretes
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int ParentId { get; set; }

        public int RideId { get; set; }

        public int ClassId { get; set; }

        public string HomeAddress { get; set; } = null!;

        public Parent? Parent { get; set; }

        public Ride? Ride { get; set; }

        public Class? Class { get; set; }
    }
}
