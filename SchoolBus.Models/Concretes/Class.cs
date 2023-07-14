using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolBus.Models.Abstracts;


namespace SchoolBus.Models.Concretes
{
    public class Class : BaseEntity
    {
        public string Name { get; set; } = null!;

        public virtual IEnumerable<Student>? Students { get; set; }
    }
}
