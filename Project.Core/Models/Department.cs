using Project.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Models
{
    public class Department : AuditableEntity
    {
        public string Title { get; set; }   
        public ICollection<Doctor> Doctors { get; set; }
    }
}
