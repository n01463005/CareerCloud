using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CareerCloud.Pocos
{
    [Table("System_Country_Codes")]
  public  class SystemCountryCodePoco
    {
        
        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }

       // public virtual ICollection<CompanyLocationPoco> CompanyLocations { get; set; }
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
