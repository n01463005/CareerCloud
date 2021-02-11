using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CareerCloud.BusinessLogicLayer
{
   public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repo) : base(repo)
        {

        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyProfilePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyWebsite))
                {
                    exceptions.Add(new ValidationException(600, $"company website{poco.CompanyWebsite} field is empty"));
                }
                else if (!Regex.IsMatch(poco.CompanyWebsite, @"\A(?:(http)?s?:\/\/)?(www.)?([a-z0-9!]+\-?[a-z0-9!]+)+\.(ca|biz|com)\Z", RegexOptions.IgnoreCase))
                {
                    exceptions.Add(new ValidationException(600, $"company website{poco.CompanyWebsite} is not a valid address format"));
                }


                if (string.IsNullOrEmpty(poco.ContactPhone) || poco.ContactPhone.Length < 12)
                {
                    exceptions.Add(new ValidationException(601, "Wrong Phone number"));
                }
                else
                {
                    string[] phoneDigit = poco.ContactPhone.Split('-');
                    if (phoneDigit.Length != 3)
                    {
                        exceptions.Add(new ValidationException(602, $"wrong Phone number of {poco.Id}"));
                    }
                    else
                    {
                        if (phoneDigit[0].Length != 3)
                        {
                            exceptions.Add(new ValidationException(603, $"Wrong 1st digit number of {poco.Id}"));
                        }
                        else if (phoneDigit[1].Length != 3)
                        {
                            exceptions.Add(new ValidationException(604, $"wrong 2nd digit number of {poco.Id}"));
                        }
                        else if (phoneDigit[2].Length != 4)
                        {
                            exceptions.Add(new ValidationException(605, $"wrond 3rd digit number of {poco.Id}"));
                        }

                    }
                }
               
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
           public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }

    }

