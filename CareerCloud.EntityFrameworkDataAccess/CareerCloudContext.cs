using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CareerCloud.Pocos;
namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public virtual DbSet<ApplicantEducationPoco> ApplicantEducations { set; get; }
        public virtual DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { set; get; }
        public virtual DbSet<ApplicantProfilePoco> ApplicantProfile { set; get; }
        public virtual DbSet<ApplicantResumePoco> ApplicantResumes { set; get; }
        public virtual DbSet<ApplicantSkillPoco> ApplicantSkills { set; get; }
        public virtual DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { set; get; }
        public virtual DbSet<CompanyDescriptionPoco> CompanyDescriptions { set; get; }
        public virtual DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { set; get; }
        public virtual DbSet<CompanyJobEducationPoco> CompanyJobEducations { set; get; }
        public virtual DbSet<CompanyJobPoco> CompanyJobs { set; get; }
        public virtual DbSet<CompanyJobSkillPoco> CompanyJobSkills { set; get; }
        public virtual DbSet<CompanyLocationPoco> CompanyLocations { set; get; }
        public virtual DbSet<CompanyProfilePoco> CompanyProfiles { set; get; }
        public virtual DbSet<SecurityLoginPoco> SecurityLogins { set; get; }
        public virtual DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { set; get; }
        public virtual DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { set; get; }
        public virtual DbSet<SecurityRolePoco> SecurityRoles { set; get; }
        public virtual DbSet<SystemCountryCodePoco> SystemCountryCodes { set; get; }
        public virtual DbSet<SystemLanguageCodePoco> SystemLanguageCodes { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            BaseCon basecon = new BaseCon();
            optionBuilder.UseSqlServer(basecon._connstr);
            base.OnConfiguring(optionBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantEducationPoco>(entity =>
            {
                entity.ToTable("Applicant_Educations");

                entity.Property(a => a.Id).ValueGeneratedNever();
                entity.Property(a => a.Applicant).ValueGeneratedNever();
                entity.Property(a => a.Major)
                      .HasMaxLength(100);
                entity.Property(a => a.CertificateDiploma)
                      .HasColumnName("Certificate_Diploma")
                      .HasMaxLength(100);
                entity.Property(a => a.StartDate)
                      .HasColumnName("Start_Date");

                entity.Property(a => a.TimeStamp)
                     .HasColumnName("Time_Stamp")
                     .IsRowVersion()
                     .IsConcurrencyToken();

                entity.HasOne(a => a.ApplicantProfile)
                      .WithMany(a => a.ApplicantEducations)
                      .HasForeignKey(f => f.Applicant)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Applicant_Educations_Applicant_Profile");



            });
            modelBuilder.Entity<ApplicantJobApplicationPoco>(entity =>
            {
                entity.ToTable("Applicant_Job_Applications");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Applicant).ValueGeneratedNever();
                entity.Property(e => e.Job).ValueGeneratedNever();

                entity.Property(e => e.ApplicationDate)
                      .HasColumnName("Application_Date")
                      .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TimeStamp)
                       .IsRequired()
                       .HasColumnName("Time_Stamp")
                       .IsRowVersion()
                       .IsConcurrencyToken();

                entity.HasOne(a => a.ApplicantProfile)
                      .WithMany(p => p.ApplicantJobApplications)
                      .HasForeignKey(f => f.Applicant)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Applicant_Job_Applications_Applicant_Profiles");

                entity.HasOne(a => a.CompanyJob)
                      .WithMany(p => p.ApplicantJobApplications)
                      .HasForeignKey(f => f.Job)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Applicant_Job_Applications_Company_Jobs");

            });
            modelBuilder.Entity<ApplicantProfilePoco>(entity =>
            {
                entity.ToTable("Applicant_Profiles");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Login).ValueGeneratedNever();


                entity.Property(e => e.City)
                       .HasColumnName("City_Town")
                      .HasMaxLength(100);

                entity.Property(e => e.Country)
                .HasColumnName("Country_Code")
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

                entity.Property(e => e.Currency)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

                entity.Property(e => e.CurrentRate)
                .HasColumnName("Current_Rate")
                .HasColumnType("deciaml(18, 2");

                entity.Property(e => e.CurrentSalary)
                .HasColumnName("Current_Salary")
                .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Province)
                .HasColumnName("State_Province_Code")
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

                entity.Property(e => e.Street)
                      .HasColumnName("Street_Address")
                      .HasMaxLength(100);

                entity.Property(e => e.TimeStamp)
                       .IsRequired()
                       .HasColumnName("Time_Stamp")
                       .IsRowVersion()
                       .IsConcurrencyToken();

                entity.Property(e => e.PostalCode)
                       .HasColumnName("Zip_Postal_Code")
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .IsFixedLength();

                entity.HasOne(d => d.SystemCountryCode)
                       .WithMany(p => p.ApplicantProfiles)
                       .HasForeignKey(d => d.Country)
                       .HasConstraintName("FK_Applicant_Profiles_System_Country_Codes");

                entity.HasOne(d => d.SecurityLogin)
                       .WithMany(p => p.ApplicantProfiles)
                       .HasForeignKey(d => d.Login)
                       .OnDelete(DeleteBehavior.ClientSetNull)
                       .HasConstraintName("FK_Applicant_Profiles_Security_Logins");
            });

            modelBuilder.Entity<ApplicantResumePoco>(entity =>
            {
                entity.ToTable("Applicant_Resumes");
                entity.Property(a => a.Id).ValueGeneratedNever();
                entity.Property(a => a.Applicant).ValueGeneratedNever();

                entity.Property(a => a.LastUpdated).HasDefaultValueSql("(getdate())")
                      .HasColumnName("Last_Updated");
                entity.HasOne(d => d.ApplicantProfile)
                      .WithMany(r => r.ApplicantResumes)
                      .HasForeignKey(f => f.Applicant)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Applicant_Resumes_Applicant_Profiles");

            });
            modelBuilder.Entity<ApplicantSkillPoco>(entity =>
            {
                entity.ToTable("Applicant_Skills");
                entity.Property(a => a.Id).ValueGeneratedNever();
                entity.Property(a => a.Id).ValueGeneratedNever();

                entity.Property(a => a.Skill)
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.SkillLevel)
                      .HasColumnName("Skill_Level")
                      .HasMaxLength(10)
                      .IsUnicode(false)
                      .IsFixedLength(true);
                entity.Property(a => a.TimeStamp)
                       .IsRequired()
                       .HasColumnName("Time_Stamp")
                       .IsRowVersion()
                       .IsConcurrencyToken();
                entity.HasOne(d => d.ApplicantProfile)
                      .WithMany(s => s.ApplicantSkills)
                      .HasForeignKey(e => e.Applicant)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Applicant_Skills_Applicant_Profiles");

            });
            modelBuilder.Entity<ApplicantWorkHistoryPoco>(entity =>
            {
                entity.ToTable("Applicant_Work_History");
                entity.Property(a => a.Id).ValueGeneratedNever();
                entity.Property(a => a.Applicant).ValueGeneratedNever();
                entity.Property(a => a.CountryCode)
                      .HasColumnName("Country_Code")
                      .HasMaxLength(10)
                      .IsUnicode(false)
                      .IsFixedLength(true);

                entity.Property(a => a.CompanyName)
                      .HasColumnName("Company_Name")
                      .HasMaxLength(150)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.Location)
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.JobTitle)
                      .HasColumnName("Job_Title")
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.JobDescription)
                      .HasColumnName("Job_Description")
                      .HasMaxLength(500)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.StartMonth)
                      .HasColumnName("Start_Month")
                      .HasColumnType("smallint");
                //check after test!!!
                entity.Property(a => a.TimeStamp)
                       .IsRequired()
                       .HasColumnName("Time_Stamp")
                       .IsRowVersion()
                       .IsConcurrencyToken();
                entity.HasOne(d => d.ApplicantProfile)
                      .WithMany(w => w.ApplicantWorkHistorys)
                      .HasForeignKey(g => g.Applicant)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Applicant_Work_Experience_Applicant_Profiles");
                entity.HasOne(d => d.SystemCountryCode)
                      .WithMany(g => g.ApplicantWorkHistories)
                      .HasForeignKey(e => e.CountryCode)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Applicant_Work_History_System_Country_Codes");
            });
                modelBuilder.Entity<CompanyDescriptionPoco>(entity => 
                {
                    entity.ToTable("Company_Descriptions");
                    entity.Property(a => a.Id).ValueGeneratedNever();
                    entity.Property(a => a.Company).ValueGeneratedNever();
                    entity.Property(a => a.LanguageId)
                          .HasColumnName("LanguageID")
                          .HasMaxLength(10)
                          .IsUnicode(false)

                          .IsFixedLength(true);
                    entity.Property(a => a.CompanyName)
                          .HasColumnName("Company_Name")
                          .HasMaxLength(50)
                          .IsUnicode(false)
                          .IsFixedLength();

                    entity.Property(a => a.CompanyDescription)
                          .HasColumnName("Company_Description")
                          .HasMaxLength(1000)
                          .IsUnicode(false)
                          .IsFixedLength();
                    entity.Property(a => a.TimeStamp)
                      .IsRequired()
                      .HasColumnName("Time_Stamp")
                      .IsRowVersion()
                      .IsConcurrencyToken();
                    entity.HasOne(a => a.CompanyProfile)
                          .WithMany(c => c.CompanyDescriptions)
                          .HasForeignKey(e => e.Company)
                          .OnDelete(DeleteBehavior.ClientSetNull)
                          .HasConstraintName("Company_Descriptions_Company_Profiles");
                    entity.HasOne(a => a.SystemLanguageCode)
                          .WithMany(b => b.CompanyDescriptions)
                          .HasForeignKey(x => x.LanguageId)
                          .OnDelete(DeleteBehavior.ClientSetNull)
                          .HasConstraintName("Company_Descriptions_System_Language_Codes");

                });
            modelBuilder.Entity<CompanyJobEducationPoco>(entity => 
            {
                entity.ToTable("Company_Job_Educations");
                entity.Property(a => a.Id).ValueGeneratedNever();
                entity.Property(a => a.Job).ValueGeneratedNever();

                entity.Property(a => a.Major)
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.Importance)
                      .HasColumnType("smallint");
                entity.Property(a => a.TimeStamp)
                      .IsRequired()
                      .HasColumnName("Time_Stamp")
                      .IsRowVersion()
                      .IsConcurrencyToken();
                entity.HasOne(a => a.CompanyJob)
                      .WithMany(x => x.CompanyJobEducations)
                      .HasForeignKey(y => y.Job)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Company_Job_Educations_Company_Jobs");

            });
            modelBuilder.Entity<CompanyJobSkillPoco>(entity => 
            {
                entity.ToTable("Company_Job_Skills");
                entity.Property(a => a.Id).ValueGeneratedNever();
                entity.Property(a => a.Job).ValueGeneratedNever();
                entity.Property(a => a.Skill)
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .IsFixedLength();

                entity.Property(a => a.SkillLevel)
                      .HasColumnName("Skill_Level")
                      .HasMaxLength(10)
                      .IsUnicode(false)
                      .IsFixedLength();
                // Check after test???
                entity.Property(a => a.TimeStamp)
                     .IsRequired()
                     .HasColumnName("Time_Stamp")
                     .IsRowVersion()
                     .IsConcurrencyToken();

                entity.HasOne(a => a.CompanyJob)
                      .WithMany(x => x.CompanyJobSkills)
                      .HasForeignKey(y => y.Job)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Company_Job_Skills_Company_Jobs");
            });
            modelBuilder.Entity<CompanyJobPoco>(entity =>
            {
                entity.ToTable("Company_Jobs");
                entity.Property(a => a.Id).ValueGeneratedNever();
                entity.Property(a => a.Company).ValueGeneratedNever();
                entity.Property(a => a.ProfileCreated).HasDefaultValueSql("(getdate())")
                      .HasColumnName("Profile_Created");
                //Check???
                entity.Property(a => a.TimeStamp)
                    .IsRequired()
                    .HasColumnName("Time_Stamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.HasOne(a => a.CompanyProfile)
                      .WithMany(x => x.CompanyJobs)
                      .HasForeignKey(y => y.Company)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Company_Jobs_Company_Profiles");
            });
            modelBuilder.Entity<CompanyJobDescriptionPoco>(entity =>
            {
                entity.ToTable("Company_Jobs_Descriptions");
                entity.Property(a => a.Id).ValueGeneratedNever();
                entity.Property(x => x.Job).ValueGeneratedNever();
                entity.Property(a => a.JobName)
                      .HasColumnName("Job_Name")
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .IsFixedLength();

                entity.Property(a => a.JobDescriptions)
                      .HasColumnName("Job_Descriptions")
                      .HasMaxLength(1000)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.TimeStamp)
                    .IsRequired()
                    .HasColumnName("Time_Stamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.HasOne(a => a.CompanyJob)
                      .WithMany(x => x.CompanyJobDescriptions)
                      .HasForeignKey(y => y.Job)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Company_Jobs_Descriptions_Company_Jobs");

            });

            modelBuilder.Entity<CompanyLocationPoco>(entity =>
            {
                entity.ToTable("Company_Locations");
                entity.Property(a => a.Id).ValueGeneratedNever();
                entity.Property(a => a.Company).ValueGeneratedNever();
                entity.Property(a => a.CountryCode)
                      .HasColumnName("Country_Code")
                      .HasMaxLength(10)
                      .IsUnicode(false)
                      .IsFixedLength(true);
                entity.Property(a => a.Province)
                      .HasColumnName("State_Province_Code")
                      .HasMaxLength(10)
                      .IsUnicode(false)
                      .IsFixedLength(true);
                entity.Property(a => a.Street)
                      .HasColumnName("Street_Address")
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.City)
                      .HasColumnName("City_Town")
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.PostalCode)
                      .HasColumnName("Zip_Postal_Code")
                      .HasMaxLength(20)
                      .IsUnicode(false)
                      .IsFixedLength(true);
                entity.Property(a => a.TimeStamp)
                   .IsRequired()
                   .HasColumnName("Time_Stamp")
                   .IsRowVersion()
                   .IsConcurrencyToken();
                entity.HasOne(a => a.CompanyProfile)
                      .WithMany(x => x.CompanyLocations)
                      .HasForeignKey(y => y.Company)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Company_Locations_Company_Profiles");



            });
            modelBuilder.Entity<CompanyProfilePoco>(entity =>
            {
                entity.ToTable("Company_Profiles");
                entity.Property(a => a.Id).HasDefaultValueSql("(new())");
                entity.Property(a => a.RegistrationDate).HasDefaultValueSql("(getdate())")
                      .HasColumnName("Registration_Date");
                entity.Property(a => a.CompanyWebsite)
                      .HasColumnName("Company_Website")
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.ContactPhone)
                      .HasColumnName("Contact_Phone")
                      .HasMaxLength(20)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.ContactName)
                      .HasColumnName("Contact_Name")
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.CompanyLogo)
                      .HasColumnName("Company_Logo")
                      .HasColumnType("deciaml(18, 2");
                //check 
                entity.Property(a => a.TimeStamp)
                  .IsRequired()
                  .HasColumnName("Time_Stamp")
                  .IsRowVersion()
                  .IsConcurrencyToken();
            });

            modelBuilder.Entity<SecurityLoginPoco>(entity => 
            {
                entity.ToTable("Security_Logins");
                entity.Property(a => a.Id).HasDefaultValueSql("(new())");
                entity.Property(a => a.Login)
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.Login)
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.Password)
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.Created).HasDefaultValueSql("(getdate())")
                      .HasColumnName("Created_Date");
                entity.Property(a => a.PasswordUpdate).HasDefaultValueSql("(getdate())")
                      .HasColumnName("Password_Update_Date");
                entity.Property(a => a.AgreementAccepted).HasDefaultValueSql("(getdate())")
                      .HasColumnName("Agreement_Accepted_Date");
                //check
                entity.Property(a => a.EmailAddress)
                     .HasColumnName("Email_Address")
                     .HasMaxLength(100)
                     .IsUnicode(false)
                     .IsFixedLength();
                entity.Property(a => a.PhoneNumber)
                      .HasColumnName("Phone_Number")
                      .HasMaxLength(20)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.FullName)
                     .HasColumnName("Full_Name")
                     .HasMaxLength(100)
                     .IsUnicode(false)
                     .IsFixedLength();
                
                entity.Property(a => a.TimeStamp)
                  .IsRequired()
                  .HasColumnName("Time_Stamp")
                  .IsRowVersion()
                  .IsConcurrencyToken();
            });
            modelBuilder.Entity<SecurityLoginsLogPoco>(entity => 
            {
                entity.ToTable("Security_Logins_Log");
                entity.Property(a => a.Id).ValueGeneratedNever();
                entity.Property(a => a.Login).ValueGeneratedNever();
                entity.Property(a => a.SourceIP)
                      .HasColumnName("Source_Ip")
                      .HasMaxLength(15)
                      .IsUnicode(false)
                      .IsFixedLength(true);
                entity.Property(a => a.LogonDate).HasDefaultValueSql("(getdate())")
                      .HasColumnName("Logon_Date");
               
                entity.HasOne(a => a.SecurityLogin)
                      .WithMany(x => x.SecurityLoginsLogs)
                      .HasForeignKey(y => y.Login)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Security_Logins_Log_Security_Logins");
            });

            modelBuilder.Entity<SecurityLoginsRolePoco>(entity => 
            {
                entity.ToTable("Security_Logins_Roles");
                entity.Property(a => a.Id).ValueGeneratedNever();
                entity.Property(a => a.Login).ValueGeneratedNever();
                entity.Property(x => x.Role).ValueGeneratedNever();
                entity.Property(a => a.TimeStamp)
                 .IsRequired()
                 .HasColumnName("Time_Stamp")
                 .IsRowVersion()
                 .IsConcurrencyToken();
                entity.HasOne(a => a.SecurityLogin)
                      .WithMany(x => x.SecurityLoginsRoles)
                      .HasForeignKey(y => y.Login)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Security_Logins_Roles_Security_Logins");
                entity.HasOne(a => a.SecurityRole)
                      .WithMany(x => x.SecurityLoginsRoles)
                      .HasForeignKey(y => y.Role)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Securiy_Logins_Roles_Security_Roles");

            });
            modelBuilder.Entity<SecurityRolePoco>(entity => 
            {
                entity.ToTable("Security_Roles");
                entity.Property(a => a.Id).ValueGeneratedNever();
                entity.Property(a => a.Role)
                     .HasMaxLength(50)
                     .IsUnicode(false)
                     .IsFixedLength();
              
                      
            });

            modelBuilder.Entity<SystemCountryCodePoco>(entity => 
            {
                entity.ToTable("System_Country_Codes");
                entity.Property(a => a.Code).ValueGeneratedNever()
                      .IsFixedLength(true);
                entity.Property(a => a.Name)
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .IsFixedLength();
            });

            modelBuilder.Entity<SystemLanguageCodePoco>(entity => 
            {
                entity.ToTable("System_Language_Codes");
                entity.Property(a => a.LanguageID).ValueGeneratedNever()
                      .IsFixedLength(true);
                entity.Property(a => a.Name)
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .IsFixedLength();
                entity.Property(a => a.NativeName)
                      .HasColumnName("Native_Name")
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .IsFixedLength();
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}