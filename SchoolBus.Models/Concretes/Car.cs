using SchoolBus.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus.Models.Concretes
{
    public class Car : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string CarNumber { get; set; } = null!;

        public int SeatCount { get; set; }

        public Driver? Driver { get; set; }

        public override string ToString()
        {
            return $"{Name} {CarNumber} {SeatCount}";
        }
    }
}
