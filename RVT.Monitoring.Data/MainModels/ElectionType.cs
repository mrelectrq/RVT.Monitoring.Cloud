using RVT.Monitoring.Data.IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVT.Monitoring.Data.MainModels
{
    public class ElectionType
    {
         public Guid ElectionTypeId { get; set; }
        public RVTUser CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
