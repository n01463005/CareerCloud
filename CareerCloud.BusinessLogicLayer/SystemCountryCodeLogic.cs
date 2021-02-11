using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
   public class SystemCountryCodeLogic
    {
        protected IDataRepository<SystemCountryCodePoco> _repo;
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repo)  
            {
            _repo = repo;

        }
        public  void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repo.Add(pocos);
        }
        public void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
           _repo.Update(pocos);
        }
        
        public void Delete(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repo.Remove(pocos);
        }
        public List<SystemCountryCodePoco> GetAll()
        {
            return _repo.GetAll().ToList();
        }
        public SystemCountryCodePoco Get(string code)
        {

            return _repo.GetSingle(s => s.Code == code);
        }
        protected virtual void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (SystemCountryCodePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Code))
                {
                    exceptions.Add(new ValidationException(900, "Code can't be empty"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(901, "Name can't be empty"));
                }
                if(exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }

        }
    }
}
