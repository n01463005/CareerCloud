using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.ApplicantProfileService;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantProfileServices : ApplicantProfileServiceBase
    {
        private readonly ApplicantProfileLogic _logic;
        public ApplicantProfileServices()
        {
            _logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
        }

        public override Task<ApplicantProfile> GetApplicantProfile(AppProfileIdRequest request, ServerCallContext context)
        {
            var poco = _logic.Get(Guid.Parse(request.Id));

            if(poco is null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return Task.FromResult (new ApplicantProfile
            {
                Id = poco.Id.ToString(),
                Login = poco.Login.ToString(),
                CurrentSalary = (double?)poco.CurrentSalary,
                CurrentRate = (double?)poco.CurrentRate,
                Currency = poco.Currency,
                Country = poco.Country,
                Province = poco.Province,
                Street = poco.Street,
                City = poco.City,
                PostalCode = poco.PostalCode



            });

        }

        public override Task<Empty> CreateApplicantProfile(ApplicantProfiles request, ServerCallContext context)
        {
            List<ApplicantProfilePoco> pocos = new List<ApplicantProfilePoco>();

            foreach(var item in request.AppPro)
            {
                ApplicantProfilePoco poco = new ApplicantProfilePoco()
                {

                    Id = Guid.Parse(item.Id),
                    Login = Guid.Parse(item.Login),
                    CurrentSalary = (decimal?)item.CurrentSalary,
                    CurrentRate = (decimal?)item.CurrentRate,
                    Currency = item.Currency,
                    Country = item.Country,
                    Province = item.Province,
                    Street = item.Street,
                    City = item.City,
                    PostalCode = item.PostalCode
                };

                pocos.Add(poco);
            }

            _logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
         }
            
        

        public override Task<Empty> UpdateApplicantProfile(ApplicantProfiles request, ServerCallContext context)
        {
            List<ApplicantProfilePoco> poco = new List<ApplicantProfilePoco>();
            foreach(var item in request.AppPro)
              {
                        var pocoToUpdate = _logic.Get(Guid.Parse(item.Id));
                        pocoToUpdate.Login = Guid.Parse(item.Login);
                        pocoToUpdate.CurrentSalary = (decimal?)item.CurrentSalary;
                        pocoToUpdate.CurrentRate = (decimal?)item.CurrentRate;
                        pocoToUpdate.Currency = item.Currency;
                        pocoToUpdate.Country = item.Country;
                        pocoToUpdate.Province = item.Province;
                        pocoToUpdate.Street = item.Street;
                        pocoToUpdate.City = item.City;
                        pocoToUpdate.PostalCode = item.PostalCode;
                    poco.Add(pocoToUpdate);
               }
            _logic.Update(poco.ToArray());
            return Task.FromResult(new Empty());
         }
            
           
        

        public override Task<Empty> DeleteApplicantProfile(ApplicantProfiles request, ServerCallContext context)
        {
            List<ApplicantProfilePoco> pocos = new List<ApplicantProfilePoco>();

            foreach(var item in request.AppPro)
            {
                var pocoToDelete = _logic.Get(Guid.Parse(item.Id));
                pocos.Add(pocoToDelete);
            }
                _logic.Delete(pocos.ToArray());
                return Task.FromResult(new Empty());
            
        }
    }
}
/*CurrentSalary
CurrentRate
Currency = 5;
string Country = 6;
string Province = 7;
string Street = 8;
string City = 9;
string PostalCode*/