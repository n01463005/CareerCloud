using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Profiles")]
   public class ApplicantProfilePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Login { get; set; }

        [Column("Current_Salary")]
        public Decimal? CurrentSalary { get; set; }

        [Column("Current_Rate")]
        public Decimal? CurrentRate { get; set; }

        public string Currency { get; set; }

        [Column("Country_Code")]

        public string CountryCode { get; set; }

        [Column("State_Province_Code")]

        public string StateProvinceCode { get; set; }

        [Column("Street_Address")]

        public string  StreetAddress { get; set; }

        [Column("City_Town")]
        public string CityTown { get; set; }

        [Column("Zip_Postal_Code")]

        public string ZipPostalCode { get; set; }

        [Column("Time_Stamp")]

        public byte[] TimeStamp { get; set; }


    }
}
