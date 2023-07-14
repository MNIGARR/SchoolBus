using SchoolBus.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus.Models.Concretes
{
    public class Driver : BaseEntity
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int? CarId { get; set; }

        public int? RideId { get; set; }

        public bool HasLicence { get; set; }

        public string Address { get; set; } = null!;

        public Car? Car { get; set; }

        public Ride? Ride { get; set; }


        public override string ToString() => $"{FirstName} {LastName}";

    }
}
