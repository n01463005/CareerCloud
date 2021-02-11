using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CareerCloud.Pocos
{
    [Table("System_Language_Codes")]
   public class SystemLanguageCodePoco
    {
        
       
        //public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        [Key]
        public string LanguageID { get; set; }
        public string Name { get; set; }

        [Column("Native_Name")]
        public string NativeName { get; set; }
    }
}
