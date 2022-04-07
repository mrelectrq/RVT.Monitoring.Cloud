using RVT.Monitoring.Data.IdentityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVT.Monitoring.Data.MainModels
{
   public class Election
    {
        [Key]
        public Guid ElectionId { get; set; }
        public RVTUser CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ClosureTime { get; set; }
        [MaxLength(20)]
        public string ElectionShortName { get; set; }
        [MaxLength(300)]
        public string ElectionFullName { get; set; }
        [MaxLength(4000)]
        public string AditionalInfo { get; set; }
        public ElectionType ElectionType { get; set; }
        public RVTUser ManualCloseUser { get; set; }
        [MaxLength(4000)]
        public string CaseManualClosure { get; set; }


    }
}
