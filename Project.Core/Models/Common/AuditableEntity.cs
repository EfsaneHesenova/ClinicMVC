using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Models.Common
{
    public class AuditableEntity : BaseEntity
    {
        public DateTime Createdat { get; set; }
        public DateTime Updatedat { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
