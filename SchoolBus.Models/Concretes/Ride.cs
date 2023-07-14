using SchoolBus.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus.Models.Concretes
{
    public class Ride : BaseEntity
    {
        public int DriverId { get; set; }

        public Driver? Driver { get; set; }

        public virtual IEnumerable<Student>? Students { get; set; }
    }
}
